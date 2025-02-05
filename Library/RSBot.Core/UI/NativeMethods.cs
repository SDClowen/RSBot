using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Windows.Forms;

namespace SDUI;

public class NativeMethods
{
    public const int DWMSBT_MAINWINDOW = 2; // Mica
    public const int DWMSBT_TRANSIENTWINDOW = 3; // Acrylic
    public const int DWMSBT_TABBEDWINDOW = 4; // Tabbed

    private const string user32 = "user32.dll";
    private const string gdi32 = "gdi32.dll";
    private const string uxtheme = "uxtheme.dll";
    private const string dwmapi = "dwmapi.dll";

    public const int WM_NOTIFY = 0x004E;
    public const int WM_NCLBUTTONDOWN = 0xA1;
    public const int HT_CAPTION = 0x2;
    public const int CS_DROPSHADOW = 0x00020000;
    public const int WS_MINIMIZEBOX = 0x20000;
    public const int WS_SIZEBOX = 0x00040000;
    public const int WS_SYSMENU = 0x00080000;
    public const int CS_DBLCLKS = 0x8;
    public const int WM_NCPAINT = 0x0085;
    public const int WM_PAINT = 0x000F;
    public const int WM_ERASEBKGND = 0x0014;
    public const int WM_NCHITTEST = 0x84;
    public const int WM_NCCALCSIZE = 0x0083;
    public const int WM_SYSCOMMAND = 0x0112;
    public const int SC_MOVE = 0xF010;
    public const int HTCAPTION = 0x2;
    public const int HTCLIENT = 0x1;
    public const int LVCDI_ITEM = 0x0;
    public const int LVCDI_GROUP = 0x1;
    public const int LVCDI_ITEMSLIST = 0x2;
    public const int LVM_FIRST = 0x1000;
    public const int LVM_GETHEADER = LVM_FIRST + 31;
    public const int LVM_SETITEMSTATE = LVM_FIRST + 43;
    public const int LVM_GETGROUPRECT = LVM_FIRST + 98;
    public const int LVM_ENABLEGROUPVIEW = LVM_FIRST + 157;
    public const int LVM_SETGROUPINFO = LVM_FIRST + 147;
    public const int LVM_GETGROUPINFO = LVM_FIRST + 149;
    public const int LVM_REMOVEGROUP = LVM_FIRST + 150;
    public const int LVM_MOVEGROUP = LVM_FIRST + 151;
    public const int LVM_GETGROUPCOUNT = LVM_FIRST + 152;
    public const int LVM_GETGROUPINFOBYINDEX = LVM_FIRST + 153;
    public const int LVM_MOVEITEMTOGROUP = LVM_FIRST + 154;
    public const int WM_LBUTTONUP = 0x202;

    public const int LVGF_NONE = 0x0;
    public const int LVGF_HEADER = 0x1;
    public const int LVGF_FOOTER = 0x2;
    public const int LVGF_STATE = 0x4;
    public const int LVGF_ALIGN = 0x8;
    public const int LVGF_GROUPID = 0x10;
    public const int LVGF_SUBTITLE = 0x100; // pszSubtitle is valid
    public const int LVGF_TASK = 0x200; // pszTask is valid
    public const int LVGF_DESCRIPTIONTOP = 0x400; // pszDescriptionTop is valid
    public const int LVGF_DESCRIPTIONBOTTOM = 0x800; // pszDescriptionBottom is valid
    public const int LVGF_TITLEIMAGE = 0x1000; // iTitleImage is valid
    public const int LVGF_EXTENDEDIMAGE = 0x2000; // iExtendedImage is valid
    public const int LVGF_ITEMS = 0x4000; // iFirstItem and cItems are valid
    public const int LVGF_SUBSET = 0x8000; // pszSubsetTitle is valid
    public const int LVGF_SUBSETITEMS = 0x10000; // readonly, cItems holds count of items in visible subset, iFirstItem is valid
    public const int LVGS_NORMAL = 0x0;
    public const int LVGS_COLLAPSED = 0x1;
    public const int LVGS_HIDDEN = 0x2;
    public const int LVGS_NOHEADER = 0x4;
    public const int LVGS_COLLAPSIBLE = 0x8;
    public const int LVGS_FOCUSED = 0x10;
    public const int LVGS_SELECTED = 0x20;
    public const int LVGS_SUBSETED = 0x40;
    public const int LVGS_SUBSETLINKFOCUSED = 0x80;
    public const int LVGA_HEADER_LEFT = 0x1;
    public const int LVGA_HEADER_CENTER = 0x2;
    public const int LVGA_HEADER_RIGHT = 0x4; // Don't forget to validate exclusivity
    public const int LVGA_FOOTER_LEFT = 0x8;
    public const int LVGA_FOOTER_CENTER = 0x10;
    public const int LVGA_FOOTER_RIGHT = 0x20; // Don't forget to validate exclusivity
    public const int LVGGR_GROUP = 0; // Entire expanded group
    public const int LVGGR_HEADER = 1;  // Header only (collapsed group)
    public const int LVGGR_LABEL = 2;  // Label only
    public const int LVGGR_SUBSETLINK = 3;  // subset link only
    public const int LVS_EX_DOUBLEBUFFER = 0x10000;
    public const int LVM_SETEXTENDEDLISTVIEWSTYLE = 4150;

    public const int NM_FIRST = 0;
    public const int NM_CLICK = NM_FIRST - 2;
    public const int NM_CUSTOMDRAW = NM_FIRST - 12;
    public const int WM_REFLECT = 0x2000;
    public const int WM_NOFITY = 0x4E;
    public const int WM_KILLFOCUS = 0x8;
    public const int WM_VSCROLL = 0x115;
    public const int WM_HSCROLL = 0x114;
    public const int WM_THEMECHANGED = 0x031A;
    public const int HDM_FIRST = 0x1200;
    public const int HDM_GETITEM = HDM_FIRST + 11;
    public const int HDM_SETITEM = HDM_FIRST + 12;
    public const int TCM_FIRST = 4864;
    public const int TCM_ADJUSTRECT = TCM_FIRST + 40;
    public const int TCS_MULTILINE = 0x0200;

