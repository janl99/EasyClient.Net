using System;
using System.Collections.Generic;
using System.Text;

namespace EasyPusher.Net
{
    public class EasyPusherManager
    {

        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct EASY_MEDIA_INFO_T
        {

            /// unsigned int
            public uint u32VideoCodec;

            /// unsigned int
            public uint u32VideoFps;

            /// unsigned int
            public uint u32AudioCodec;

            /// unsigned int
            public uint u32AudioSamplerate;

            /// unsigned int
            public uint u32AudioChannel;
        }

        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct EASY_AV_Frame
        {

            /// unsigned int
            public uint u32AVFrameFlag;

            /// unsigned int
            public uint u32AVFrameLen;

            /// unsigned int
            public uint u32VFrameType;

            /// unsigned char*
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
            public string pBuffer;

            /// unsigned int
            public uint u32TimestampSec;

            /// unsigned int
            public uint u32TimestampUsec;
        }

        public enum EASY_PUSH_STATE_T
        {

            /// EASY_PUSH_STATE_CONNECTING -> 1
            EASY_PUSH_STATE_CONNECTING = 1,

            EASY_PUSH_STATE_CONNECTED,

            EASY_PUSH_STATE_CONNECT_FAILED,

            EASY_PUSH_STATE_CONNECT_ABORT,

            EASY_PUSH_STATE_PUSHING,

            EASY_PUSH_STATE_DISCONNECTED,

            EASY_PUSH_STATE_ERROR,
        }

        /// Return Type: int
        ///_id: int
        ///_state: EASY_PUSH_STATE_T->__EASY_PUSH_STATE_T
        ///_frame: EASY_AV_Frame*
        ///_userptr: void*
        public delegate int EasyPusher_Callback(int _id, EASY_PUSH_STATE_T _state, ref EASY_AV_Frame _frame, System.IntPtr _userptr);

        //public partial class NativeMethods
        //{

            /// Return Type: void*
            [System.Runtime.InteropServices.DllImportAttribute("libEasyPusher.dll", EntryPoint = "EasyPusher_Create", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
            public static extern System.IntPtr EasyPusher_Create();

        
            /// Return Type: unsigned int
            ///handle: void*
            [System.Runtime.InteropServices.DllImportAttribute("libEasyPusher.dll", EntryPoint = "EasyPusher_Release", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
            public static extern uint EasyPusher_Release(System.IntPtr handle);


            /// Return Type: unsigned int
            ///handle: void*
            ///callback: EasyPusher_Callback
            ///id: int
            ///userptr: void*
            [System.Runtime.InteropServices.DllImportAttribute("libEasyPusher.dll", EntryPoint = "EasyPusher_SetEventCallback", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
            public static extern uint EasyPusher_SetEventCallback(System.IntPtr handle, EasyPusher_Callback callback, int id, System.IntPtr userptr);


            /// Return Type: unsigned int
            ///handle: void*
            ///serverAddr: char*
            ///port: unsigned short
            ///streamName: char*
            ///username: char*
            ///password: char*
            ///pstruStreamInfo: EASY_MEDIA_INFO_T*
            ///bufferKSize: unsigned int
            ///createlogfile: unsigned char
            [System.Runtime.InteropServices.DllImportAttribute("libEasyPusher.dll", EntryPoint = "EasyPusher_StartStream", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
            public static extern uint EasyPusher_StartStream(System.IntPtr handle, System.IntPtr serverAddr, ushort port, System.IntPtr streamName, System.IntPtr username, System.IntPtr password, ref EASY_MEDIA_INFO_T pstruStreamInfo, uint bufferKSize, byte createlogfile);


            /// Return Type: unsigned int
            ///handle: void*
            [System.Runtime.InteropServices.DllImportAttribute("libEasyPusher.dll", EntryPoint = "EasyPusher_StopStream", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
            public static extern uint EasyPusher_StopStream(System.IntPtr handle);


            /// Return Type: unsigned int
            ///handle: void*
            ///frame: EASY_AV_Frame*
            [System.Runtime.InteropServices.DllImportAttribute("libEasyPusher.dll", EntryPoint = "EasyPusher_PushFrame", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
            public static extern uint EasyPusher_PushFrame(System.IntPtr handle, ref EASY_AV_Frame frame);

        //}

    }
}
