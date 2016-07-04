using System;
using System.Collections.Generic;
using System.Text;

namespace EasyClient.Net
{
    public class EasyClientManager
    {
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public struct CAMERA_INFO_T
        {

            /// char[64]
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 64)]
            public string friendlyName;

            /// int
            public int width;

            /// int
            public int height;

            /// __CAMERA_INFO_T*
            public System.IntPtr pNext;
        }

        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct CAMERA_LIST_T
        {

            /// int
            public int count;

            /// CAMERA_INFO_T*
            public System.IntPtr pCamera;
        }

        /// Return Type: int
        ///_VideoDevicesInfo: CAMERA_LIST_T*
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.StdCall)]
        public delegate int EmnuVideoDevicesInfoCallBack(ref CAMERA_LIST_T _VideoDevicesInfo);

        //public partial class NativeMethods
        //{

            /// Return Type: int
            [System.Runtime.InteropServices.DllImportAttribute("EasyClient.dll", EntryPoint = "?EasyClient_Init@@YAHXZ")]
            public static extern int EasyClient_Init();


            /// Return Type: void
            [System.Runtime.InteropServices.DllImportAttribute("EasyClient.dll", EntryPoint = "?EasyClient_Release@@YAXXZ")]
            public static extern void EasyClient_Release();


            /// Return Type: int
            ///callback: EmnuVideoDevicesInfoCallBack
            [System.Runtime.InteropServices.DllImportAttribute("EasyClient.dll", EntryPoint = "?EnumLocalVideoDevices@@YAHP6GHPAU__CAMERA_LIST_T@@@Z@Z")]
            public static extern int EnumLocalVideoDevices(EmnuVideoDevicesInfoCallBack callback);

        //}

    }
}
