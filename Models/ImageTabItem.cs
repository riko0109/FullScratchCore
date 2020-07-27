using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FullScratchCore.Models
{
    public class ImageTabItem : TabItemBase
    {
        public ImageTabItem(string header, ControlType type, string filepath) : base(header, type)
        {
            this.Header = header;
            this.TabType = type;
            this.TabID = System.Guid.NewGuid().ToString();
            this.Image = GetBitmapImage(filepath);
        }

        public BitmapImage Image { get; set; }

        public BitmapImage GetBitmapImage(string filepath)
        {
            var bmpImg = new BitmapImage();
            bmpImg.BeginInit();

            // オプションその 1 : 読込元のファイルがロックされない。
            bmpImg.CacheOption = BitmapCacheOption.OnLoad;
            // オプションその 2 : decoded image の幅を指定できる。サムネイル用に小さく表示する場合などのメモリ節約に有効。
            bmpImg.DecodePixelWidth = 50;
            // オプションその 3 : わからん
            bmpImg.CreateOptions = BitmapCreateOptions.None;

            bmpImg.UriSource = new Uri(filepath);
            bmpImg.EndInit();

            // オプションその 4 : スレッドをまたいで BitmapImage を受け渡す場合に必要な操作。
            // この例では意味ないと思います。知らんけど。
            // 例えば、このメソッドを非同期にするなら必要になる。
            bmpImg.Freeze();

            return bmpImg;
        }
    }
}

