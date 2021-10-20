using System;
using System.Collections.Generic;
using System.Text;

namespace OurOpenSource.Data.EasyMark
{
    /// <summary>
    /// 用于存储已处理过（标记过标记位置）的EasyMark文本。
    /// </summary>
    /// <remarks>
    /// 因为只是用于存储，所以各个值之间不想关。
    /// </remarks>
    public class MarkedEasyMark
    {
        /// <summary>
        /// EasyMark的绝对路径。
        /// </summary>
        public string BasePath { get; set; }

        /// <summary>
        /// 各个标记的位置。
        /// </summary>
        public List<int> MarksPosition { get; set; }
        /// <summary>
        /// 各个标记的长度。
        /// </summary>
        /// <remarks>
        /// 长度包含一对方括号。
        /// </remarks>
        public List<int> MarksLength { get; set; }
        /// <summary>
        /// EasyMark文本。
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 标记。
        /// </summary>
        /// <param name="index">标记的索引。</param>
        /// <returns>标记内容。</returns>
        public EasyMarkContent this[int index]
        {
            get
            {
                return new EasyMarkContent(Text.Substring(MarksPosition[index], MarksLength[index]));
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

        /// <summary>
        /// 构造MarkedEasyMark。
        /// </summary>
        /// <param name="marksPosition">各个标记的位置。</param>
        /// <param name="marksLength">各个标记的长度。</param>
        /// <param name="text">EasyMark文本。</param>
        public MarkedEasyMark(List<int> marksPosition, List<int> marksLength, string text, string basePath)
        {
            this.MarksPosition = marksPosition;
            this.MarksLength = marksLength;
            this.Text = text;
            this.BasePath = basePath;
        }
    }
}
