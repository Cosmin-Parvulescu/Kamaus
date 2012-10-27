using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

using AForge;
using AForge.Video;
using AForge.Video.DirectShow;

namespace Kamaus_CL
{
    public class WebcamController
    {
        private bool deviceExists = false;
        private VideoCaptureDevice videoSource = null;
        FilterInfoCollection videoDevices = null;

        public event EventHandler NewFrame;

        public WebcamController()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count == 0)
            {
                throw new Exception("No webcam detected!");
            }

            deviceExists = !deviceExists;
        }

        public void Start()
        {
            if (deviceExists)
            {
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.NewFrame += videoSource_NewFrame;
                videoSource.Start();
            }
        }

        void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            NewFrame(sender, eventArgs);
        }

        public void Stop()
        {
            if (videoSource != null)
            {
                if (videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource = null;
                }
            }
        }
    }
}
