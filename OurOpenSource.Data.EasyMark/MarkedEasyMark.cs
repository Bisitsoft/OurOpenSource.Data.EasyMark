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

        /// <summary>
        /// 输出转义后的EasyMark文档。
        /// </summary>
        /// <returns>转义后的EasyMark文档。</returns>
        public string Output()
        {
			int i, j0, j1;//j值分开算是为了增加容错机制，不过如果文档是本身是错误的这样其实也没什么用。
			int move = 0; //long move = 0;
			StringBuilder document = new StringBuilder(Text);

            for (i = 0, j0 = j1 = 0; i < document.Length; i++)
            {
                if (document[i] == '[')
                {
                    if (i - move == MarksPosition[j0])
                    {
						j0++;
                    }
                    else
                    {
						document.Insert(i++, '[');
						move++;
                    }
                }
				else if (document[i] == ']')
				{
					if (i - move == MarksPosition[j1] + MarksLength[j1] - 1)
					{
						j1++;
					}
					else
					{
						document.Insert(i++, ']');
						move++;
					}
				}

                //if (document[i] == '[')
                //{
                //    if (i - move != MarksPosition[j])
                //    {
                //        document.Insert(i++, '[');
                //        move++;
                //    }
                //}
                //else if (document[i] == ']')
                //{
                //    if (i - move == MarksPosition[j] + MarksLength[j] - 1)
                //    {
                //        j++;
                //    }
                //    else
                //    {
                //        document.Insert(i++, ']');
                //        move++;
                //    }
                //}
            }

			return document.ToString();
		}

        public MarkedEasyMark(List<int> marksPosition, List<int> marksLength, string text)
        {
            this.MarksPosition = marksPosition;
            this.MarksLength = marksLength;
            this.Text = text;
        }
    }
}
