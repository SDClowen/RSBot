using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using System;
using System.Linq;

namespace RSBot.Alchemy.Bot
{
    internal class AttributeGranter
    {
        #region Members

        private bool _shouldRun;

        #endregion Members

        #region Constructor

        public AttributeGranter()
        {
            SubscribeEvents();
        }

        #endregion Constructor

        #region Methods

        public void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnAlchemySuccess", new Action<InventoryItem, InventoryItem, AlchemyType>(OnStoneAlchemySuccess));
            EventManager.SubscribeEvent("OnAlchemyFailed", new Action<InventoryItem, InventoryItem, AlchemyType>(OnStoneAlchemyFailed));
            EventManager.SubscribeEvent("OnAlchemyError", new Action<ushort, AlchemyType>(OnStoneAlchemyError));
            EventManager.SubscribeEvent("OnAlchemy", new Action<AlchemyType>(OnStoneAlchemy));
            EventManager.SubscribeEvent("OnFuseRequest", new Action<AlchemyAction, AlchemyType>(OnFuseRequest));
        }

        /// <summary>
        /// Runs the attribute granter using the specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public void Run(AttributesConfig config)
        {
            //Wait for the next tick to operate
            if (!_shouldRun)
                return;

            if (!config.Attributes.Any())
            {
                Log.Error("[Alchemy] No attribute stone fusion configured!");

                Kernel.Bot.Stop();

                return;
            }

            foreach (var attribute in config.Attributes)
            {
                var slot = ItemAttributesInfo.GetAttributeSlotForItem(attribute.Group, config.Item.Record);
                var currentValue = config.Item.Attributes.GetPercentage(slot);

                if (currentValue >= attribute.MaxValue && attribute.MaxValue > 0)
                    continue;

                AlchemyManager.FuseAttributeStone(config.Item, attribute.Stone);

                _shouldRun = false;
            }
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            _shouldRun = false;
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            _shouldRun = true;
        }

        #endregion Methods

        #region Events

        /// <summary>
        /// Will be triggered if any fuse request was sent to the server
        /// </summary>
        /// <param name="action"></param>
        /// <param name="type"></param>
        private void OnFuseRequest(AlchemyAction action, AlchemyType type)
        {
            if (type != AlchemyType.AttributeStone)
                return;

            Globals.View.AddLog(AlchemyManager.ActiveAlchemyItems?.First()?.Record.GetRealName(), "Fusing request...");
            _shouldRun = false;
        }

        /// <summary>
        /// Will be triggered if any stone alchemy action response was sent from the server
        /// </summary>
        private void OnStoneAlchemy(AlchemyType type)
        {
            if (type != AlchemyType.AttributeStone)
                return;

            Globals.View.AddLog(AlchemyManager.ActiveAlchemyItems?.First()?.Record.GetRealName(), "Fusing response...");

            _shouldRun = true;
        }

        /// <summary>
        /// Will be triggered if a stone alchemy operation was successful
        /// </summary>
        /// <param name="oldItem"></param>
        /// <param name="newItem">The new item after the successful action</param>
        /// <param name="type"></param>
        private void OnStoneAlchemySuccess(InventoryItem oldItem, InventoryItem newItem, AlchemyType type)
        {
            if (type != AlchemyType.AttributeStone)
                return;

            Globals.View.AddLog(AlchemyManager.ActiveAlchemyItems?.First()?.Record.GetRealName(), "Fusing response (success)...");

            _shouldRun = true;
        }

        /// <summary>
        /// Will be triggered if a stone alchemy action failed
        /// </summary>
        /// <param name="oldItem"></param>
        /// <param name="newItem">The new item after the operation failed</param>
        /// <param name="type"></param>
        private void OnStoneAlchemyFailed(InventoryItem oldItem, InventoryItem newItem, AlchemyType type)
        {
            if (type != AlchemyType.AttributeStone)
                return;

            Globals.View.AddLog(AlchemyManager.ActiveAlchemyItems?.First()?.Record.GetRealName(), "Fusing response (fail)...");
            _shouldRun = true;
        }

        /// <summary>
        /// Will be triggered if an stone alchemy error
        /// </summary>
        /// <param name="errorCode">The error code</param>
        /// <param name="type"></param>
        private void OnStoneAlchemyError(ushort errorCode, AlchemyType type)
        {
            if (type != AlchemyType.AttributeStone)
                return;

            Globals.View.AddLog(AlchemyManager.ActiveAlchemyItems?.First()?.Record.GetRealName(), "Fusing response (error)...");
            _shouldRun = true;
        }

        #endregion Events
    }
}