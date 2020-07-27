using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;

namespace FullScratchCore.Models.Common
{
    class DataTableConstructor
    {
        public DataTableConstructor(string datapath, Encoding enc, bool useHeader)
        {
            this.DataPath = datapath;
            this.Encoding = enc;
            this.UseHeader = useHeader;
        }

        private string _DataPath { get; set; }
        public string DataPath
        {
            get
            {
                return _DataPath;
            }
            set
            {
                _DataPath = value;
            }
        }

        /// <summary>
        /// 文字コード指定
        /// </summary>
        private Encoding _Encoding { get; set; }
        public Encoding Encoding
        {
            get
            {
                return _Encoding;
            }
            set
            {
                _Encoding = value;
            }
        }

        private bool UseHeader { get; set; }

        public DataTable Construct()
        {
            var temptable = new DataTable();
            string Line = new StreamReader(this.DataPath, this.Encoding).ReadLine();
            int SeparaterCount = Line.Length - Line.Replace(",", "").Length + 1;

            using (var StreamReader = new StreamReader(this.DataPath, this.Encoding))
            {
                if (UseHeader)
                {
                    for (int i = 0; i <= SeparaterCount; i++)
                    {
                        temptable.Columns.Add().ColumnName = Line.Split(',')[i];
                    }
                    StreamReader.ReadLine();
                }
                else
                {
                    for (int i = 0; i <= SeparaterCount; i++)
                    {
                        temptable.Columns.Add().ColumnName = i.ToString();
                    }
                }

                long RowCnt = 1;
                while (!StreamReader.EndOfStream)
                {
                    var dr = temptable.NewRow();
                    dr.ItemArray = (RowCnt + "," + StreamReader.ReadLine()).Split(',');
                    temptable.Rows.Add(dr.ItemArray);
                    RowCnt++;
                }
            }
            return temptable;
        }
    }
}