    public struct MARGINS                           // struct for box shadow
    {
        public int Left;
        public int Right;
        public int Top;
        public int Bottom;
    }

    public struct SubclassInfo
    {
        public COLORREF headerTextColor;
    };

    [DllImport("kernel32", EntryPoint = "RtlMoveMemory", SetLastError = false)]
    public static extern void MoveMemory(IntPtr Destination, IntPtr Source, IntPtr Length);

    [DllImport("gdi32.dll", SetLastError = true, ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
    [ResourceExposure(ResourceScope.None)]
    public static extern int CombineRgn(IntPtr hRgn, IntPtr hRgn1, IntPtr hRgn2, int nCombineMode);

    [DllImport("user32.dll")]
    public static extern IntPtr GetWindowDC(IntPtr hWnd);

    [DllImport("gdi32.dll")]
    public static extern bool FillRgn(IntPtr hdc, IntPtr hrgn, IntPtr hbr);

    [DllImport("gdi32.dll")]
    public static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

    [DllImport("gdi32.dll")]
    public static extern IntPtr CreateSolidBrush(uint crColor);


    [DllImport("user32.dll")]
    public static extern IntPtr GetDCEx(IntPtr hwnd, IntPtr hrgnclip, uint fdwOptions);
    
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SetRect(Rect rect, int w, int h, int x, int y);

    [DllImport(gdi32)]
    public static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pvd, [In] ref uint pcFonts);

    [DllImport(uxtheme, CharSet = CharSet.Unicode, EntryPoint = "OpenThemeData")]
    public static extern IntPtr OpenThemeData(IntPtr hWnd, string classList);

    [DllImport(uxtheme, EntryPoint = "CloseThemeData")]
    public extern static Int32 CloseThemeData(IntPtr hTheme);

    [DllImport(uxtheme, EntryPoint = "GetThemeColor")]
    public extern static Int32 GetThemeColor(IntPtr hTheme, int iPartId, int iStateId, int iPropId, out COLORREF pColor);

    [DllImport(gdi32)]
    public static extern uint SetTextColor(IntPtr hdc, COLORREF crColor);

    [DllImport(user32)]
    public static extern bool ReleaseCapture();

    [DllImport(user32, SetLastError = true)]
    public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

    [DllImport(user32, SetLastError = true)]
    public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

    [DllImport(user32, SetLastError = true)]
    public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, ref HDITEM lParam);

