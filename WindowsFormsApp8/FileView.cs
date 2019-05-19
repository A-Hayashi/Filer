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
using WindowsFormsApp8.FileSystem;
using WindowsFormsApp8.Action;

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

            string[] folders = Directory.GetDirectories(current_path);
            foreach (string folder in folders)
            {
                FilerItem filer_item = new Folder(folder);
                ListViewItem item = new ListViewItem(filer_item.Info.Name);
                item.Tag = filer_item;
                list_view.Items.Add(item);
            }

            string[] files = System.IO.Directory.GetFiles(current_path);
            foreach (string file in files)
            {
                FilerItem filer_item = new FileSystem.File(file);
                ListViewItem item = new ListViewItem(filer_item.Info.Name);
                item.Tag = filer_item;
                list_view.Items.Add(item);
            }

        }

        private void List_view_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void List_view_KeyDown(object sender, KeyEventArgs e)
        {
            if (KeyCommandManager.Instance.executeAction(e.Control, e.Alt, e.Shift, e.KeyCode))
            {

            }
            else if (e.KeyCode == Keys.Enter)
            {
                FilerItem item = (FilerItem)list_view.FocusedItem.Tag;


                if (item.Type == FilerItem.ItemType.Folder)
                {
                    setPath(item.Info.FullName);
                }
                else
                {
                    Process.Start(item.Info.FullName);
                }
            }
            else if (e.KeyCode == Keys.Back)
            {
                DirectoryInfo parent = Directory.GetParent(current_path);
                setPath(parent.FullName);
            }
        }
    }
}
