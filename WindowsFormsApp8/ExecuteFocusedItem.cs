using System;
using System.Collections.Generic;
using System.Text;
using WindowsFormsApp8.Action;
using WindowsFormsApp8.FileSystem;
using System.Diagnostics;

namespace WindowsFormsApp8.Action
{

    public class ExecuteFocusedItem : Action
    {
        public override void execute()
        {
            Form1 main_form = Form1.Instance;
            if(main_form.FocusedViewType == Form1.EFocusedViewType.FileView)
            {
                FileView view = main_form.getLastFocusedFileView();

                List<FilerItem> list = view.SelectedFilerItems;
                if(list.Count != 1)
                {
                    return;
                }

                FilerItem item = list[0];
                if(item.Type == FilerItem.ItemType.Folder)
                {
                    view.setPath(item.Info.FullName);
                }
                else
                {
                    Process.Start(item.Info.FullName);
                }
            }
            else if(main_form.FocusedViewType == Form1.EFocusedViewType.HistoryView)
            {

            }
        }
    }

}