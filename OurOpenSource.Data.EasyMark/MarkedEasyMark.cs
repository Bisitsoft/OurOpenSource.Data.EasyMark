using System;
using System.Collections.Generic;
using System.Text;

namespace OurOpenSource.Data.EasyMark
{
    public class MarkedEasyMark
    {
        public List<int> MarksPosition { get; set; }
        /// <remarks>
        /// 包含一堆括号的长度。
        /// </remarks>
        public List<int> MarksLength { get; set; }
        public string Text { get; set; }

        public MarkContent this[int index]
        {
            get
            {
                return new MarkContent(Text.Substring(MarksPosition[index], MarksLength[index]));
            }
        }

        public MarkedEasyMark(List<int> marksPosition, List<int> marksLength, string text)
        {
            this.MarksPosition = marksPosition;
            this.MarksLength = marksLength;
            this.Text = text;
        }
    }
}
