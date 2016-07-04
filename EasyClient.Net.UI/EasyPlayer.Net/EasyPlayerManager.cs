using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace EasyPlayer.Net
{
    
    public class EasyPlayerManager
    {
        public enum RENDER_FORMAT
        {

            /// DISPLAY_FORMAT_YV12 -> 842094169
            DISPLAY_FORMAT_YV12 = 842094169,

            /// DISPLAY_FORMAT_YUY2 -> 844715353
            DISPLAY_FORMAT_YUY2 = 844715353,

            /// DISPLAY_FORMAT_UYVY -> 1498831189
            DISPLAY_FORMAT_UYVY = 1498831189,

            /// DISPLAY_FORMAT_A8R8G8B8 -> 21
            DISPLAY_FORMAT_A8R8G8B8 = 21,

            /// DISPLAY_FORMAT_X8R8G8B8 -> 22
            DISPLAY_FORMAT_X8R8G8B8 = 22,

            /// DISPLAY_FORMAT_RGB565 -> 23
            DISPLAY_FORMAT_RGB565 = 23,

            /// DISPLAY_FORMAT_RGB555 -> 25
            DISPLAY_FORMAT_RGB555 = 25,

            /// DISPLAY_FORMAT_RGB24_GDI -> 26
            DISPLAY_FORMAT_RGB24_GDI = 26,
        }

        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct RTSP_FRAME_INFO {
    
            /// unsigned int
            public uint codec;
    
            /// unsigned int
            public uint type;
    
            /// unsigned char
            public byte fps;
    
            /// unsigned short
            public ushort width;
    
            /// unsigned short
            public ushort height;
    
            /// unsigned int
            public uint reserved1;
    
            /// unsigned int
            public uint reserved2;
    
            /// unsigned int
            public uint sample_rate;
    
            /// unsigned int
            public uint channels;
    
            /// unsigned int
            public uint length;
    
            /// unsigned int
            public uint timestamp_usec;
    
            /// unsigned int
            public uint timestamp_sec;
    
            /// float
            public float bitrate;
    
            /// float
            public float losspacket;
        }


        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct Point
        {

            /// LONG->int
            public int x;

            /// LONG->int
            public int y;
        }

        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct tagRECT
        {

            /// LONG->int
            public int left;

            /// LONG->int
            public int top;

            /// LONG->int
            public int right;

            /// LONG->int
            public int bottom;
        }

        public delegate int MediaSourceCallBack(int _channelId, IntPtr _channelPtr, int _frameType, [MarshalAs(UnmanagedType.LPArray)] byte[] pBuf, [MarshalAs(UnmanagedType.LPArray)] RTSP_FRAME_INFO[] _frameInfo);

        //public partial class NativeMethods
        //{

        /// Return Type: int
        [System.Runtime.InteropServices.DllImportAttribute("libEasyPlayer.dll", EntryPoint = "?EasyPlayer_Init@@YAHXZ")]
        //[DllImport("libEasyPlayer.dll", EntryPoint = "EasyPlayer_Init", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int EasyPlayer_Init();


        /// Return Type: void
        [System.Runtime.InteropServices.DllImportAttribute("libEasyPlayer.dll", EntryPoint = "?EasyPlayer_Release@@YAXXZ")]
        public static extern void EasyPlayer_Release();

        /// Return Type: int
        [System.Runtime.InteropServices.DllImportAttribute("libEasyPlayer.dll", EntryPoint = "?EasyPlayer_OpenStream@@YAHPBDPAUHWND__@@W4__RENDER_FORMAT@@H00P6GHHPAHHPADPAURTSP_FRAME_INFO@@@ZPAX@Z")]
        public static extern int EasyPlayer_OpenStream(String url, IntPtr hWnd, RENDER_FORMAT renderFormat, int rtpovertcp, String username, String password, MediaSourceCallBack callback, IntPtr userPtr);

        /// Return Type: void
        ///channelId: int
        [System.Runtime.InteropServices.DllImportAttribute("libEasyPlayer.dll", EntryPoint = "?EasyPlayer_CloseStream@@YAXH@Z")]
        public static extern void EasyPlayer_CloseStream(int channelId);


        /// Return Type: int
        ///channelId: int
        ///cache: int
        [System.Runtime.InteropServices.DllImportAttribute("libEasyPlayer.dll", EntryPoint = "?EasyPlayer_SetFrameCache@@YAHHH@Z")]
        public static extern int EasyPlayer_SetFrameCache(int channelId, int cache);


        /// Return Type: int
        ///channelId: int
        ///shownToScale: int
        [System.Runtime.InteropServices.DllImportAttribute("libEasyPlayer.dll", EntryPoint = "?EasyPlayer_SetShownToScale@@YAHHH@Z")]
        public static extern int EasyPlayer_SetShownToScale(int channelId, int shownToScale);


        /// Return Type: int
        ///channelId: int
        ///decodeKeyframeOnly: int
        [System.Runtime.InteropServices.DllImportAttribute("libEasyPlayer.dll", EntryPoint = "?EasyPlayer_SetDecodeType@@YAHHH@Z")]
        public static extern int EasyPlayer_SetDecodeType(int channelId, int decodeKeyframeOnly);


        /// Return Type: int
        ///channelId: int
        ///lpSrcRect: LPRECT->tagRECT*
        [System.Runtime.InteropServices.DllImportAttribute("libEasyPlayer.dll", EntryPoint = "?EasyPlayer_SetRenderRect@@YAHHPAUtagRECT@@@Z")]
        public static extern int EasyPlayer_SetRenderRect(int channelId, ref tagRECT lpSrcRect);


        /// Return Type: int
        ///channelId: int
        ///show: int
        [System.Runtime.InteropServices.DllImportAttribute("libEasyPlayer.dll", EntryPoint = "?EasyPlayer_ShowStatisticalInfo@@YAHHH@Z")]
        public static extern int EasyPlayer_ShowStatisticalInfo(int channelId, int show);


        /// Return Type: int
        ///channelId: int
        ///pt: POINT->tagPOINT
        [System.Runtime.InteropServices.DllImportAttribute("libEasyPlayer.dll", EntryPoint = "?EasyPlayer_SetDragStartPoint@@YAHHUtagPOINT@@@Z")]
        public static extern int EasyPlayer_SetDragStartPoint(int channelId, Point pt);


        /// Return Type: int
        ///channelId: int
        ///pt: POINT->tagPOINT
        [System.Runtime.InteropServices.DllImportAttribute("libEasyPlayer.dll", EntryPoint = "?EasyPlayer_SetDragEndPoint@@YAHHUtagPOINT@@@Z")]
        public static extern int EasyPlayer_SetDragEndPoint(int channelId, Point pt);


        /// Return Type: int
        ///channelId: int
        [System.Runtime.InteropServices.DllImportAttribute("libEasyPlayer.dll", EntryPoint = "?EasyPlayer_ResetDragPoint@@YAHH@Z")]
        public static extern int EasyPlayer_ResetDragPoint(int channelId);


        /// Return Type: int
        ///channelId: int
        [System.Runtime.InteropServices.DllImportAttribute("libEasyPlayer.dll", EntryPoint = "EasyPlayer_StartManuRecording@@YAHH@Z")]
        public static extern int EasyPlayer_StartManuRecording(int channelId);


        /// Return Type: int
        ///channelId: int
        [System.Runtime.InteropServices.DllImportAttribute("libEasyPlayer.dll", EntryPoint = "?EasyPlayer_StopManuRecording@@YAHH@Z")]
        public static extern int EasyPlayer_StopManuRecording(int channelId);


        /// Return Type: int
        ///channelId: int
        [System.Runtime.InteropServices.DllImportAttribute("libEasyPlayer.dll", EntryPoint = "?EasyPlayer_PlaySound@@YAHH@Z")]
        public static extern int EasyPlayer_PlaySound(int channelId);


        /// Return Type: int
        [System.Runtime.InteropServices.DllImportAttribute("libEasyPlayer.dll", EntryPoint = "?EasyPlayer_StopSound@@YAHXZ")]
        public static extern int EasyPlayer_StopSound();

        //}

    }
}
