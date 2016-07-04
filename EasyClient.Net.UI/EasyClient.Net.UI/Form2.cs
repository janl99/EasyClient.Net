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
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }



        Int32 callback(ref EasyClientManager.CAMERA_LIST_T  _VedioDeviceInfoList)
        {
            IntPtr pinfo = _VedioDeviceInfoList.pCamera;

            while (pinfo != IntPtr.Zero) 
            {
                EasyClientManager.CAMERA_INFO_T  _t = (EasyClientManager.CAMERA_INFO_T)Marshal.PtrToStructure(_VedioDeviceInfoList.pCamera, typeof(EasyClientManager.CAMERA_INFO_T));
                comboBox1.Items.Add(_t.friendlyName);
                pinfo = _t.pNext;
            }

            return 1;
        }

        public static int Start(EasyClientManager.EmnuVideoDevicesInfoCallBack callback)
        {
            int _r = 0;
            EasyClientManager.EmnuVideoDevicesInfoCallBack _callback = null;
            if (callback != null) { _callback = callback; }

            EasyClientManager.EasyClient_Init();
            if (_callback != null)
            {
                EasyClientManager.EnumLocalVideoDevices(callback);
            }

            return _r;
        }

        public static void Stop() 
        {
            EasyClientManager.EasyClient_Release();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Start(callback);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Stop();
        }
    }
}
