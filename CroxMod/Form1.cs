using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace CroxMod
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll")]
        public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll")]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, out IntPtr lpThreadId);

        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hObject);

        const int PROCESS_ALL_ACCESS = 0x1F0FFF;

        // NEW: store all items for filtering/sorting
        private List<ListViewItem> allItems = new List<ListViewItem>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "DLL Files (*.dll)|*.dll";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtDLLPath.Text = ofd.FileName;
            }
        }

        // UPDATED: refresh with categories
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            listProcesses.Items.Clear();
            allItems.Clear();

            Process[] processes = Process.GetProcesses();
            foreach (Process proc in processes)
            {
                try
                {
                    string category = GetProcessCategory(proc);
                    ListViewItem item = new ListViewItem(new[]
                    {
                        proc.Id.ToString(),
                        proc.ProcessName,
                        category
                    });
                    item.Tag = proc.ProcessName.ToLower(); // For sorting
                    allItems.Add(item);
                }
                catch { }
            }

            ApplyFilter("All");
        }

        private void btnInject_Click(object sender, EventArgs e)
        {
            if (listProcesses.SelectedItems.Count == 0 || string.IsNullOrEmpty(txtDLLPath.Text))
            {
                MessageBox.Show("Select a process and DLL first!");
                return;
            }

            string selectedPid = listProcesses.SelectedItems[0].SubItems[0].Text;
            int pid = int.Parse(selectedPid);

            string dllPath = txtDLLPath.Text;

            bool success = InjectDLL(pid, dllPath);
            if (success)
                MessageBox.Show("Injected successfully!");
            else
                MessageBox.Show("Injection failed!");
        }

        bool InjectDLL(int pid, string dllPath)
        {
            IntPtr hProc = OpenProcess(PROCESS_ALL_ACCESS, false, pid);
            if (hProc == IntPtr.Zero) return false;

            IntPtr addr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            IntPtr allocMem = VirtualAllocEx(hProc, IntPtr.Zero, (uint)(dllPath.Length + 1), 0x1000, 0x40);

            UIntPtr bytesWritten;
            bool written = WriteProcessMemory(hProc, allocMem, System.Text.Encoding.ASCII.GetBytes(dllPath), (uint)(dllPath.Length + 1), out bytesWritten);

            if (!written)
            {
                CloseHandle(hProc);
                return false;
            }

            IntPtr hThread = CreateRemoteThread(hProc, IntPtr.Zero, 0, addr, allocMem, 0, out _);
            CloseHandle(hProc);

            return hThread != IntPtr.Zero;
        }

        // NEW: categorize processes
        private string GetProcessCategory(Process p)
        {
            try
            {
                if (p.MainWindowHandle != IntPtr.Zero) return "Application";
                if (p.ProcessName.ToLower().Contains("svchost") ||
                    p.ProcessName.ToLower().Contains("system")) return "System";
                return "Process";
            }
            catch { return "Process"; }
        }

        // NEW: filtering
        private void ApplyFilter(string type)
        {
            listProcesses.Items.Clear();
            var filtered = allItems.Where(i => type == "All" || i.SubItems[2].Text == type);
            foreach (var item in filtered)
                listProcesses.Items.Add((ListViewItem)item.Clone());
        }

        private void btnShowAll_Click(object sender, EventArgs e) => ApplyFilter("All");
        private void btnShowApps_Click(object sender, EventArgs e) => ApplyFilter("Application");
        private void btnShowSystem_Click(object sender, EventArgs e) => ApplyFilter("Process");

        // NEW: alphabetical sort
        private void btnSortAlpha_Click(object sender, EventArgs e)
        {
            var sorted = listProcesses.Items.Cast<ListViewItem>()
                .OrderBy(i => i.Tag.ToString())
                .ToArray();
            listProcesses.Items.Clear();
            listProcesses.Items.AddRange(sorted);
        }

        private void listProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
