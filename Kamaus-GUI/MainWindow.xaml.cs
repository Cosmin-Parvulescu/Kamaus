using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Drawing;

using Kamaus_CL;
using System.IO;
using System.Drawing.Imaging;
using System.Threading;

namespace Kamaus_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Kamaus_CL.MouseController mc = new MouseController();
        Kamaus_CL.WebcamController wc = new WebcamController();

        public MainWindow()
        {
            InitializeComponent();

            wc.NewFrame += wc_NewFrame;
            wc.Start();
        }

        void wc_NewFrame(object sender, EventArgs e)
        {
            AForge.Video.NewFrameEventArgs ev = (AForge.Video.NewFrameEventArgs)e;
            Bitmap image = (Bitmap)ev.Frame.Clone();

            image = Filters.ApplyFilters(image);

            AForge.Point mousePosition = BlobDetector.GetRedBlobCenter(image);
            if (BlobDetector.detected)
            {
                mc.MoveMouse(Convert.ToInt32(mousePosition.X), Convert.ToInt32(mousePosition.Y));
            }

            BitmapImage bImg = new BitmapImage();

            bImg.BeginInit();

            MemoryStream mStream = new MemoryStream();
            System.Drawing.Image cFrame = image;
            cFrame.Save(mStream, ImageFormat.Bmp);
            mStream.Seek(0, SeekOrigin.Begin);

            bImg.StreamSource = mStream;
            bImg.EndInit();
            bImg.Freeze();

            Dispatcher.BeginInvoke(new ThreadStart(delegate
                {
                    pictureBox.Source = bImg;
                }));
        }

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            wc.Stop();
        }
    }
}
