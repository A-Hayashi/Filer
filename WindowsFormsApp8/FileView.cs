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

namespace WindowsFormsApp8
{
    public partial class FileView : UserControl
    {
        private string current_path = @"c:\";
      
        public FileView()
        {
            InitializeComponent();
            setPath(current_path);
        }

        private void setPath(string full__name)
        {
            current_path = full__name;
            drawView();    
        }


        private void drawView()
        {
            list_view.Clear();
            list_view.Columns.Add("名前", 300);

            string[] folders = System.IO.Directory.GetDirectories(current_path);
            foreach(string folder in folders)
            {
                string[] strs = folder.Split('\\');
                string folder_name = strs[strs.Length - 1];

                ListViewItem item = new ListViewItem(folder_name);
                item.Tag = folder;
                list_view.Items.Add(item);
            }

            string[] files = System.IO.Directory.GetFiles(current_path);
            foreach(string file in files)
            {
                string file_name = System.IO.Path.GetFileName(file);
                ListViewItem item = new ListViewItem(file_name);
                item.Tag = file;
                list_view.Items.Add(item);
            }

        }

        private void List_view_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void List_view_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                ListViewItem item = list_view.FocusedItem;
                string item_name = (string)item.Tag;

                if (System.IO.Directory.Exists(item_name))
                {
                    setPath(item_name);
                }else if (System.IO.File.Exists(item_name))
                {
                    Process.Start(item_name);
                }
            }else if(e.KeyCode == Keys.Back)
            {
                System.IO.DirectoryInfo info = System.IO.Directory.GetParent(current_path);
                setPath(info.FullName);
            }
        }
    }
}
