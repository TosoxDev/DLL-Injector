using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace LWSInjector
{
    internal class InjectorAPI
    {
        public const int MAX_PATH = 260;

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr OpenProcess(ProcessAccessFlags processAccess, bool bInheritHandle, int processId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [MarshalAs(UnmanagedType.AsAny)] object lpBuffer, Int32 nSize, out IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CloseHandle(IntPtr hHandle);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr GetModuleHandle(string moduleName);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, out IntPtr lpThreadId);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, AllocationType flAllocationType, MemoryProtection flProtect);

        [Flags]
        public enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VirtualMemoryOperation = 0x00000008,
            VirtualMemoryRead = 0x00000010,
            VirtualMemoryWrite = 0x00000020,
            DuplicateHandle = 0x00000040,
            CreateProcess = 0x000000080,
            SetQuota = 0x00000100,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            QueryLimitedInformation = 0x00001000,
            Synchronize = 0x00100000
        }

        [Flags]
        public enum AllocationType
        {
            Commit = 0x1000,
            Reserve = 0x2000,
            Decommit = 0x4000,
            Release = 0x8000,
            Reset = 0x80000,
            Physical = 0x400000,
            TopDown = 0x100000,
            WriteWatch = 0x200000,
            LargePages = 0x20000000
        }

        [Flags]
        public enum MemoryProtection
        {
            Execute = 0x10,
            ExecuteRead = 0x20,
            ExecuteReadWrite = 0x40,
            ExecuteWriteCopy = 0x80,
            NoAccess = 0x01,
            ReadOnly = 0x02,
            ReadWrite = 0x04,
            WriteCopy = 0x08,
            GuardModifierflag = 0x100,
            NoCacheModifierflag = 0x200,
            WriteCombineModifierflag = 0x400
        }

        public enum InjectionReturnCodes : int
        {
            Success = 0,
            InvalidProcess = 1,
            HandleAccessError = 2,
            InvalidLoadLibraryAddress = 3,
            InvalidVirtualAdress = 4,
            WriteMemoryError = 5,
            CreateThreadError = 6
        }

        public static InjectionReturnCodes InjectLoadLibrary(byte[] data, string procname)
        {
            // Create new temporary file
            string imagePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString()) + ".dll";

            // Fill the file with the data
            File.WriteAllBytes(imagePath, data);

            // Inject the file into the process
            return InjectLoadLibrary(imagePath, procname);
        }

        public static InjectionReturnCodes InjectLoadLibrary(string dllpath, string procname)
        {
            // Find the process with the name procname
            Process[] procs = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(procname));
            if (procs.Length == 0)
                return InjectionReturnCodes.InvalidProcess;

            // Create a handle to the process
            IntPtr hProc = OpenProcess(ProcessAccessFlags.All, true, procs[0].Id);
            if (hProc == IntPtr.Zero)
                return InjectionReturnCodes.HandleAccessError;

            // Get a pointer to the LoadLibrary function of kernel32
            IntPtr loadlibAddy = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            if (loadlibAddy == IntPtr.Zero)
                return InjectionReturnCodes.InvalidLoadLibraryAddress;

            // Allocate memory
            IntPtr loc = VirtualAllocEx(hProc, IntPtr.Zero, MAX_PATH, AllocationType.Commit | AllocationType.Reserve, MemoryProtection.ExecuteReadWrite);
            if (loc == IntPtr.Zero)
                return InjectionReturnCodes.InvalidVirtualAdress;

            // Load the data of the dll into memory
            bool result = WriteProcessMemory(hProc, loc, dllpath, dllpath.Length, out _);
            if (!result)
                return InjectionReturnCodes.WriteMemoryError;

            // Inject the dll
            IntPtr hThread = CreateRemoteThread(hProc, IntPtr.Zero, 0, loadlibAddy, loc, 0, out _);
            if (hThread == IntPtr.Zero) 
                return InjectionReturnCodes.CreateThreadError;

            CloseHandle(hThread);

            return InjectionReturnCodes.Success;
        }
    }
}
