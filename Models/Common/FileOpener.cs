﻿using FullScratchCore.ViewModels;
using Microsoft.Win32;
using System;
using System.IO;
using System.Text;

namespace FullScratchCore.Models.Common
{
    class FileOpener 
    {

        public FileOpener(Encoding enc, Models.TabItemBase.ControlType controlType)
        {
            this.TabViewModel = new CustomTabViewModel();
            this.EncodingType = enc;
            this.ControlType = controlType;
        }

        private CustomTabViewModel TabViewModel;
        private Encoding EncodingType { get; set; }
        private Models.TabItemBase.ControlType ControlType { get; set; }
        private string TabID { get; set; }

        public void OpenFile()
        {
            OpenFileDialog Dialog = new OpenFileDialog();



            if ((bool)Dialog.ShowDialog())
            {
                using (StreamReader Reader = new StreamReader(Dialog.FileName, this.EncodingType))
                {
                    var TabViewModel = new CustomTabViewModel();
                    if (Path.GetExtension(Dialog.FileName) == ".csv")
                    {
                        TabViewModel.TabAdd(new Models.GridTabItem(Path.GetFileName(Dialog.FileName), Dialog.FileName, this.ControlType));
                    }
                    else
                    {
                        TabViewModel.TabAdd(new Models.TextTabItem(Path.GetFileName(Dialog.FileName), Reader.ReadToEnd(), this.ControlType));
                    }

                };

            }
        }

        public void OpenFile(string filepath)
        {
            using (StreamReader Reader = new StreamReader(filepath, this.EncodingType))
            {
                    if (Path.GetExtension(filepath) == ".csv")
                    {
                        CustomTabViewModel.Tabs.Add(new Models.GridTabItem(Path.GetFileName(filepath),filepath, this.ControlType));
                    }
                    else
                    {
                        TabViewModel.TabAdd(new Models.TextTabItem(Path.GetFileName(filepath), Reader.ReadToEnd(), this.ControlType));
                    }
            }
        }
    }
}

