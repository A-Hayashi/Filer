using System;
using System.Collections.Generic;
using System.Text;
using WindowsFormsApp8.Action;
using WindowsFormsApp8.FileSystem;


namespace WindowsFormsApp8.Action
{

    public class moveToAnotherFileView : Action
    {
        public override void execute()
        {
            Form1 main_form = Form1.Instance;
            if(main_form.FocusedViewType == Form1.EFocusedViewType.FileView)
            {
                FileView active_view = main_form.getLastFocusedFileView();
                FileView inactive_view = main_form.getAnotherFileView(active_view);

                List<FilerItem> list = active_view.SelectedFilerItems;
                string to_folder = inactive_view.CurrentPath;
                foreach(FilerItem item in list)
                {
                    if(item.Type == FilerItem.ItemType.File)
                    {
                        Microsoft.VisualBasic.FileIO.FileSystem.MoveFile(item.Info.FullName, to_folder + "\\" + item.Info.Name, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs);
                    }
                    else
                    {
                        Microsoft.VisualBasic.FileIO.FileSystem.MoveFile(item.Info.FullName, to_folder, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs);
                    }
                }
            }
        }
    }

}