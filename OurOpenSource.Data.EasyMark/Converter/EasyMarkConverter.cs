using System;
using System.Collections.Generic;
using System.Text;

namespace OurOpenSource.Data.EasyMark.Converter
{
    public abstract class EasyMarkConverter
    {
        private Dictionary<string, IConverter> converters = new Dictionary<string, IConverter>();
        public Dictionary<string, IConverter> Converters { get { return converters; } }

        public void RegisterConverter(IConverter converter)
        {
            converters.Add(converter.Name, converter);
        }
        public void UnregisterConverter(string name)
        {
            converters.Remove(name);
        }

        /// <summary>
        /// 执行转化。
        /// </summary>
        /// <param name="markedEasyMark">被转化的EasyMark。</param>
        /// <returns></returns>
        public abstract string Convert(MarkedEasyMark markedEasyMark);

        //#region ==DefaultConfigure==
        //public static EasyMarkConverter DefaultConfigure_Html()
        //{
        //
        //}
        //#endregion
    }
}
