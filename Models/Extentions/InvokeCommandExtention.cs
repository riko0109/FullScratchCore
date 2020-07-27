using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace FullScratchCore.Models.Extentions
{
    /// <summary>
    /// マークアップ拡張継承クラス
    /// </summary>
    [MarkupExtensionReturnType(typeof(EventHandler))]
    public sealed class InvokeCommandExtention : MarkupExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException();
        }
    }
}

