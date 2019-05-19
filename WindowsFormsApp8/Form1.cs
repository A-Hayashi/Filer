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

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        static private Form1 instance = null;

        public Form1()
        {
            instance = this;
            InitializeComponent();

            KeyCommandManager keycommand_manager = KeyCommandManager.Instance;
            keycommand_manager.registAction(keycommand_manager.getCommandString(false, false, false, Keys.Escape), new ExitApplication());
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

        }
    }
}
