using System;
using System.Collections.Generic;
using System.Text;
using WindowsFormsApp8.Action;
using WindowsFormsApp8.FileSystem;


namespace WindowsFormsApp8.Action
{

    public class moveToParentFolder : Action
    {
        public override void execute()
        {
            Form1 main_form = Form1.Instance;
            if(main_form.FocusedViewType == Form1.EFocusedViewType.FileView)
            {
                FileView view = main_form.getLastFocusedFileView();
                System.IO.DirectoryInfo parent = System.IO.Directory.GetParent(view.CurrentPath);
                view.setPath(parent.FullName);
                view.drawView();
            }
        }
    }

}