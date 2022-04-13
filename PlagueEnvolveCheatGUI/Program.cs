using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PlagueEnvolveCheatGUI
{
    static class NativeMethod
    {
        [DllImport("PlagueEnvolveCheatHelper.dll", EntryPoint = "modifyValue", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void modifyValue(ref ulong newValue);

        [DllImport("PlagueEnvolveCheatHelper.dll", EntryPoint = "readProcessMemoryStatus", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool readProcessMemoryStatus();

        [DllImport("PlagueEnvolveCheatHelper.dll", EntryPoint = "emptyMemory", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void emptyMemory();

        [DllImport("PlagueEnvolveCheatHelper.dll", EntryPoint = "getCurrentValue", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern ulong getCurrentValue();

        [DllImport("kernel32.dll", EntryPoint = "AllocConsole", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool AllocConsole();

        [DllImport("kernel32.dll", EntryPoint = "FreeConsole", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void FreeConsole();
    }
    public class Program
    {
        public static int RunGUIWindow(string argument)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PlagueEnvolveWindow());
            return 0;
        }
    }
}
