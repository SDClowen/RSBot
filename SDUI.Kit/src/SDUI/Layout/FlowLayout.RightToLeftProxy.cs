﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Drawing;

namespace SDUI.Layout;

internal partial class FlowLayout
{
    private class RightToLeftProxy : ContainerProxy
    {
        public RightToLeftProxy (IArrangedElement container) : base (container)
        {
        }

        public override Rectangle Bounds {
            set {
                // if the container is RTL, align to the left, otherwise, align to the right.
                // Do NOT use LayoutUtils.RTLTranslate as we want to preserve the padding.Right on the right...
                base.Bounds = RTLTranslateNoMarginSwap (value);
            }
        }
    }
}
