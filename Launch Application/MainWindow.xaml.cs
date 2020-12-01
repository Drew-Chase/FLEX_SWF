using ChaseLabs.Games.SWF.STDLib.Global;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace Launch_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.NotifyIcon NotifyIcon;
        //bool IsRunning = false;
        Process application = null;

        public MainWindow()
        {
            InitializeComponent();

            SystemTray();
            RegisterEvent();

            LaunchApplication();
        }

        void RegisterEvent()
        {
            NotifyIcon.MouseDoubleClick += ((object sender, System.Windows.Forms.MouseEventArgs e) => { OpenSite(); });


            AppDomain.CurrentDomain.ProcessExit += ((object sender, EventArgs e) =>
            {
                NotifyIcon.Visible = false;
                if (application != null && !application.HasExited) application.Kill();
            });

            //Window Events
            StateChanged += ((object sender, EventArgs e) =>
            {
                ShowInTaskbar = false;
                NotifyIcon.BalloonTipTitle = "Flex";
                NotifyIcon.BalloonTipText = "Flex Server has Started at http://127.0.0.1:5050";
                NotifyIcon.ShowBalloonTip(400);
                NotifyIcon.Visible = true;
            });


            ShowInTaskbar = false;
            NotifyIcon.BalloonTipTitle = "Flex";
            NotifyIcon.BalloonTipText = "Flex Server has Started at http://127.0.0.1:5050";
            NotifyIcon.ShowBalloonTip(400);
            NotifyIcon.Visible = true;

            WindowState = WindowState.Maximized;
            long now = DateTime.Now.Ticks, wanted = DateTime.Now.AddSeconds(5).Ticks;
            while (now < wanted) { now = DateTime.Now.Ticks; }
            //WindowState = WindowState.Minimized;
            WindowState = WindowState.Normal;
        }

        private void SystemTray()
        {
            NotifyIcon = new System.Windows.Forms.NotifyIcon
            {
                Icon = System.Drawing.Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location)
            };
            contextMenu = new System.Windows.Forms.ContextMenuStrip();
            contextMenu.Items.Add("Open", null, new EventHandler((object sender, EventArgs args) => { OpenSite(); }));
            contextMenu.Items.Add("Restart", null, new EventHandler((object sender, EventArgs args) => RestartApplication()));
            contextMenu.Items.Add("Exit", null, new EventHandler((object sender, EventArgs args) => { Close(); }));
            NotifyIcon.ContextMenuStrip = contextMenu;
        }

        void LaunchApplication()
        {
            if (application != null && !application.HasExited)
                application.Kill();
            application = new Process() { StartInfo = new ProcessStartInfo() { FileName = "netcoreapp3.1/flex service.exe", UseShellExecute = false, CreateNoWindow = false } };
            application.Start();
            //IsRunning = true;
            //application.Exited += ((object sender, EventArgs e) => { IsRunning = false; });
        }

        void RestartApplication()
        {
            if (application != null)
                application.Kill();
            LaunchApplication();
        }

        void OpenSite()
        {
            //if (!IsRunning) return;
            new Process() { StartInfo = new ProcessStartInfo() { FileName = $"http://127.0.0.1:5050 " } }.Start();
        }
    }
}