    [DllImport(user32, SetLastError = true)]
    public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, ref COLORREF lParam);

    [DllImport(user32, SetLastError = true)]
    public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, ref Rect lParam);

    [DllImport(user32)]
    public static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, int flags);

    [DllImport(dwmapi)]
    public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

    [DllImport(dwmapi, CharSet = CharSet.Unicode, PreserveSig = false)]
    public static extern int DwmSetWindowAttribute(IntPtr hwnd, DWMWINDOWATTRIBUTE dwAttribute, ref DWM_WINDOW_CORNER_PREFERENCE pvAttribute, int cbAttribute);

    [DllImport(dwmapi)]
    public static extern int DwmSetWindowAttribute(IntPtr hwnd, DWMWINDOWATTRIBUTE dwAttribute, ref int pvAttribute, int cbAttribute);

    [DllImport(dwmapi)]
    public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool InvalidateRect(IntPtr hWnd, Rect rect, bool bErase);

    [DllImport("user32.dll")]
    public static extern bool GetClientRect(IntPtr hWnd, ref Rect rect);


    [DllImport(uxtheme, ExactSpelling = true)]
    public extern static int DrawThemeParentBackground(IntPtr hWnd, IntPtr hdc, ref System.Drawing.Rectangle pRect);

    [DllImport(user32, EntryPoint = "SendMessageW", SetLastError = true)]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, ref LVGROUP lParam);

    [DllImport(user32, EntryPoint = "SendMessageW", SetLastError = true)]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, ref Rect lParam);

    [DllImport(user32, EntryPoint = "PostMessageW", SetLastError = true)]
    public static extern int PostMessage(IntPtr hWnd, int Msg, int wParam, ref IntPtr lParam);

    [DllImport(uxtheme, CharSet = CharSet.Unicode, SetLastError = true)]
    public extern static int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

    [DllImport(uxtheme, EntryPoint = "#133", SetLastError = true)]
    internal static extern bool AllowDarkModeForWindow(IntPtr window, bool isDarkModeAllowed);

    [DllImport(user32, EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessageLVItem(IntPtr hWnd, int msg, int wParam, ref LVITEM lvi);

    [DllImport(user32, CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, string lParam);

    [DllImport(user32, SetLastError = true)]
    public static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

    [DllImport(user32, SetLastError = true)]
    public static extern IntPtr SetCursor(IntPtr hCursor);

    [DllImport(user32, SetLastError = true)]
    public static extern IntPtr LoadImage(IntPtr hinst, string lpszName, uint uType, int cxDesired, int cyDesired, uint fuLoad);

    [DllImport(user32, SetLastError = true)]
    public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);

    [DllImport(user32, EntryPoint = "SetWindowLong", SetLastError = true)]
    public static extern int SetWindowLong32(IntPtr hWnd, int nIndex, int dwNewLong);

    [DllImport(user32, EntryPoint = "SetWindowLongPtr", SetLastError = true)]
    public static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

    [DllImport(user32)]
    public static extern bool SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

    [SecurityCritical]
    [DllImport("ntdll.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern NTSTATUS RtlGetVersion(ref OSVERSIONINFOEX versionInfo);

    [DllImport(user32)]
    public static extern IntPtr GetDC(IntPtr hwnd);

    /// <summary>
    /// The SaveDC function saves the current state of the specified device context (DC) by copying data describing selected objects and graphic modes
    /// </summary>
    /// <param name="hdc"></param>
    /// <returns></returns>
    [DllImport("gdi32.dll")]
    internal static extern int SaveDC(IntPtr hdc);

    [DllImport(user32)]
    public static extern IntPtr ReleaseDC(IntPtr hwnd, IntPtr hdc);

    private delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);
    [DllImport(user32)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);

    public delegate IntPtr SUBCLASSPROC(
            IntPtr hWnd,
            int msg,
            IntPtr wParam,
            IntPtr lParam,
            UIntPtr uIdSubclass,
            UIntPtr dwRefData
        );

    [DllImport("comctl32.dll", ExactSpelling = true)]
    public static extern bool SetWindowSubclass(
        IntPtr hWnd,
        IntPtr pfnSubclass,
        UIntPtr uIdSubclass,
        UIntPtr dwRefData
    );

    [DllImport("comctl32.dll", ExactSpelling = true)]
    public static extern bool RemoveWindowSubclass(
        IntPtr hWnd,
        IntPtr pfnSubclass,
        UIntPtr uIdSubclass
    );

    [DllImport("comctl32.dll", ExactSpelling = true)]
    public static extern IntPtr DefSubclassProc(
        IntPtr hWnd,
        int msg,
        IntPtr wParam,
        IntPtr lParam
    );

    /// <summary>
    /// The CreateDIBSection function creates a DIB that applications can write to directly.
    /// </summary>
    /// <param name="hdc"></param>
    /// <param name="pbmi"></param>
    /// <param name="iUsage"></param>
    /// <param name="ppvBits"></param>
    /// <param name="hSection"></param>
    /// <param name="dwOffset"></param>
    /// <returns></returns>
    [DllImport("gdi32.dll")]
    private static extern IntPtr CreateDIBSection(IntPtr hdc, ref BITMAPINFO pbmi, uint iUsage, IntPtr ppvBits, IntPtr hSection, uint dwOffset);

    /// <summary>
    /// This function transfers pixels from a specified source rectangle to a specified destination rectangle, altering the pixels according to the selected raster operation (ROP) code.
    /// </summary>
    /// <param name="hdc"></param>
    /// <param name="nXDest"></param>
    /// <param name="nYDest"></param>
    /// <param name="nWidth"></param>
    /// <param name="nHeight"></param>
    /// <param name="hdcSrc"></param>
    /// <param name="nXSrc"></param>
    /// <param name="nYSrc"></param>
    /// <param name="dwRop"></param>
    /// <returns></returns>
    [DllImport("gdi32.dll")]
    internal static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);

    /// <summary>
    /// This function selects an object into a specified device context. The new object replaces the previous object of the same type.
    /// </summary>
    /// <param name="hDC"></param>
    /// <param name="hObject"></param>
    /// <returns></returns>
    [DllImport("gdi32.dll")]
    internal static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

    /// <summary>
    /// The DeleteObject function deletes a logical pen, brush, font, bitmap, region, or palette, freeing all system resources associated with the object. After the object is deleted, the specified handle is no longer valid.
    /// </summary>
    /// <param name="hObject"></param>
    /// <returns></returns>
    [DllImport("gdi32.dll")]
    internal static extern bool DeleteObject(IntPtr hObject);

    /// <summary>
    /// This function creates a memory device context (DC) compatible with the specified device.
    /// </summary>
    /// <param name="hDC"></param>
    /// <returns></returns>
    [DllImport("gdi32.dll")]
    internal static extern IntPtr CreateCompatibleDC(IntPtr hDC);

    /// <summary>
    /// The DeleteDC function deletes the specified device context (DC).
    /// </summary>
    /// <param name="hdc"></param>
    /// <returns></returns>
    [DllImport("gdi32.dll")]
    internal static extern bool DeleteDC(IntPtr hdc);

    internal const int WM_PRINT = 0x0317;

    [Flags]
    internal enum DrawingOptions
    {
        PRF_CHECKVISIBLE = 0x01,
        PRF_NONCLIENT = 0x02,
        PRF_CLIENT = 0x04,
        PRF_ERASEBKGND = 0x08,
        PRF_CHILDREN = 0x10,
        PRF_OWNED = 0x20
    }

    public static void TakeScreenshot(IntPtr hwnd, Graphics g)
    {
        IntPtr hdc = IntPtr.Zero;
        try
        {
            hdc = g.GetHdc();

            SendMessage(hwnd, WM_PRINT, hdc,
                new IntPtr((int)(
                    DrawingOptions.PRF_CHILDREN |
                    DrawingOptions.PRF_CLIENT |
                    DrawingOptions.PRF_NONCLIENT |
                    DrawingOptions.PRF_OWNED
                    ))
                );
        }
        finally
        {
            if (hdc != IntPtr.Zero)
                g.ReleaseHdc(hdc);
        }
    }

    private static bool EnumWindow(IntPtr handle, IntPtr pointer)
    {
        GCHandle gch = GCHandle.FromIntPtr(pointer);
        List<IntPtr> list = gch.Target as List<IntPtr>;
        if (list == null)
            throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
        list.Add(handle);
        return true;
    }

    public static void DisableVisualStylesForFirstChild(IntPtr parent)
    {
        List<IntPtr> children = new List<IntPtr>();
        GCHandle listHandle = GCHandle.Alloc(children);
        try
        {
            EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
            EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
            if (children.Count > 0)
                SetWindowTheme(children[0], "", "");
        }
        finally
        {
            if (listHandle.IsAllocated)
                listHandle.Free();
        }
    }

    public static void EnableAcrylic(IWin32Window window, Color blurColor)
    {
        if (window is null) throw new ArgumentNullException(nameof(window));

        var accentPolicy = new AccentPolicy
        {
            AccentState = ACCENT.ENABLE_ACRYLICBLURBEHIND,
            GradientColor = blurColor.ToArgb()
        };
        var accentSize = Marshal.SizeOf(accentPolicy);
        var accentPolicyPtr = Marshal.AllocHGlobal(accentSize);
        Marshal.StructureToPtr(accentPolicy, accentPolicyPtr, false);

        var data = new WindowCompositionAttributeData
        {
            Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY,
            Data = accentPolicyPtr,
            SizeOfData = Marshal.SizeOf<AccentPolicy>()
        };

        SetWindowCompositionAttribute(
            window.Handle,
            ref data);
    }
    
    /// <summary>
     /// Fills an area for glass rendering
     /// </summary>
     /// <param name="g"></param>
     /// <param name="r"></param>
    public static void FillForGlass(Graphics g, Rectangle r)
    {
        var rc = new Rect
        {
            Left = r.Left,
            Right = r.Right,
            Top = r.Top,
            Bottom = r.Bottom
        };

        IntPtr destdc = g.GetHdc();    //hwnd must be the handle of form,not control
        IntPtr Memdc = CreateCompatibleDC(destdc);
        IntPtr bitmap;
        IntPtr bitmapOld = IntPtr.Zero;

        var dib = new BITMAPINFO();
        dib.bmiHeader.biHeight = -(rc.Bottom - rc.Top);
        dib.bmiHeader.biWidth = rc.Right - rc.Left;
        dib.bmiHeader.biPlanes = 1;
        dib.bmiHeader.biSize = Marshal.SizeOf(typeof(BITMAPINFOHEADER));
        dib.bmiHeader.biBitCount = 32;
        dib.bmiHeader.biCompression = BI_RGB;
        if (!(SaveDC(Memdc) == 0))
        {
            bitmap = CreateDIBSection(Memdc, ref dib, DIB_RGB_COLORS, (IntPtr)0, IntPtr.Zero, 0);
            if (!(bitmap == IntPtr.Zero))
            {
                bitmapOld = SelectObject(Memdc, bitmap);
                BitBlt(destdc, rc.Left, rc.Top, rc.Right - rc.Left, rc.Bottom - rc.Top, Memdc, 0, 0, SRCCOPY);

            }

            //Remember to clean up
            SelectObject(Memdc, bitmapOld);

            DeleteObject(bitmap);

            ReleaseDC(Memdc, (IntPtr)(-1));
            DeleteDC(Memdc);


        }
        g.ReleaseHdc();

    }

    [Flags]
    public enum WindowLongIndexFlags : int
    {
        GWL_EXSTYLE = -20,
        GWLP_HINSTANCE = -6,
        GWLP_HWNDPARENT = -8,
        GWL_ID = -12,
        GWLP_ID = GWL_ID,
        GWL_STYLE = -16,
        GWL_USERDATA = -21,
        GWLP_USERDATA = GWL_USERDATA,
        GWL_WNDPROC = -4,
        GWLP_WNDPROC = GWL_WNDPROC,
        DWLP_USER = 0x8,
        DWLP_MSGRESULT = 0x0,
        DWLP_DLGPROC = 0x4,
    }

    public delegate IntPtr dWndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

    [DllImport(user32)]
    public static extern IntPtr GetWindowLong(IntPtr hWnd, WindowLongIndexFlags nIndex);

    [DllImport(user32)]
    public static extern IntPtr SetWindowLong(IntPtr hWnd, WindowLongIndexFlags nIndex, SetWindowLongFlags newProc);

    public enum SetWindowPosFlags : uint
    {
        /// <summary>
        ///     If the calling thread and the thread that owns the window are attached to different input queues, the system posts the request to the thread that owns the window. This prevents the calling thread from blocking its execution while other threads process the request.
        /// </summary>
        SWP_ASYNCWINDOWPOS = 0x4000,

        /// <summary>
        ///     Prevents generation of the WM_SYNCPAINT message.
        /// </summary>
        SWP_DEFERERASE = 0x2000,

        /// <summary>
        ///     Draws a frame (defined in the window's class description) around the window.
        /// </summary>
        SWP_DRAWFRAME = 0x0020,

        /// <summary>
        ///     Applies new frame styles set using the SetWindowLong function. Sends a WM_NCCALCSIZE message to the window, even if the window's size is not being changed. If this flag is not specified, WM_NCCALCSIZE is sent only when the window's size is being changed.
        /// </summary>
        SWP_FRAMECHANGED = 0x0020,

        /// <summary>
        ///     Hides the window.
        /// </summary>
        SWP_HIDEWINDOW = 0x0080,

        /// <summary>
        ///     Does not activate the window. If this flag is not set, the window is activated and moved to the top of either the topmost or non-topmost group (depending on the setting of the hWndInsertAfter parameter).
        /// </summary>
        SWP_NOACTIVATE = 0x0010,

        /// <summary>
        ///     Discards the entire contents of the client area. If this flag is not specified, the valid contents of the client area are saved and copied back into the client area after the window is sized or repositioned.
        /// </summary>
        SWP_NOCOPYBITS = 0x0100,

        /// <summary>
        ///     Retains the current position (ignores X and Y parameters).
        /// </summary>
        SWP_NOMOVE = 0x0002,

        /// <summary>
        ///     Does not change the owner window's position in the Z order.
        /// </summary>
        SWP_NOOWNERZORDER = 0x0200,

        /// <summary>
        ///     Does not redraw changes. If this flag is set, no repainting of any kind occurs. This applies to the client area, the nonclient area (including the title bar and scroll bars), and any part of the parent window uncovered as a result of the window being moved. When this flag is set, the application must explicitly invalidate or redraw any parts of the window and parent window that need redrawing.
        /// </summary>
        SWP_NOREDRAW = 0x0008,

        /// <summary>
        ///     Same as the SWP_NOOWNERZORDER flag.
        /// </summary>
        SWP_NOREPOSITION = 0x0200,

        /// <summary>
        ///     Prevents the window from receiving the WM_WINDOWPOSCHANGING message.
        /// </summary>
        SWP_NOSENDCHANGING = 0x0400,

        /// <summary>
        ///     Retains the current size (ignores the cx and cy parameters).
        /// </summary>
        SWP_NOSIZE = 0x0001,

        /// <summary>
        ///     Retains the current Z order (ignores the hWndInsertAfter parameter).
        /// </summary>
        SWP_NOZORDER = 0x0004,

        /// <summary>
        ///     Displays the window.
        /// </summary>
        SWP_SHOWWINDOW = 0x0040,
    }

    [Flags]
    public enum SetWindowLongFlags : uint
    {
        WS_OVERLAPPED = 0,
        WS_POPUP = 0x80000000,
        WS_CHILD = 0x40000000,
        WS_MINIMIZE = 0x20000000,
        WS_VISIBLE = 0x10000000,
        WS_DISABLED = 0x8000000,
        WS_CLIPSIBLINGS = 0x4000000,
        WS_CLIPCHILDREN = 0x2000000,
        WS_MAXIMIZE = 0x1000000,
        WS_CAPTION = 0xC00000,
        WS_BORDER = 0x800000,
        WS_DLGFRAME = 0x400000,
        WS_VSCROLL = 0x200000,
        WS_HSCROLL = 0x100000,
        WS_SYSMENU = 0x80000,
        WS_THICKFRAME = 0x40000,
        WS_GROUP = 0x20000,
        WS_TABSTOP = 0x10000,
        WS_MINIMIZEBOX = 0x20000,
        WS_MAXIMIZEBOX = 0x10000,
        WS_TILED = WS_OVERLAPPED,
        WS_ICONIC = WS_MINIMIZE,
        WS_SIZEBOX = WS_THICKFRAME,

        WS_EX_DLGMODALFRAME = 0x0001,
        WS_EX_NOPARENTNOTIFY = 0x0004,
        WS_EX_TOPMOST = 0x0008,
        WS_EX_ACCEPTFILES = 0x0010,
        WS_EX_TRANSPARENT = 0x0020,
        WS_EX_MDICHILD = 0x0040,
        WS_EX_TOOLWINDOW = 0x0080,
        WS_EX_WINDOWEDGE = 0x0100,
        WS_EX_CLIENTEDGE = 0x0200,
        WS_EX_CONTEXTHELP = 0x0400,
        WS_EX_RIGHT = 0x1000,
        WS_EX_LEFT = 0x0000,
        WS_EX_RTLREADING = 0x2000,
        WS_EX_LTRREADING = 0x0000,
        WS_EX_LEFTSCROLLBAR = 0x4000,
        WS_EX_RIGHTSCROLLBAR = 0x0000,
        WS_EX_CONTROLPARENT = 0x10000,
        WS_EX_STATICEDGE = 0x20000,
        WS_EX_APPWINDOW = 0x40000,
        WS_EX_OVERLAPPEDWINDOW = WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE,
        WS_EX_PALETTEWINDOW = WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST,
        WS_EX_LAYERED = 0x00080000,
        WS_EX_NOINHERITLAYOUT = 0x00100000,
        WS_EX_LAYOUTRTL = 0x00400000,
        WS_EX_COMPOSITED = 0x02000000,
        WS_EX_NOACTIVATE = 0x08000000,
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct COLORREF
    {
        public byte R;
        public byte G;
        public byte B;
    }

    public enum ACCENT
    {
        DISABLED = 0,
        ENABLE_GRADIENT = 1,
        ENABLE_TRANSPARENTGRADIENT = 2,
        ENABLE_BLURBEHIND = 3,
        ENABLE_ACRYLICBLURBEHIND = 4,
        INVALID_STATE = 5
    }


    public struct AccentPolicy
    {
        public ACCENT AccentState;
        public uint AccentFlags;
        public int GradientColor;
        public uint AnimationId;
    }

    public enum NTSTATUS : uint
    {
        /// <summary>
        /// The operation completed successfully. 
        /// </summary>
        STATUS_SUCCESS = 0x00000000
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct OSVERSIONINFOEX
    {
        // The OSVersionInfoSize field must be set to Marshal.SizeOf(typeof(OSVERSIONINFOEX))
        public int OSVersionInfoSize;
        public int MajorVersion;
        public int MinorVersion;
        public int BuildNumber;
        public int PlatformId;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string CSDVersion;
        public ushort ServicePackMajor;
        public ushort ServicePackMinor;
        public ushort SuiteMask;
        public byte ProductType;
        public byte Reserved;
    }

    public unsafe struct WindowCompositionAttributeData
    {
        public WindowCompositionAttribute Attribute;
        public IntPtr Data;
        public int SizeOfData;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct LVITEM
    {
        public int mask;
        public int iItem;
        public int iSubItem;
        public int state;
        public int stateMask;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pszText;
        public int cchTextMax;
        public int iImage;
        public IntPtr lParam;
        public int iIndent;
        public int iGroupId;
        public int cColumns;
        public IntPtr puColumns;
    };

    [StructLayout(LayoutKind.Sequential)]
    public partial struct NMHDR
    {
        public IntPtr hwndFrom;
        public IntPtr idFrom;
        public int code;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;

        public Rect(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public int X
        {
            get => Left;
            set
            {
                Right -= Left - value;
                Left = value;
            }
        }

        public int Y
        {
            get => Top;
            set
            {
                Bottom -= Top - value;
                Top = value;
            }
        }

        public int Height
        {
            get => Bottom - Top;
            set => Bottom = value + Top;
        }

        public int Width
        {
            get => Right - Left;
            set => Right = value + Left;
        }

    }

    // The DWM_WINDOW_CORNER_PREFERENCE enum for DwmSetWindowAttribute's third parameter, which tells the function
    // what value of the enum to set.
    // Copied from dwmapi.h
    public enum DWM_WINDOW_CORNER_PREFERENCE : int
    {
        DWMWCP_DEFAULT = 0,
        DWMWCP_DONOTROUND = 1,
        DWMWCP_ROUND = 2,
        DWMWCP_ROUNDSMALL = 3
    }

    [StructLayout(LayoutKind.Sequential)]
    public partial struct NMCUSTOMDRAW
    {
        public NMHDR hdr;
        public int dwDrawStage;
        public IntPtr hdc;
        public Rect rc;
        public IntPtr dwItemSpec;
        public uint uItemState;
        public IntPtr lItemlParam;
    }

    [StructLayout(LayoutKind.Sequential)]
    public partial struct NMLVCUSTOMDRAW
    {
        public NMCUSTOMDRAW nmcd;
        public int clrText;
        public int clrTextBk;
        public int iSubItem;
        public int dwItemType;
        public int clrFace;
        public int iIconEffect;
        public int iIconPhase;
        public int iPartId;
        public int iStateId;
        public Rect rcText;
        public uint uAlign;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public partial struct LVGROUP
    {
        public uint cbSize;
        public uint mask;
        public IntPtr pszHeader;
        public int cchHeader;
        public IntPtr pszFooter;
        public int cchFooter;
        public int iGroupId;
        public uint stateMask;
        public uint state;
        public uint uAlign;
        public IntPtr pszSubtitle;
        public uint cchSubtitle;
        public IntPtr pszTask;
        public uint cchTask;
        public IntPtr pszDescriptionTop;
        public uint cchDescriptionTop;
        public IntPtr pszDescriptionBottom;
        public uint cchDescriptionBottom;
        public int iTitleImage;
        public int iExtendedImage;
        public int iFirstItem;
        public uint cItems;
        public IntPtr pszSubsetTitle;
        public uint cchSubsetTitle;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWPOS
    {
        public IntPtr HWND;
        public IntPtr hwndAfter;
        public int x;
        public int y;
        public int cx;
        public int cy;
        public SetWindowPosFlags flags;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HDITEM
    {
        public Mask mask;
        public int cxy;
        [MarshalAs(UnmanagedType.LPTStr)] public string pszText;
        public IntPtr hbm;
        public int cchTextMax;
        public Format fmt;
        public IntPtr lParam;
        // _WIN32_IE >= 0x0300 
        public int iImage;
        public int iOrder;
        // _WIN32_IE >= 0x0500
        public uint type;
        public IntPtr pvFilter;
        // _WIN32_WINNT >= 0x0600
        public uint state;

        [Flags]
        public enum Mask
        {
            Format = 0x4,       // HDI_FORMAT
        };

        [Flags]
        public enum Format
        {
            SortDown = 0x200,   // HDF_SORTDOWN
            SortUp = 0x400,     // HDF_SORTUP
        };
    };


    [Flags]
    public enum CDRF
    {
        CDRF_DODEFAULT = 0x0,
        CDRF_NEWFONT = 0x2,
        CDRF_SKIPDEFAULT = 0x4,
        CDRF_DOERASE = 0x8,
        CDRF_SKIPPOSTPAINT = 0x100,
        CDRF_NOTIFYPOSTPAINT = 0x10,
        CDRF_NOTIFYITEMDRAW = 0x20,
        CDRF_NOTIFYSUBITEMDRAW = 0x20,
        CDRF_NOTIFYPOSTERASE = 0x40
    }

    [Flags]
    public enum CDDS
    {
        CDDS_PREPAINT = 0x1,
        CDDS_POSTPAINT = 0x2,
        CDDS_PREERASE = 0x3,
        CDDS_POSTERASE = 0x4,
        CDDS_ITEM = 0x10000,
        CDDS_ITEMPREPAINT = CDDS_ITEM | CDDS_PREPAINT,
        CDDS_ITEMPOSTPAINT = CDDS_ITEM | CDDS_POSTPAINT,
        CDDS_ITEMPREERASE = CDDS_ITEM | CDDS_PREERASE,
        CDDS_ITEMPOSTERASE = CDDS_ITEM | CDDS_POSTERASE,
        CDDS_SUBITEMField = 0x20000
    }

    public enum WindowCompositionAttribute
    {
        WCA_UNDEFINED = 0,
        WCA_NCRENDERING_ENABLED = 1,
        WCA_NCRENDERING_POLICY = 2,
        WCA_TRANSITIONS_FORCEDISABLED = 3,
        WCA_ALLOW_NCPAINT = 4,
        WCA_CAPTION_BUTTON_BOUNDS = 5,
        WCA_NONCLIENT_RTL_LAYOUT = 6,
        WCA_FORCE_ICONIC_REPRESENTATION = 7,
        WCA_EXTENDED_FRAME_BOUNDS = 8,
        WCA_HAS_ICONIC_BITMAP = 9,
        WCA_THEME_ATTRIBUTES = 10,
        WCA_NCRENDERING_EXILED = 11,
        WCA_NCADORNMENTINFO = 12,
        WCA_EXCLUDED_FROM_LIVEPREVIEW = 13,
        WCA_VIDEO_OVERLAY_ACTIVE = 14,
        WCA_FORCE_ACTIVEWINDOW_APPEARANCE = 15,
        WCA_DISALLOW_PEEK = 16,
        WCA_CLOAK = 17,
        WCA_CLOAKED = 18,
        WCA_ACCENT_POLICY = 19,
        WCA_FREEZE_REPRESENTATION = 20,
        WCA_EVER_UNCLOAKED = 21,
        WCA_VISUAL_OWNER = 22,
        WCA_HOLOGRAPHIC = 23,
        WCA_EXCLUDED_FROM_DDA = 24,
        WCA_PASSIVEUPDATEMODE = 25,
        WCA_USEDARKMODECOLORS = 26,
        WCA_LAST = 27
    };

    [Flags]
    public enum DWMWINDOWATTRIBUTE : uint
    {
        /// <summary>
        /// Use with DwmGetWindowAttribute. Discovers whether non-client rendering is enabled. The retrieved value is of type BOOL. TRUE if non-client rendering is enabled; otherwise, FALSE.
        /// </summary>
        DWMWA_NCRENDERING_ENABLED = 1,

        /// <summary>
        /// Use with DwmSetWindowAttribute. Sets the non-client rendering policy. The pvAttribute parameter points to a value from the DWMNCRENDERINGPOLICY enumeration.
        /// </summary>
        DWMWA_NCRENDERING_POLICY,

        /// <summary>
        /// Use with DwmSetWindowAttribute. Enables or forcibly disables DWM transitions. The pvAttribute parameter points to a value of type BOOL. TRUE to disable transitions, or FALSE to enable transitions.
        /// </summary>
        DWMWA_TRANSITIONS_FORCEDISABLED,

        /// <summary>
        /// Use with DwmSetWindowAttribute. Enables content rendered in the non-client area to be visible on the frame drawn by DWM. The pvAttribute parameter points to a value of type BOOL. TRUE to enable content rendered in the non-client area to be visible on the frame; otherwise, FALSE.
        /// </summary>
        DWMWA_ALLOW_NCPAINT,

        /// <summary>
        /// Use with DwmGetWindowAttribute. Retrieves the bounds of the caption button area in the window-relative space. The retrieved value is of type RECT. If the window is minimized or otherwise not visible to the user, then the value of the RECT retrieved is undefined. You should check whether the retrieved RECT contains a boundary that you can work with, and if it doesn't then you can conclude that the window is minimized or otherwise not visible.
        /// </summary>
        DWMWA_CAPTION_BUTTON_BOUNDS,

        /// <summary>
        /// Use with DwmSetWindowAttribute. Specifies whether non-client content is right-to-left (RTL) mirrored. The pvAttribute parameter points to a value of type BOOL. TRUE if the non-client content is right-to-left (RTL) mirrored; otherwise, FALSE.
        /// </summary>
        DWMWA_NONCLIENT_RTL_LAYOUT,

        /// <summary>
        /// Use with DwmSetWindowAttribute. Forces the window to display an iconic thumbnail or peek representation (a static bitmap), even if a live or snapshot representation of the window is available. This value is normally set during a window's creation, and not changed throughout the window's lifetime. Some scenarios, however, might require the value to change over time. The pvAttribute parameter points to a value of type BOOL. TRUE to require a iconic thumbnail or peek representation; otherwise, FALSE.
        /// </summary>
        DWMWA_FORCE_ICONIC_REPRESENTATION,

        /// <summary>
        /// Use with DwmSetWindowAttribute. Sets how Flip3D treats the window. The pvAttribute parameter points to a value from the DWMFLIP3DWINDOWPOLICY enumeration.
        /// </summary>
        DWMWA_FLIP3D_POLICY,

        /// <summary>
        /// Use with DwmGetWindowAttribute. Retrieves the extended frame bounds rectangle in screen space. The retrieved value is of type RECT.
        /// </summary>
        DWMWA_EXTENDED_FRAME_BOUNDS,

        /// <summary>
        /// Use with DwmSetWindowAttribute. The window will provide a bitmap for use by DWM as an iconic thumbnail or peek representation (a static bitmap) for the window. DWMWA_HAS_ICONIC_BITMAP can be specified with DWMWA_FORCE_ICONIC_REPRESENTATION. DWMWA_HAS_ICONIC_BITMAP normally is set during a window's creation and not changed throughout the window's lifetime. Some scenarios, however, might require the value to change over time. The pvAttribute parameter points to a value of type BOOL. TRUE to inform DWM that the window will provide an iconic thumbnail or peek representation; otherwise, FALSE. Windows Vista and earlier: This value is not supported.
        /// </summary>
        DWMWA_HAS_ICONIC_BITMAP,

        /// <summary>
        /// Use with DwmSetWindowAttribute. Do not show peek preview for the window. The peek view shows a full-sized preview of the window when the mouse hovers over the window's thumbnail in the taskbar. If this attribute is set, hovering the mouse pointer over the window's thumbnail dismisses peek (in case another window in the group has a peek preview showing). The pvAttribute parameter points to a value of type BOOL. TRUE to prevent peek functionality, or FALSE to allow it. Windows Vista and earlier: This value is not supported.
        /// </summary>
        DWMWA_DISALLOW_PEEK,

        /// <summary>
        /// Use with DwmSetWindowAttribute. Prevents a window from fading to a glass sheet when peek is invoked. The pvAttribute parameter points to a value of type BOOL. TRUE to prevent the window from fading during another window's peek, or FALSE for normal behavior. Windows Vista and earlier: This value is not supported.
        /// </summary>
        DWMWA_EXCLUDED_FROM_PEEK,

        /// <summary>
        /// Use with DwmSetWindowAttribute. Cloaks the window such that it is not visible to the user. The window is still composed by DWM. Using with DirectComposition: Use the DWMWA_CLOAK flag to cloak the layered child window when animating a representation of the window's content via a DirectComposition visual that has been associated with the layered child window. For more details on this usage case, see How to animate the bitmap of a layered child window. Windows 7 and earlier: This value is not supported.
        /// </summary>
        DWMWA_CLOAK,

        /// <summary>
        /// Use with DwmGetWindowAttribute. If the window is cloaked, provides one of the following values explaining why. DWM_CLOAKED_APP (value 0x0000001). The window was cloaked by its owner application. DWM_CLOAKED_SHELL(value 0x0000002). The window was cloaked by the Shell. DWM_CLOAKED_INHERITED(value 0x0000004). The cloak value was inherited from its owner window. Windows 7 and earlier: This value is not supported.
        /// </summary>
        DWMWA_CLOAKED,

        /// <summary>
        /// Use with DwmSetWindowAttribute. Freeze the window's thumbnail image with its current visuals. Do no further live updates on the thumbnail image to match the window's contents. Windows 7 and earlier: This value is not supported.
        /// </summary>
        DWMWA_FREEZE_REPRESENTATION,

        /// <summary>
        /// Use with DwmSetWindowAttribute. Enables a non-UWP window to use host backdrop brushes. If this flag is set, then a Win32 app that calls Windows::UI::Composition APIs can build transparency effects using the host backdrop brush (see Compositor.CreateHostBackdropBrush). The pvAttribute parameter points to a value of type BOOL. TRUE to enable host backdrop brushes for the window, or FALSE to disable it. This value is supported starting with Windows 11 Build 22000.
        /// </summary>
        DWMWA_USE_HOSTBACKDROPBRUSH,

        /// <summary>
        /// Use with DwmSetWindowAttribute. Allows the window frame for this window to be drawn in dark mode colors when the dark mode system setting is enabled. For compatibility reasons, all windows default to light mode regardless of the system setting. The pvAttribute parameter points to a value of type BOOL. TRUE to honor dark mode for the window, FALSE to always use light mode. This value is supported starting with Windows 10 Build 17763.
        /// </summary>
        DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19,

        /// <summary>
        /// Use with DwmSetWindowAttribute. Allows the window frame for this window to be drawn in dark mode colors when the dark mode system setting is enabled. For compatibility reasons, all windows default to light mode regardless of the system setting. The pvAttribute parameter points to a value of type BOOL. TRUE to honor dark mode for the window, FALSE to always use light mode. This value is supported starting with Windows 11 Build 22000.
        /// </summary>
        DWMWA_USE_IMMERSIVE_DARK_MODE = 20,

        /// <summary>
        /// Use with DwmSetWindowAttribute. Specifies the rounded corner preference for a window. The pvAttribute parameter points to a value of type DWM_WINDOW_CORNER_PREFERENCE. This value is supported starting with Windows 11 Build 22000.
        /// </summary>
        DWMWA_WINDOW_CORNER_PREFERENCE = 33,

        /// <summary>
        /// Use with DwmSetWindowAttribute. Specifies the color of the window border. The pvAttribute parameter points to a value of type COLORREF. The app is responsible for changing the border color according to state changes, such as a change in window activation. This value is supported starting with Windows 11 Build 22000.
        /// </summary>
        DWMWA_BORDER_COLOR,

        /// <summary>
        /// Use with DwmSetWindowAttribute. Specifies the color of the caption. The pvAttribute parameter points to a value of type COLORREF. This value is supported starting with Windows 11 Build 22000.
        /// </summary>
        DWMWA_CAPTION_COLOR,

        /// <summary>
        /// Use with DwmSetWindowAttribute. Specifies the color of the caption text. The pvAttribute parameter points to a value of type COLORREF. This value is supported starting with Windows 11 Build 22000.
        /// </summary>
        DWMWA_TEXT_COLOR,

        /// <summary>
        /// Use with DwmGetWindowAttribute. Retrieves the width of the outer border that the DWM would draw around this window. The value can vary depending on the DPI of the window. The pvAttribute parameter points to a value of type UINT. This value is supported starting with Windows 11 Build 22000.
        /// </summary>
        DWMWA_VISIBLE_FRAME_BORDER_THICKNESS,

        /// <summary>
        /// The maximum recognized DWMWINDOWATTRIBUTE value, used for validation purposes.
        /// </summary>
        DWMWA_SYSTEMBACKDROP_TYPE,
    }

    /// <summary>
    /// An uncompressed format.
    /// </summary>
    private const int BI_RGB = 0;

    /// <summary>
    /// The BITMAPINFO structure contains an array of literal RGB values.
    /// </summary>
    public const int DIB_RGB_COLORS = 0;

    /// <summary>
    /// Copies the source rectangle directly to the destination rectangle.
    /// </summary>
    public const int SRCCOPY = 0x00CC0020;

    /// <summary>
    /// This structure contains information about the dimensions and color format of a device-independent bitmap (DIB).
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    private struct BITMAPINFOHEADER
    {
        public int biSize;
        public int biWidth;
        public int biHeight;
        public short biPlanes;
        public short biBitCount;
        public int biCompression;
        public readonly int biSizeImage;
        public readonly int biXPelsPerMeter;
        public readonly int biYPelsPerMeter;
        public readonly int biClrUsed;
        public readonly int biClrImportant;
    }

    /// <summary>
    /// This structure describes a color consisting of relative intensities of red, green, and blue.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    private struct RGBQUAD
    {
        public readonly byte rgbBlue;
        public readonly byte rgbGreen;
        public readonly byte rgbRed;
        public readonly byte rgbReserved;
    }
    /// <summary>
    /// This structure defines the dimensions and color information of a Windows-based device-independent bitmap (DIB).
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    private struct BITMAPINFO
    {
        public BITMAPINFOHEADER bmiHeader;
        public readonly RGBQUAD bmiColors;
    }
}