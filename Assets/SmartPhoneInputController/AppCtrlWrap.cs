using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class AppCtrlWrap
{
    protected const uint BM_CLICK = 0x00F5;
    protected const uint WM_SETTEXT = 0x000C;

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static extern int GetWindowTextLength(IntPtr hWnd);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    protected static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, uint lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    protected static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, string lParam);

    protected class Info
    {
        public string name;
        public IntPtr handle;
    }

    protected List<Info> list;

    protected List<Info> GetAllHandle(string title)
    {
        IntPtr app = FindWindowEx(IntPtr.Zero, IntPtr.Zero, null, title);

        var handleList = new List<Info>();
        GetAllHandle(app, ref handleList);

        return handleList;
    }

    void GetAllHandle(IntPtr parent, ref List<Info> handleList)
    {
        foreach (Info info in GetChildHandle(parent))
        {
            handleList.Add(new Info() { name = info.name, handle = info.handle });
            GetAllHandle(info.handle, ref handleList);
        }
    }

    List<Info> GetChildHandle(IntPtr parent)
    {
        var handleList = new List<Info>();
        var child = IntPtr.Zero;
        while (true)
        {
            IntPtr handle = FindWindowEx(parent, child, null, null);
            if (handle == IntPtr.Zero) break;

            int length = GetWindowTextLength(handle);
            StringBuilder sb = new StringBuilder(length + 1);
            GetWindowText(handle, sb, sb.Capacity);

            handleList.Add(new Info() { name = sb.ToString(), handle = handle });
            child = handle;
        }
        return handleList;
    }

    protected IntPtr GetHandle(string name)
    {
        foreach (Info i in list)
        {
            if (i.name == name)
            {
                return i.handle;
            }
        }
        return IntPtr.Zero;
    }
}

public class VoiceroidCtrl : AppCtrlWrap
{
    const int edit = 9;

    public VoiceroidCtrl()
    {
        list = GetAllHandle("VOICEROID＋ 琴葉葵");
    }

    public void Send(string text)
    {
        SendMessage(list[edit].handle, WM_SETTEXT, 0, text);
    }

    public void Play()
    {
        SendMessage(GetHandle(" 再生"), BM_CLICK, 0, 0);
    }
    
[System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern System.IntPtr GetActiveWindow();
    
    public static System.IntPtr GetWindowHandle()
    {
        return GetActiveWindow();
    }

    //public void Wasd()
    //{
    //    System.Windows.Forms.SendKeys("w");
    //}
}
