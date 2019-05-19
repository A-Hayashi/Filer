using System;
using System.Collections.Generic;
using System.Text;


namespace WindowsFormsApp8.Action
{
    class ExitApplication : Action
    {
        public override void execute()
        {
            Form1.Instance.Close();

        }

    }
}