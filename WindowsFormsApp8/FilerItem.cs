using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace WindowsFormsApp8.FileSystem
{
    public abstract class FilerItem
    {
        public enum ItemType
        {
            File,
            Folder
        }
        abstract public FileSystemInfo Info { get; }
        abstract public ItemType Type { get; }


    }
}
