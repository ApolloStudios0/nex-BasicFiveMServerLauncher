using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using nex_FiveMServerLauncher.IServicers;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Net;

namespace nex_FiveMServerLauncher
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // [!] Initialize
            InitializeComponent();
            LoadServerLogs();
            ProgramBanner.Content = ServerDetailsConfig.ProgramTitle;
            IFiveMServicer fiveMServicer = new IFiveMServicer(ServerDetailsConfig.ServerIPandPort);

            // [!] Set Server Text & Details
            ServerName.Content = ServerDetailsConfig.ServerName;
            ServerDescriptionLabel.Content = fiveMServicer.ServerDescription;
            PlayerCountLabel.Content = $"View {fiveMServicer.ServerPlayerCount} Active Players";

            // [!] Get & Set Server Image
            var ServerImage = Image.FromStream(new MemoryStream(Convert.FromBase64String(fiveMServicer.IconUrl)));
            ImageBrush img = new ImageBrush() { ImageSource = BitmapToImageSource(ServerImage) };
            ServerPhoto.Fill = img;
            SecondaryServerPhoto.Fill = img;

            // [!] Bitmap Converter
            ImageSource BitmapToImageSource(Image serverImage)
            {
                BitmapImage bitmap = new BitmapImage();
                using (MemoryStream memory = new MemoryStream())
                {
                    serverImage.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                    memory.Position = 0;
                    bitmap.BeginInit();
                    bitmap.StreamSource = memory;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();
                }
                return bitmap;
            }

            // [!] Get Playerlist
            PlayerListView.ItemsSource = fiveMServicer.SB.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            // [!] Set Other Dynamic Variables
            WhatToDisplayLogs.Content = ServerDetailsConfig.WhatTitleToDisplayForLogs;
        }

        public void LoadServerLogs()
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    string ServerLogs = wc.DownloadString(ServerDetailsConfig.RawTextSourceURL);

                    // Split Each NewLine
                    string[] SplitLogs = ServerLogs.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                    // Show In Listview
                    ServerLogsListView.ItemsSource = SplitLogs;
                }
            }
            catch { MessageBox.Show("URL Provided Is Invalid"); }
        }

        /// <summary>
        /// Delegate All Buttons From Mainwindow UI
        /// </summary>
        private void MoveForm(object sender, MouseButtonEventArgs e) { this.DragMove(); }
        private void ButtonDelegator(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button btn = sender as System.Windows.Controls.Button;

            switch (btn.Content)
            {
                case "X": Application.Current.Shutdown(); break;

                case "-":
                    // minimize
                    WindowState = WindowState.Minimized;
                    break;

                case "Join":
                    Process.Start(ServerDetailsConfig.DiscordServerJoinUrl);
                    break;

                case "View":
                    Process.Start(ServerDetailsConfig.WebsiteURL);
                    break;

                case "Connect":
                    Process.Start($"https://cfx.re/join/{ServerDetailsConfig.ServerConnectionID}");
                    break;
            }
        }
    }
}
