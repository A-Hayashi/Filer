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

        public List<FilerItem> SelectedFilerItems
        {
            get
            {
                List<FilerItem> list = new List<FilerItem>();
                foreach (ListViewItem item in list_view.SelectedItems)
                {
                    list.Add((FilerItem)item.Tag);
                }
                return list;
            }
        }

        public string CurrentPath
        {
            get { return current_path; }
        }

        private void setPath(string full__name)
        {
            current_path = full__name;
            drawView();
        }


        public void drawView()
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
            KeyCommandManager.Instance.executeAction(e.Control, e.Alt, e.Shift, e.KeyCode);

        }

        private void List_view_Enter(object sender, EventArgs e)
        {
            Form1 main_form = Form1.Instance;
            main_form.FocusedViewType = Form1.EFocusedViewType.FileView;
            main_form.setLastFocusedFileView(this);
        }
    }
}
