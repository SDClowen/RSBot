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
        public static string[] Commands { get; set; }

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
            Commands = File.ReadAllLines(script);

            EventManager.FireEvent("OnLoadScript");
        }

        /// <summary>
        /// Loads the specified commands.
        /// </summary>
        /// <param name="commands">The commands.</param>
        public static void Load(string[] commands)
        {
            Commands = commands;
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

                var arguments = command.Split(' ');

                switch (arguments[0])
                {
                    case "move":
                        ExecuteMove(arguments);
                        break;

                    case "buy":
                        Log.Notify("[Script] Purchasing items...");
                        ShoppingManager.Run(arguments[1]);
                        while (!ShoppingManager.Finished)
                            Thread.Sleep(50); //Wait until shopping is finished
                        break;

                    case "repair":
                        Log.Notify("[Script] Repairing items...");
                        ShoppingManager.RepairItems(arguments[1]);
                        break;

                    case "store":
                        ShoppingManager.StoreItems(arguments[1]);
                        Log.Notify("[Script] Storing items...");
                        break;

                    case "teleport":
                        Log.Notify("[Script] Teleporting...");
                        ExecuteTeleport(arguments);
                        break;

                    case "dismount":
                        Log.Notify("[Script] Dismounting vehicle...");
                        if (Game.Player.HasActiveVehicle)
                        {
                            Game.Player.Vehicle.Dismount();
                            Thread.Sleep(1000);
                        }
                        break;

                    case "wait":
                        var duration = Convert.ToInt32(arguments[1]);
                        Log.Notify($"[Script] Waiting for {duration}ms");
                        Thread.Sleep(duration);
                        break;

                    default:
                        Log.Notify($"Unknown script command [{arguments[0]}]");
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
        private static void ExecuteMove(IReadOnlyList<string> arguments)
        {
            var pos = new Position
            {
                XSector = byte.Parse(arguments[4]),
                YSector = byte.Parse(arguments[5]),
                XOffset = float.Parse(arguments[1]),
                YOffset = float.Parse(arguments[2]),
                ZOffset = float.Parse(arguments[3])
            };

            //Check if the new position is nearby a cave enterance.
            //If so dismount the vehicle
            if (Game.Player.HasActiveVehicle)
            {
                if (Game.ReferenceManager.GetGroundTeleporters(pos.RegionID).Select(teleporter => pos.DistanceTo(teleporter.GetPosition())).Any(distanceToTeleporter => !(distanceToTeleporter > 5)))
                    Game.Player.Vehicle.Dismount();
            }

            var distance = pos.DistanceTo(Game.Player.Movement.Source);
            if (distance > 100)
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
        private static void ExecuteTeleport(IReadOnlyList<string> arguments)
        {
            var npcCodeName = arguments[1];
            var destination = uint.Parse(arguments[2]);

            if (!SpawnManager.TryGetEntity<SpawnedPortal>(p => p.Record.CodeName == npcCodeName, out var entity))
            {
                Log.Debug("Could not find teleportation NPC " + npcCodeName);
                return;
            }

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