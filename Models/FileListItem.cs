using FullScratchCore.Models.Command;
using FullScratchCore.Models.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;

namespace FullScratchCore.Models
{
    public class FileListItem
    {
        public FileListItem(FileInfo fileinfo)
        {
            this.FileInfoInstance = fileinfo;
            this.ExecuteCmd = new OpenFileCmd();
        }

        private FileInfo FileInfoInstance { get; set; }

        public string FullPath
        {
            get
            {
                return FileInfoInstance.FullName;
            }
        }

        public string FileName
        {
            get
            {
                return FileInfoInstance.Name;
            }
        }

        public string Extention
        {
            get
            {
                return FileInfoInstance.Extension;
            }
        }

        public string CreationTime
        {
            get
            {
                return FileInfoInstance.CreationTimeUtc.ToString();
            }
        }

        public string LastUpdateTime
        {
            get
            {
                return FileInfoInstance.LastWriteTimeUtc.ToString();
            }
        }

        public long FileSize
        {
            get
            {
                return FileInfoInstance.Length;
            }
        }

        private ICommand _ExecuteCmd { get; set; }
        public ICommand ExecuteCmd
        {
            get
            {
                return _ExecuteCmd;
            }
            set
            {
                _ExecuteCmd = value;
            }
        }

        public static FileListItem SelectedListItem { get; set; }
    }
}
