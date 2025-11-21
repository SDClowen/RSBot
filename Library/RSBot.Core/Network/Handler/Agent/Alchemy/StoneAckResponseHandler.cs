using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Components;

namespace RSBot.Core.Network.Handler.Agent.Alchemy;

internal class StoneAckResponseHandler : IPacketHandler
{
    #region Methods

    public void Invoke(Packet packet)
    {
        var type = AlchemyType.MagicStone;

        if (AlchemyManager.ActiveAlchemyItems != null && AlchemyManager.ActiveAlchemyItems.Count >= 2)
        {
            var stone = AlchemyManager.ActiveAlchemyItems[1].Record;
            if (stone.TypeID3 == 11 && stone.TypeID4 == 2)
                type = AlchemyType.AttributeStone;
        }

        GenericAlchemyAckResponse.Invoke(packet, type);
    }

    #endregion Methods

    #region Properties

    public ushort Opcode => 0xB151;

    public PacketDestination Destination => PacketDestination.Client;

    #endregion Properties
}
