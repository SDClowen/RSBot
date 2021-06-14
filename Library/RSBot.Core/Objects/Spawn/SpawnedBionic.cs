using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Network;
using System.Timers;

namespace RSBot.Core.Objects.Spawn
{
    public class SpawnedBionic
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>
        /// The unique identifier.
        /// </value>
        public uint UniqueId;

        /// <summary>
        /// Gets or sets the tracker.
        /// </summary>
        /// <value>
        /// The tracker.
        /// </value>
        public PositionTracker Tracker;

        /// <summary>
        /// Gets or sets the model identifier.
        /// </summary>
        /// <value>
        /// The model identifier.
        /// </value>
        public uint ObjId { get; set; }

        /// <summary>
        /// Gets the record.
        /// </summary>
        /// <value>
        /// The record.
        /// </value>
        public RefObjChar Record => Game.ReferenceManager.GetRefObjChar(ObjId);

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public SpawnedBionicType Type { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public State State { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is behind obstacle.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is behind obstacle; otherwise, <c>false</c>.
        /// </value>
        public bool IsBehindObstacle => Tracker != null && CollisionManager.HasCollisionBetween(Tracker.Position, Game.Player.Tracker.Position);

        /// <summary>
        /// Gets a value indicating whether [attacking player].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [attacking player]; otherwise, <c>false</c>.
        /// </value>
        public bool AttackingPlayer { get; private set; }

        internal void ParseDetails(Packet packet)
        {
            UniqueId = packet.ReadUInt();

            var movement = Movement.FromPacket(packet);
            State = State.FromPacket(packet);

            if (Record.TypeID2 == 1)
            {
                Game.Spawns.Players[Game.Spawns.Players.Count - 1].ParseDetails(packet);
                EventManager.FireEvent("OnSpawnPlayer", Game.Spawns.GetPlayer(UniqueId));
            }
            if (Record.TypeID2 == 2)
            {
                var npc = SpawnedNpc.FromPacket(packet, this);
                if (Record.TypeID3 == 1)
                {
                    Game.Spawns.Monsters.Add(SpawnedMonster.FromPacket(packet, npc));
                    EventManager.FireEvent("OnSpawnMonster", Game.Spawns.GetMonster(UniqueId));
                }
                else if (Record.TypeID3 == 3)
                {
                    Game.Spawns.Cos.Add(SpawnedCos.FromPacket(packet, npc));
                    EventManager.FireEvent("OnSpawnCos", Game.Spawns.GetCos(UniqueId));
                }
                else if (Record.TypeID3 == 5)
                {
                    packet.ReadUInt(); //GuildId
                    packet.ReadString(); //Guild name
                }
                else
                    Game.Spawns.Npcs.Add(npc); //Unknown or unhandled type of NPC!
            }

            Tracker = new PositionTracker(movement);
            Tracker.SetSpeed(State.WalkSpeed, State.RunSpeed);
        }

        /// <summary>
        /// Starts the attacking timer.
        /// </summary>
        /// <param name="duration">The duration.</param>
        public void StartAttackingTimer(int duration = 10000)
        {
            //Log.Debug("Attacking timer has started.");

            AttackingPlayer = true;
            /*
            var timer = new Timer();
            timer.AutoReset = false;
            timer.Elapsed += Timer_Elapsed;*/
        }

        /// <summary>
        /// Handles the Elapsed event of the Timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Log.Debug("Attacking timer has elapsed.");
            AttackingPlayer = false;
        }
    }
}