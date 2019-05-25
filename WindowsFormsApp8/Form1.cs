using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp8.Action;
using WindowsFormsApp8.Util;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        static private Form1 instance = null;

        public enum EFocusedViewType
        {
            FileView,
            HistoryView,
            Other
        }

        private EFocusedViewType focused_view = EFocusedViewType.Other;

        public EFocusedViewType FocusedViewType
        {
            get { return focused_view; }
            set { focused_view = value; }
        }
        private FileView last_focused_fileview = null;

        public FileView getLastFocusedFileView()
        {
            return last_focused_fileview;
        }

        public void setLastFocusedFileView(FileView focused_view)
        {
            last_focused_fileview = focused_view;
        }

        public FileView getAnotherFileView(FileView file_view)
        {
            if(file_view == left_file_listview)
            {
                return right_file_listview;
            }
            else
            {
                return left_file_listview;
            }
        }

        public Form1()
        {
            instance = this;
            InitializeComponent();

            KeyCommandManager keycommand_manager = KeyCommandManager.Instance;
            keycommand_manager.registAction(keycommand_manager.getCommandString(false, false, false, Keys.Escape), new ExitApplication());
            keycommand_manager.registAction(keycommand_manager.getCommandString(false, false, false, Keys.Enter), new ExecuteFocusedItem());
            keycommand_manager.registAction(keycommand_manager.getCommandString(false, false, false, Keys.Delete), new moveToRecycle());
            keycommand_manager.registAction(keycommand_manager.getCommandString(false, false, true, Keys.Delete), new DeleteSelectedItem());
            keycommand_manager.registAction(keycommand_manager.getCommandString(false, false, false, Keys.Back), new moveToParentFolder());
            keycommand_manager.registAction(keycommand_manager.getCommandString(false, false, false, Keys.C), new CopyToAnotherFileView());
            keycommand_manager.registAction(keycommand_manager.getCommandString(false, false, false, Keys.M), new moveToAnotherFileView());

            drawDriveToolbar();
        }

        static public Form1 Instance
        {
            get { return instance; }
        }


        private void ListView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FileView2_Load(object sender, EventArgs e)
        {

        }

        private void FileView1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetteingFile file = SetteingFile.Instance;

            String h_str = file.load("Location", "Height");
            String w_str = file.load("Location", "Width");

            try
            {
                this.Height = int.Parse(h_str);
                this.Width = int.Parse(w_str);
            }
            catch
            {
                this.Height = 600;
                this.Width = 800;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            KeyCommandManager.Instance.executeAction(e.Control, e.Alt, e.Shift, e.KeyCode);
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SetteingFile file = SetteingFile.Instance;

            if(WindowState == FormWindowState.Normal)
            {
                file.save("Location", "Height", this.Height.ToString());
                file.save("Location", "Width", this.Width.ToString());
            }
        }

        private void drawDriveToolbar()
        {
            drive_toolbar.Items.Clear();

            System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
            foreach (System.IO.DriveInfo drive in drives)
            {
                ToolStripButton button = new ToolStripButton(drive.Name, null, changeDrive);
                drive_toolbar.Items.Add(button);
            }
        }

        public void changeDrive(object sender, EventArgs e)
        {
            ToolStripButton button = (ToolStripButton)sender;
            FileView view = getLastFocusedFileView();

            view.setPath(button.Text);
            view.drawView();
        }
    }
}
