using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MachineIO
{
    class UWC300
    {
        [DllImport("UWC300.dll", EntryPoint = "uwc300_initial", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int uwc300_initial(uint COM_Number);

        [DllImport("UWC300.dll", EntryPoint = "uwc300_close", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int uwc300_close();

        [DllImport("UWC300.dll", EntryPoint = "uwc300_set_output", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int uwc300_set_output(uint sts);

        [DllImport("UWC300.dll", EntryPoint = "uwc300_get_output", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int uwc300_get_output(ref char sts);

        [DllImport("UWC300.dll", EntryPoint = "uwc300_get_input", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int uwc300_get_input(ref char sts);

        [DllImport("UWC300.dll", EntryPoint = "uwc300_set_16output", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int uwc300_set_16output(uint sts);

        [DllImport("UWC300.dll", EntryPoint = "uwc300_get_16output", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int uwc300_get_16output(ref uint sts);

        [DllImport("UWC300.dll", EntryPoint = "uwc300_get_16input", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int uwc300_get_16input(ref uint sts);

        [DllImport("UWC300.dll", EntryPoint = "uwc300_set_32output", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int uwc300_set_32output(ulong sts);

        [DllImport("UWC300.dll", EntryPoint = "uwc300_get_32output", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int uwc300_get_32output(ref ulong sts);

        [DllImport("UWC300.dll", EntryPoint = "uwc300_get_32input", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int uwc300_get_32input(ref ulong sts);
    }
}
