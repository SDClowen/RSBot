using RSBot.Core.Objects.Spawn;
using System.Collections.Generic;
using System.Linq;

namespace RSBot.Core.Objects
{
    public class Spawns
    {
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public List<SpawnedItem> Items { get; set; }

        /// <summary>
        /// Gets or sets the players.
        /// </summary>
        /// <value>
        /// The players.
        /// </value>
        public List<SpawnedPlayer> Players { get; set; }

        /// <summary>
        /// </summary>
        /// <value>
        /// The NPCS.
        /// </value>
        public List<SpawnedNpc> Npcs { get; set; }

        /// <summary>
        /// Gets or sets the monsters.
        /// </summary>
        /// <value>
        /// The monsters.
        /// </value>
        public List<SpawnedMonster> Monsters { get; set; }

        /// <summary>
        /// Gets or sets the cos.
        /// </summary>
        /// <value>
        /// The cos.
        /// </value>
        public List<SpawnedCos> Cos { get; set; }

        /// <summary>
        /// Gets or sets the fortress structures.
        /// </summary>
        /// <value>
        /// The fortress structures.
        /// </value>
        public List<SpawnedFortressStructure> FortressStructures { get; set; }

        /// <summary>
        /// Gets or sets the portals.
        /// </summary>
        /// <value>
        /// The portals.
        /// </value>
        public List<SpawnedPortal> Portals { get; set; }

        /// <summary>
        /// Gets or sets the zones.
        /// </summary>
        /// <value>
        /// The zones.
        /// </value>
        public List<SpawnedSpellArea> SpellAreas { get; set; }

        private object _lock = new object();

        /// <summary>
        /// Returns a boolean indicating if the unique id exists
        /// </summary>
        /// <param name="uniqueId">The unique identifier.</param>
        /// <returns></returns>
        public bool UniqueIdExists(uint uniqueId)
        {
            lock (_lock)
            {
                //Search in items..
                var itemObj = Items.FirstOrDefault(item => item.UniqueId == uniqueId);
                if (itemObj != null)
                    return true;

                //search in players..
                var playerObj = Players.FirstOrDefault(player => player.Bionic.UniqueId == uniqueId);
                if (playerObj != null)
                    return true;

                //search in NPCs..
                var npcObj = Npcs.FirstOrDefault(npc => npc.Bionic.UniqueId == uniqueId);
                if (npcObj != null)
                    return true;

                //search in Mobs..
                var mobObj = Monsters.FirstOrDefault(npc => npc.Character.Bionic.UniqueId == uniqueId);
                if (mobObj != null)
                    return true;

                //search in Cos..
                var cosObj = Cos.FirstOrDefault(cos => cos.Character.Bionic.UniqueId == uniqueId);
                if (cosObj != null)
                    return true;

                //search in FortressStructures..
                var fortressStructureObj = FortressStructures.FirstOrDefault(fso => fso.Bionic.UniqueId == uniqueId);
                if (fortressStructureObj != null)
                    return true;

                //search in Portals..
                var portalObj = Portals.FirstOrDefault(portal => portal.UniqueId == uniqueId);
                if (portalObj != null)
                    return true;

                //search in SpellAreas..
                var eventObj = SpellAreas.FirstOrDefault(eventZone => eventZone.CasterUniqueId == uniqueId);
                return eventObj != null;
            }
        }

