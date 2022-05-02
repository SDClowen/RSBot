using RSBot.Core.Event;
using RSBot.Core.Network;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace RSBot.Core.Components
{
    public class ScriptManager
    {
        /// <summary>
        /// Gets or sets the script.
        /// </summary>
        /// <value>
        /// The script.
        /// </value>
        public static string Script { get; set; }

        /// <summary>
        /// Gets or sets the commands.
        /// </summary>
        /// <value>
        /// The commands.
        /// </value>
        public static ScriptCommand[] Commands { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ScriptManager"/> is running.
        /// </summary>
        /// <value>
        ///   <c>true</c> if running; otherwise, <c>false</c>.
        /// </value>
        public static bool Running { get; set; }

        /// <summary>
        /// Loads the specified script.
        /// </summary>
        /// <param name="script">The script.</param>
        public static void Load(string script)
        {
            if (!File.Exists(script))
            {
                Log.Notify($"Cannot load script [{script}] (File does not exist)!");
                return;
            }

            Script = script;
            Load(File.ReadAllLines(script));
        }

        /// <summary>
        /// Loads the specified commands.
        /// </summary>
        /// <param name="commands">The commands.</param>
        public static void Load(string[] commands)
        {
            if(commands.Length == 0)
            {
                Log.Notify($"Cannot load script commands (empty array)!");
                return;
            }

            IScriptParser parser;
            if (commands[0].Contains(",") || commands[0].Contains("scriptversion") || commands[0].Trim().ToLower()=="wait") //mbot script
            {
                parser = new MbotScriptParser();
            }
            else //rsbot script
            {
                parser = new NativeScriptParser();
            }

            Commands = parser.ParseCommands(commands);
            EventManager.FireEvent("OnLoadScript");
        }

        /// <summary>
        /// Runs this instance.
        /// </summary>
        public static void RunScript()
        {
            if (Commands == null || Commands.Length == 0)
            {
                Log.Notify("Cannot run an empty or unloaded script!");
                return;
            }

            Running = true;
            foreach (var command in Commands)
            {
                if (!Running) return;

                switch (command.Type)
                {
                    case ScriptCommandType.Move:
                        ExecuteMove((Position)command.arguments[0]);
                        break;

                    case ScriptCommandType.Buy:
                        Log.Notify("[Script] Purchasing items...");
                        ShoppingManager.Run((string)command.arguments[0]);
                        while (!ShoppingManager.Finished)
                            Thread.Sleep(50); //Wait until shopping is finished
                        break;

                    case ScriptCommandType.Repair:
                        Log.Notify("[Script] Repairing items...");
                        ShoppingManager.RepairItems((string)command.arguments[0]);
                        break;

                    case ScriptCommandType.Store:
                        ShoppingManager.StoreItems((string)command.arguments[0]);
                        Log.Notify("[Script] Storing items...");
                        break;

                    case ScriptCommandType.TeleportByCode:
                    case ScriptCommandType.TeleportById:
                        Log.Notify("[Script] Teleporting...");
                        ExecuteTeleport(command);
                        break;

                    case ScriptCommandType.Dismount:
                        Log.Notify("[Script] Dismounting vehicle...");
                        if (Game.Player.HasActiveVehicle)
                        {
                            Game.Player.Vehicle.Dismount();
                            Thread.Sleep(1000);
                        }
                        break;

                    case ScriptCommandType.Wait:
                        var duration = (int)command.arguments[0];
                        Log.Notify($"[Script] Waiting for {duration}ms");
                        Thread.Sleep(duration);
                        break;

                    default:
                        break;
                }
            }

            Running = false;

            EventManager.FireEvent("OnFinishScript");
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public static void Stop()
        {
            Running = false;
        }

        /// <summary>
        /// Executes the move.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        private static void ExecuteMove(Position pos)
        {

            //Check if the new position is nearby a cave enterance.
            //If so dismount the vehicle
            if (Game.Player.HasActiveVehicle)
            {
                if (Game.ReferenceManager.GetGroundTeleporters(pos.RegionID).Select(teleporter => pos.DistanceTo(teleporter.GetPosition())).Any(distanceToTeleporter => !(distanceToTeleporter > 5)))
                    Game.Player.Vehicle.Dismount();
            }

            var distance = pos.DistanceTo(Game.Player.Movement.Source);
            if (distance > 300)
            {
                Log.Debug("[Script] Target position too far away, bot logic aborted!");

                Kernel.Bot.Stop();
                return;
            }

            Game.Player.MoveTo(pos);
            Log.Debug($"[Script] Move to position X={pos.XCoordinate}, Y={pos.YCoordinate}");
        }

        /// <summary>
        /// Executes the teleport.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        private static void ExecuteTeleport(ScriptCommand teleportCommand)
        {
            var destination = teleportCommand.arguments[1];
            SpawnedBionic entity = null;

            if (teleportCommand.Type == ScriptCommandType.TeleportByCode)
            {
                var npcCodeName = (string)teleportCommand.arguments[0];

                if (!SpawnManager.TryGetEntity<SpawnedBionic>(p => p.Record.CodeName == npcCodeName, out entity))
                {
                    Log.Debug("Could not find teleportation NPC " + npcCodeName);
                    return;
                }
            }
            else if (teleportCommand.Type == ScriptCommandType.TeleportById)
            {
                var npcId = (uint)teleportCommand.arguments[0];
                if (!SpawnManager.TryGetEntity<SpawnedBionic>(p => p.Id == npcId, out entity))
                {
                    Log.Debug("Could not find teleportation NPC id:" + npcId);
                    return;
                }
            }
            else return;

            entity.TrySelect();

            var packet = new Packet(0x705A);
            packet.WriteUInt(entity.UniqueId);
            packet.WriteByte(0x02);
            packet.WriteUInt(destination);

            var callback = new AwaitCallback(null, 0x3012); //Game Ready
            PacketManager.SendPacket(packet, PacketDestination.Server, callback);

            callback.AwaitResponse(10000);
        }
    }
}