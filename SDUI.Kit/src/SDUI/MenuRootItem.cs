﻿namespace SDUI
{
    internal class MenuRootItem : MenuItem
    {
        public Control Control { get; }

        public MenuRootItem (Control control) => Control = control;
    }
}