        /// <summary>
        /// Removes an entity by the specified unique identifier.
        /// </summary>
        /// <param name="uniqueId">The unique identifier.</param>
        public void Remove(uint uniqueId)
        {
            lock (_lock)
            {
                //Search in items..
                var itemObj = Items.FirstOrDefault(item => item.UniqueId == uniqueId);
                if (itemObj != null)
                {
                    Items.Remove(itemObj);
                    return;
                }

                //search in players..
                var playerObj = Players.FirstOrDefault(player => player.Bionic.UniqueId == uniqueId);
                if (playerObj != null)
                {
                    playerObj.Bionic.Tracker?.StopMoving();
                    Players.Remove(playerObj);
                    return;
                }

                //search in NPCs..
                var npcObj = Npcs.FirstOrDefault(npc => npc.Bionic.UniqueId == uniqueId);
                if (npcObj != null)
                {
                    npcObj.Bionic.Tracker?.StopMoving();
                    Npcs.Remove(npcObj);
                    return;
                }

                //search in NPCs..
                var mobObj = Monsters.FirstOrDefault(npc => npc.Character.Bionic.UniqueId == uniqueId);
                if (mobObj != null)
                {
                    mobObj.Character.Bionic.Tracker?.StopMoving();
                    Monsters.Remove(mobObj);
                    return;
                }

                //search in Cos..
                var cosObj = Cos.FirstOrDefault(cos => cos.Character.Bionic.UniqueId == uniqueId);
                if (cosObj != null)
                {
                    cosObj.Character.Bionic.Tracker?.StopMoving();
                    Cos.Remove(cosObj);
                    return;
                }

                //search in FortressStructures..
                var fortressStructureObj = FortressStructures.FirstOrDefault(fso => fso.Bionic.UniqueId == uniqueId);
                if (fortressStructureObj != null)
                {
                    FortressStructures.Remove(fortressStructureObj);
                    return;
                }

                //search in Portals..
                var portalObj = Portals.FirstOrDefault(portal => portal.UniqueId == uniqueId);
                if (portalObj != null)
                {
                    Portals.Remove(portalObj);
                    return;
                }

                //search in SpellAreas..
                var eventObj = SpellAreas.FirstOrDefault(eventZone => eventZone.CasterUniqueId == uniqueId);
                if (eventObj != null)
                {
                    SpellAreas.Remove(eventObj);
                }
            }
        }

        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <param name="uniqueId">The unique identifier.</param>
        /// <returns></returns>
        public SpawnedPlayer GetPlayer(uint uniqueId)
        {
            return GetPlayers().FirstOrDefault(player => player.Bionic.UniqueId == uniqueId);
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear()
        {
            Items.Clear();
            Players.Clear();
            Monsters.Clear();
            Npcs.Clear();
            Portals.Clear();
            SpellAreas.Clear();
            FortressStructures.Clear();
            Cos.Clear();
        }

        /// <summary>
        /// Gets the NPC by unique identifier.
        /// </summary>
        /// <param name="uniqueId">The unique identifier.</param>
        /// <returns></returns>
        public SpawnedNpc GetNpc(uint uniqueId)
        {
            return GetNpcs().FirstOrDefault(n => n.Bionic.UniqueId == uniqueId);
        }

        /// <summary>
        /// Gets the NPC by unique identifier.
        /// </summary>
        /// <param name="codeName">Name of the code.</param>
        /// <returns></returns>
        public SpawnedNpc GetNpc(string codeName)
        {
            return GetNpcs().FirstOrDefault(n => n.Bionic.Record.CodeName == codeName);
        }

        /// <summary>
        /// Gets the monster by unique identifier.
        /// </summary>
        /// <param name="uniqueId">The unique identifier.</param>
        /// <returns></returns>
        public SpawnedMonster GetMonster(uint uniqueId)
        {
            return GetMonsters().FirstOrDefault(n => n.Character.Bionic.UniqueId == uniqueId);
        }

        /// <summary>
        /// Gets the cos by unique identifier.
        /// </summary>
        /// <param name="uniqueId">The unique identifier.</param>
        /// <returns></returns>
        public SpawnedCos GetCos(uint uniqueId)
        {
            return GetCoses().FirstOrDefault(n => n.Character.Bionic.UniqueId == uniqueId);
        }

        /// <summary>
        /// Gets the portal by unique identifier.
        /// </summary>
        /// <param name="uniqueId">The unique identifier.</param>
        /// <returns></returns>
        public SpawnedPortal GetPortalByUniqueId(uint uniqueId)
        {
            return GetPortals().FirstOrDefault(p => p.UniqueId == uniqueId);
        }

        /// <summary>
        /// Gets the bionic by unique identifier.
        /// </summary>
        /// <param name="uniqueId">The unique identifier.</param>
        /// <returns></returns>
        public SpawnedBionic GetBionic(uint uniqueId)
        {
            lock (_lock)
            {
                //search in players..
                var playerObj = GetPlayers().FirstOrDefault(player => player != null && player.Bionic.UniqueId == uniqueId);
                if (playerObj != null)
                    return playerObj.Bionic;

                //search in Mobs..
                var mobObj = GetMonsters().FirstOrDefault(mob => mob != null && mob.Character.Bionic.UniqueId == uniqueId);
                if (mobObj != null)
                    return mobObj.Character.Bionic;

                //search in NPCs..
                var npcObj = GetNpcs().FirstOrDefault(npc => npc != null && npc.Bionic.UniqueId == uniqueId);
                if (npcObj != null)
                    return npcObj.Bionic;

                //search in Cos..
                var cosObj = GetCoses().FirstOrDefault(cos => cos != null && cos.Character.Bionic.UniqueId == uniqueId);
                if (cosObj != null)
                    return cosObj.Character.Bionic;

                //search in FortressStructures..
                var fortressStructureObj = GetFortressStructures().FirstOrDefault(fso => fso.Bionic.UniqueId == uniqueId);
                if (fortressStructureObj != null)
                    return fortressStructureObj.Bionic;

                return null;
            }
        }

        /// <summary>
        /// Gets a player by its name
        /// </summary>
        /// <param name="playerName">Name of the player.</param>
        /// <returns></returns>
        public SpawnedPlayer GetPlayerByName(string playerName)
        {
            return GetPlayers().FirstOrDefault(p => p.Name == playerName);
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <param name="uniqueId">The unique identifier.</param>
        /// <returns></returns>
        public SpawnedItem GetItem(uint uniqueId)
        {
            return GetItems().FirstOrDefault(i => i.UniqueId == uniqueId);
        }

        /// <summary>
        /// Gets the fortress structure.
        /// </summary>
        /// <param name="uniqueId">The unique identifier.</param>
        /// <returns></returns>
        public SpawnedFortressStructure GetFortressStructure(uint uniqueId)
        {
            return GetFortressStructures()?.FirstOrDefault(fs => fs.Bionic.UniqueId == uniqueId);
        }

        /// <summary>
        /// Gets the portal.
        /// </summary>
        /// <param name="uniqueId">The unique identifier.</param>
        /// <returns></returns>
        public SpawnedPortal GetPortal(uint uniqueId)
        {
            return GetPortals()?.FirstOrDefault(p => p.UniqueId == uniqueId);
        }

        /// <summary>
        /// Gets the portal.
        /// </summary>
        /// <param name="codeName">Name of the code.</param>
        /// <returns></returns>
        public SpawnedPortal GetPortal(string codeName)
        {
            return GetPortals()?.FirstOrDefault(p => p.Record.CodeName == codeName);
        }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <returns></returns>
        public List<SpawnedItem> GetItems()
        {
            lock (_lock)
                return Items.ToList();
        }

        /// <summary>
        /// Gets the players.
        /// </summary>
        /// <returns></returns>
        public List<SpawnedPlayer> GetPlayers()
        {
            lock (_lock)
                return Players.ToList();
        }

        /// <summary>
        /// Gets the NPCS.
        /// </summary>
        /// <returns></returns>
        public List<SpawnedNpc> GetNpcs()
        {
            lock (_lock)
                return Npcs.ToList();
        }

        /// <summary>
        /// Gets the portals.
        /// </summary>
        /// <returns></returns>
        public List<SpawnedPortal> GetPortals()
        {
            lock (_lock)
                return Portals.ToList();
        }

        /// <summary>
        /// Gets the fortress structures.
        /// </summary>
        /// <returns></returns>
        public List<SpawnedFortressStructure> GetFortressStructures()
        {
            lock (_lock)
                return FortressStructures.ToList();
        }

        /// <summary>
        /// Gets the coses.
        /// </summary>
        /// <returns></returns>
        public List<SpawnedCos> GetCoses()
        {
            lock (_lock)
                return Cos.ToList();
        }

        /// <summary>
        /// Gets the monsters.
        /// </summary>
        /// <returns></returns>
        public List<SpawnedMonster> GetMonsters()
        {
            lock (_lock)
                return Monsters.ToList();
        }

        /// <summary>
        /// Gets the spell areas.
        /// </summary>
        /// <returns></returns>
        public List<SpawnedSpellArea> GetSpellAreas()
        {
            lock (_lock)
                return SpellAreas.ToList();
        }
    }
}