using RSBot.Core.Event;
using RSBot.Core.Network;
using RSBot.Core.Objects.Spawn;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RSBot.Core.Components
{
    public static class SpawnManager
    {
        /// <summary>
        /// The locking object
        /// </summary>
        private static object _lock { get; } = new object();

        /// <summary>
        /// The game spawned entities on the area
        /// </summary>
        private static List<SpawnedEntity> Entities { get; set; } = new List<SpawnedEntity>(255);

        /// <summary>
        /// Try get an entity by the specified unique identifier.
        /// </summary>
        /// <param name="uniqueId">The searching uniqueId of the entity</param>
        /// <param name="removedEntity">Returning founded entity</param>
        /// <returns><c>true</c> if success; otherwise <c>false</c></returns>
        public static bool TryGetEntity(uint uniqueId, out SpawnedEntity entity)
        {
            entity = Entities.Find(p => p.UniqueId == uniqueId);
            return entity != null;
        }

        /// <summary>
        /// Try get entity by unique id with specified generic type.
        /// </summary>
        /// <param name="uniqueId">The unique identifier.</param>
        /// <returns><c>true</c> is succesfully found; otherwise <c>false</c></returns>
        public static bool TryGetEntity<T>(Func<T, bool> condition, out T entity)
            where T : SpawnedEntity
        {
            lock (_lock)
            {
                entity = TryGetEntity<T>(p => condition(p));

                return entity != null;
            }
        }

        /// <summary>
        /// Try get entity by unique id with specified generic type.
        /// </summary>
        /// <param name="uniqueId">The unique identifier.</param>
        /// <returns></returns>
        public static T TryGetEntity<T>(uint uniqueId)
            where T : SpawnedEntity
        {
            TryGetEntity<T>(uniqueId, out var entity);

            return entity;
        }

        /// <summary>
        /// Try get entity by unique id with specified generic type.
        /// </summary>
        /// <param name="uniqueId">The unique identifier.</param>
        /// <returns><c>true</c> is succesfully found; otherwise <c>false</c></returns>
        public static bool TryGetEntity<T>(uint uniqueId, out T entity)
            where T : SpawnedEntity
        {
            lock (_lock)
            {
                entity = TryGetEntity<T>(p => p.UniqueId == uniqueId);

                return entity != null;
            }
        }

        /// <summary>
        /// Try get entity by unique id with specified generic type.
        /// </summary>
        /// <param name="uniqueId">The unique identifier.</param>
        /// <returns><c>true</c> is succesfully found; otherwise <c>false</c></returns>
        public static T TryGetEntity<T>(Func<T, bool> condition)
            where T : SpawnedEntity
        {
            lock (_lock)
            {
                return Entities.FirstOrDefault(p => p is T && condition(p as T)) as T;
            }
        }

        /// <summary>
        /// Try get entities by conditions with specified generic type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities">The entities</param>
        /// <param name="predicate">The condition</param>
        /// <returns><c>true</c> if successfully found; otherwise <c>false</c></returns>
        public static bool TryGetEntities<T>(out IEnumerable<T> entities)
            where T : SpawnedEntity
        {
            lock (_lock)
            {
                entities = Entities.Where(p => p is T).Cast<T>();

                return entities != null;
            }
        }

        /// <summary>
        /// Try get entities by conditions with specified generic type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities">The entities</param>
        /// <param name="predicate">The condition</param>
        /// <returns><c>true</c> if successfully found; otherwise <c>false</c></returns>
        public static bool TryGetEntities<T>(out IEnumerable<T> entities, Func<T, bool> predicate)
            where T : SpawnedEntity
        {
            lock (_lock)
            {
                entities = Entities.Where(p => p is T && predicate(p as T)).Cast<T>();

                return entities != null;
            }
        }

        /// <summary>
        /// Try get entities by conditions with specified generic type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities">The entities</param>
        /// <param name="predicate">The condition</param>
        /// <returns><c>true</c> if successfully found; otherwise <c>false</c></returns>
        public static int Count<T>(Func<T, bool> predicate)
            where T : SpawnedEntity
        {
            lock (_lock)
            {
                return Entities.Count(p => p is T && predicate(p as T));
            }
        }

        /// <summary>
        /// Try get entities by conditions with specified generic type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities">The entities</param>
        /// <param name="predicate">The condition</param>
        /// <returns><c>true</c> if successfully found; otherwise <c>false</c></returns>
        public static bool Any<T>(Func<T, bool> predicate)
            where T : SpawnedEntity
        {
            lock (_lock)
            {
                return Entities.Any(p => p is T && predicate(p as T));
            }
        }

        /// <summary>
        /// Try remove an entity by the specified unique identifier.
        /// </summary>
        /// <param name="uniqueId">The removing uniqueId of the entity</param>
        /// <param name="removedEntity">Returning removed entity object</param>
        /// <returns><c>true</c> if success; otherwise <c>false</c></returns>
        public static bool TryRemove(uint uniqueId, out SpawnedEntity removedEntity)
        {
            lock (_lock)
            {
                removedEntity = Entities.Find(p => p.UniqueId == uniqueId);
                return Entities.Remove(removedEntity);
            }
        }


        /// <summary>
        /// Clears this instance.
        /// </summary>
        public static int Clear<T>()
        {
            lock (_lock)
            {
                return Entities.RemoveAll(p => p is T && p.Dispose());
            }
        }

        /// <summary>
        /// Parse the incoming spawn packet
        /// </summary>
        /// <param name="packet">The packet</param>
        public static void Parse(Packet packet, bool isGroup = false)
        {
            lock (_lock)
            {
                var refObjId = packet.ReadUInt();

                if (refObjId == uint.MaxValue)
                {
                    Entities.Add(SpawnedSpellArea.FromPacket(packet));
                    return;
                }

                var obj = Game.ReferenceManager.GetRefObjCommon(refObjId);

                switch (obj.TypeID1)
                {
                    case 1:

                        switch (obj.TypeID2)
                        {
                            case 1:
                                {
                                    var spawnedPlayer = new SpawnedPlayer(refObjId);
                                    spawnedPlayer.Deserialize(packet);

                                    Entities.Add(spawnedPlayer);
                                    EventManager.FireEvent("OnSpawnPlayer", spawnedPlayer);
                                }
                                break;

                            case 2:

                                switch (obj.TypeID3)
                                {
                                    case 1:
                                        {
                                            var spawnedMonster = new SpawnedMonster(refObjId);
                                            spawnedMonster.Deserialize(packet);

                                            Entities.Add(spawnedMonster);
                                            EventManager.FireEvent("OnSpawnMonster", spawnedMonster);
                                        }
                                        break;

                                    case 3:
                                        {
                                            var spawnedCos = new SpawnedCos(refObjId);
                                            spawnedCos.Deserialize(packet);
                                            Entities.Add(spawnedCos);
                                            EventManager.FireEvent("OnSpawnCos", spawnedCos);
                                        }
                                        break;

                                    case 5:
                                        {
                                            var spawnedFortressStructure = new SpawnedFortressStructure(refObjId);
                                            spawnedFortressStructure.Deserialize(packet);
                                            Entities.Add(spawnedFortressStructure);

                                            EventManager.FireEvent("OnSpawnFortressStructure", spawnedFortressStructure);
                                        }
                                        break;

                                    default:
                                        {
                                            var spawnedNpc = new SpawnedNpcNpc(refObjId);
                                            spawnedNpc.ParseBionicDetails(packet);
                                            spawnedNpc.Deserialize(packet);
                                            Entities.Add(spawnedNpc);
                                            EventManager.FireEvent("OnSpawnNpc", spawnedNpc);
                                        }
                                        break;
                                }

                                break;
                        }

                        break;

                    case 3:
                        var spawnedItem = SpawnedItem.FromPacket(packet, refObjId);
                        Entities.Add(spawnedItem);

                        EventManager.FireEvent("OnSpawnItem", spawnedItem);
                        break;

                    case 4:
                        var spawnedPortal = SpawnedPortal.FromPacket(packet, refObjId);
                        Entities.Add(spawnedPortal);
                        EventManager.FireEvent("OnSpawnPortal", spawnedPortal);
                        break;
                }

                if (!isGroup)
                {
                    if (obj.TypeID1 == 1 || obj.TypeID1 == 4)
                        packet.ReadByte(); //1 = Normal, 3 = Spawning, 4 = Running
                    else if (obj.TypeID1 == 3)
                    {
                        packet.ReadByte(); //DropSource
                        packet.ReadUInt(); //DropUID
                    }
                }
            }
        }

        /// <summary>
        /// Update the instance
        /// </summary>
        public static void Update()
        {
            foreach (var entity in Entities)
                entity.Update();
        }

        /// <summary>
        /// Clear this instance.
        /// </summary>
        public static void Clear()
        {
            lock (_lock)
            {
                //Entities.Clear();
                Entities = new List<SpawnedEntity>();
            }
        }
    }
}