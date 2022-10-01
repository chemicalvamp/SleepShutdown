using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;


namespace SleepShutdown
{
    public partial class Form1 : Form
    {
        string watchDirectory = "";
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        DateTime lastActivity;
        DateTime shutdownTime;
        double activityThreshold = 1.00;
        FileSystemWatcher fsw;
        string commandArg = "shutdown /s";

        private UserInput input;

        public Form1(String[] args)
        {
            InitializeComponent();
            double timer;
            try
            {
                double.TryParse(args[0], out timer);
                if (timer > 0)
                    activityThreshold = timer;
                if (args[1] != null)
                    watchDirectory = args[1];
            }
            catch { }
            anyActivity(this, new EventArgs());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            input = new UserInput();
            input.KeyBoardKeyPressed += anyActivity;
            input.MouseMoved += anyActivity;

            if (watchDirectory != "")
            {
                fsw = new FileSystemWatcher(Environment.ExpandEnvironmentVariables(watchDirectory));
                directoryLabel.Text = watchDirectory;
                fsw.Changed += new FileSystemEventHandler(anyActivity);
                fsw.Created += new FileSystemEventHandler(anyActivity);
                fsw.Deleted += new FileSystemEventHandler(anyActivity);
                fsw.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                fsw.IncludeSubdirectories = true;
                fsw.EnableRaisingEvents = true;
            }
            else
            {
                fsw = new FileSystemWatcher(Environment.ExpandEnvironmentVariables(baseDirectory));
                directoryLabel.Text = baseDirectory;
                fsw.Changed += new FileSystemEventHandler(anyActivity);
                fsw.Created += new FileSystemEventHandler(anyActivity);
                fsw.Deleted += new FileSystemEventHandler(anyActivity);
                fsw.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                fsw.IncludeSubdirectories = true;
                fsw.EnableRaisingEvents = true;
            }
        }

        private void anyActivity(object sender, FileSystemEventArgs e) // Filesystem activity
        {
            lastActivity = DateTime.Now;
            shutdownTime = lastActivity.AddHours(activityThreshold);
        }

        void anyActivity(object sender, EventArgs e) // UserInput activity
        {
            lastActivity = DateTime.Now;
            shutdownTime = lastActivity.AddHours(activityThreshold);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            fsw.Dispose();
            input.Dispose();
        }

        private void formUpdate_Tick(object sender, EventArgs e)
        {
            activityTime.Text = lastActivity.ToLongTimeString();
            TimeSpan temp1 = TimeSpan.FromSeconds((shutdownTime - DateTime.Now).TotalSeconds);
            TimeSpan temp2 = new TimeSpan(temp1.Hours, temp1.Minutes, temp1.Seconds);
            shutdownLabel.Text = temp2.ToString();

            if (DateTime.Compare(shutdownTime, DateTime.Now) <= 0)
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();

                startInfo.WorkingDirectory = @"C:\Windows\System32";
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/user:Administrator \"cmd /C " + commandArg + "\"";
                startInfo.CreateNoWindow = false;
                startInfo.ErrorDialog = false;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardError = true;
                startInfo.RedirectStandardOutput = true;
                process.StartInfo = startInfo;
                process.Start();
            }
        }
    }

    public class UserInput : IDisposable
    {
        public event EventHandler<EventArgs> KeyBoardKeyPressed;
        public event EventHandler<EventArgs> MouseMoved;

        public delegate IntPtr HookDelegate(int Code, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr hHook, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll")]
        public static extern IntPtr UnhookWindowsHookEx(IntPtr hHook);

        [DllImport("User32.dll")]
        public static extern IntPtr SetWindowsHookEx(int idHook, HookDelegate lpfn, IntPtr hmod, int dwThreadId);

        private HookDelegate keyBoardDelegate;
        private HookDelegate mouseDelegate;
        private IntPtr keyBoardHandle;
        private IntPtr mouseHandle;
        private const int WH_KEYBOARD_LL = 13; // Global only
        private const int WH_MOUSE_LL = 14; // Global only
        private bool disposed;

        public UserInput()
        {
            keyBoardDelegate = KeyboardHookDelegate;
            mouseDelegate = MouseHookDelegate;
            keyBoardHandle = SetWindowsHookEx(WH_KEYBOARD_LL, keyBoardDelegate, IntPtr.Zero, 0);
            mouseHandle = SetWindowsHookEx(WH_MOUSE_LL, mouseDelegate, IntPtr.Zero, 0);
        }

        private IntPtr KeyboardHookDelegate(int Code, IntPtr wParam, IntPtr lParam)
        {
            if (Code < 0)
                return CallNextHookEx(keyBoardHandle, Code, wParam, lParam);

            if (KeyBoardKeyPressed != null)
                KeyBoardKeyPressed(this, new EventArgs());

            return CallNextHookEx(keyBoardHandle, Code, wParam, lParam);
        }

        private IntPtr MouseHookDelegate(int Code, IntPtr wParam, IntPtr lParam)
        {
            if (Code < 0)
                return CallNextHookEx(mouseHandle, Code, wParam, lParam);

            if (MouseMoved != null)
                MouseMoved(this, new EventArgs());

            return CallNextHookEx(mouseHandle, Code, wParam, lParam);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (mouseHandle != IntPtr.Zero)
                    UnhookWindowsHookEx(mouseHandle);
                if (keyBoardHandle != IntPtr.Zero)
                    UnhookWindowsHookEx(keyBoardHandle);
                disposed = true;
            }
        }

        ~UserInput()
        {
            Dispose(false);
        }
    }
}
