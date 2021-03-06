﻿using System;
using System.Collections.Generic;
using System.Text;
using WindowsFormsApp8.Action;
using WindowsFormsApp8.FileSystem;


namespace WindowsFormsApp8.Action
{

    public class DeleteSelectedItem : Action
    {
        public override void execute()
        {
            Form1 main_form = Form1.Instance;

            if(main_form.FocusedViewType == Form1.EFocusedViewType.FileView)
            {
                FileView active_view = main_form.getLastFocusedFileView();

                List<FilerItem> list = active_view.SelectedFilerItems;
                foreach(FilerItem item in list)
                {
                    if(item.Type == FilerItem.ItemType.File)
                    {
                        Console.WriteLine("a");
                        Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(item.Info.FullName, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently);
                    }
                    else
                    {
                        Console.WriteLine("b");
                        Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(item.Info.FullName, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently);
                    }

                }
                active_view.drawView();

            }
            else
            {

            }
        }
    }

}