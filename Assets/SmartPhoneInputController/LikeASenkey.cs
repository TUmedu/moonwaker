using System;
using System.Runtime.InteropServices;
//using UnityEditor;
using UnityEngine;

public class LikeASenkey : MonoBehaviour {
    // using System.Runtime.InteropServices;

    [DllImport("user32.dll")]
    private static extern IntPtr GetDesktopWindow();
    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    [DllImport("user32.dll")]
    private static extern int VkKeyScan(char ch);

    // デスクトップのウインドウハンドル取得
    IntPtr hwnd = GetDesktopWindow();
   
    // Use this for initialization
    void Start () {
		System.Windows.Forms.SendKeys.SendWait("s");
	}
	
	// Update is called once per frame
	void Update () {
        // メモ帳のウインドウハンドル取得
        //hwnd = FindWindowEx(hwnd, IntPtr.Zero, "notepad", null);
        // メモ帳ウインドウ内の「edit」ウインドウのハンドル取得
        //hwnd = FindWindowEx(hwnd, IntPtr.Zero, "edit", null);

        // 「edit」ウインドウに「aab」を送信
        //PostMessage(hwnd, 0x0100, VkKeyScan('a'), 0);
        //PostMessage(hwnd, 0x0100, 0x41, 0);
        //PostMessage(hwnd, 0x0100, 0x42, 0);

        //アクティブウィンドウをスクリーンキャプチャする場合
        //System.Windows.Forms.SendKeys.SendWait("%{PRTSC}");
        // 3秒待つ
        System.Threading.Thread.Sleep(3000);
        System.Windows.Forms.SendKeys.SendWait("w");

        //EditorWindow.focusedWindow.SendEvent(Event.KeyboardEvent("x"));
        //EditorWindow.focusedWindow.SendEvent(Event.KeyboardEvent("y"));
        //EditorWindow.focusedWindow.SendEvent(Event.KeyboardEvent("z"));

    }
}
