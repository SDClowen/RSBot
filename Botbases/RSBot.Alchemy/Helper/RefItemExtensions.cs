using RSBot.Core.Client.ReferenceObjects;
using System.Linq;

namespace RSBot.Alchemy.Helper
{
    internal static class RefItemExtensions
    {
        public static bool IsArmor(this RefObjItem item)
        {
            return item != null && item.TypeID2 == 1 && (item.TypeID3 == 1 || item.TypeID3 == 2 || item.TypeID3 == 3 || item.TypeID3 == 9 || item.TypeID3 == 10 || item.TypeID3 == 11);
        }

        public static bool IsShield(this RefObjItem item)
        {

            return item != null && item.TypeID2 == 1 && item.TypeID3 == 4;
        }

        public static bool IsAccessory(this RefObjItem item)
        {
            return item != null && item.TypeID2 == 1 && (item.TypeID3 == 5 || item.TypeID3 == 12);
        }

        public static bool IsWeapon(this RefObjItem item)
        {
            return item != null && item.TypeID2 == 1 && (item.TypeID3 == 6);
        }
    }
}