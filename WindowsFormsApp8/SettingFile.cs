using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace WindowsFormsApp8.Util
{
    public class SetteingFile
    {
        static private SetteingFile instance = new SetteingFile();

        static public SetteingFile Instance
        {
            get { return instance; }

        }

        private string file = System.Windows.Forms.Application.StartupPath + @"\config.ini";

        private SetteingFile()
        {

        }

        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
        private static extern uint GetPrivateProfileString(string lpApplicationName, string lpEntryName, string lpDefault, System.Text.StringBuilder lpReturnedString, uint nSize, string lpFileName);

        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]

        private static extern uint WritePrivateProfileString(string lpApplicationName, string lpEntryName, string lpEntryString, string lpFileName);

        public void save(string section, string entry, string value)
        {
            WritePrivateProfileString(section, entry, value, file);
        }

        public string load(string section, string entry)
        {
            uint entryLength;

            System.Text.StringBuilder entry_string = new System.Text.StringBuilder(256);
            entryLength = GetPrivateProfileString(section, entry, "Nothing", entry_string, (uint)(entry_string.Capacity), file);
            return entry_string.ToString();
        }


    }
}