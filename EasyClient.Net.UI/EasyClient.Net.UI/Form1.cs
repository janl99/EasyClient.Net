using EasyPlayer.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace EasyClient.Net.UI
{
    public partial class Form1 : Form
    {
       
        static int channelid = 0;
        public Form1()
        {
            InitializeComponent();
            
        }

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(
                  string lpClassName,
                  string lpWindowName
                 );

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopPlay(channelid);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text.Trim(); // "rtsp://192.168.2.11:554/stream0.sdp";
            if (string.IsNullOrEmpty(url)) 
            {
                MessageBox.Show("请先指定Url再播放.");
                return;
            }
            IntPtr hWnd = hWnd = FindWindow(null, this.Name);
            if (hWnd.Equals(IntPtr.Zero)) 
            {
                MessageBox.Show("未获取到句柄，无法播放.");
                return;
            }
            channelid = StartPlay(url,hWnd);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopPlay(channelid);
        }

        private static int StartPlay(string url, IntPtr hWnd)
        {
            return StartPlay(url, hWnd, callback);
        }

        static Int32 callback(int _channelId, IntPtr _channelPtr, int _frameType, [MarshalAs(UnmanagedType.LPArray)] byte[] pBuf, [MarshalAs(UnmanagedType.LPArray)] EasyPlayerManager.RTSP_FRAME_INFO[] _frameInfo) 
        {
            
            return 1;
        }

        private static int StartPlay(string url, IntPtr hWnd, EasyPlayerManager.MediaSourceCallBack callback)
        {
            int _r = -1;
            EasyPlayerManager.MediaSourceCallBack _callback = null;
            if (callback != null) { _callback = callback; }

            EasyPlayerManager.EasyPlayer_Init();
            _r = EasyPlayerManager.EasyPlayer_OpenStream(url, hWnd, EasyPlayerManager.RENDER_FORMAT.DISPLAY_FORMAT_RGB24_GDI, 1, "", "", _callback, IntPtr.Zero);
            if (_r > 0)
            {
                EasyPlayerManager.EasyPlayer_SetFrameCache(_r, 3);
                EasyPlayerManager.EasyPlayer_ShowStatisticalInfo(_r, 1);
                EasyPlayerManager.EasyPlayer_SetShownToScale(_r, 1);
                EasyPlayerManager.EasyPlayer_PlaySound(_r);
            }
            return _r;
        }

        private static void StopPlay(int _channelid)
        {
            if (_channelid > 0)
            {
                EasyPlayerManager.EasyPlayer_CloseStream(_channelid);
                EasyPlayerManager.EasyPlayer_Release();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

       
    }
}
