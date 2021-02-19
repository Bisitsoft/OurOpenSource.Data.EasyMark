using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OurOpenSource.Data.EasyMark
{
	public class EasyMark
	{
		public static string Escape(string origin){
			int i;
			StringBuilder sb = new StringBuilder(origin);

			for(i = 0; i < sb.Length; i++){
				if(sb[i] == '[')
				{
					sb.Insert(i, '[');
					i++;
				}
				else if(sb[i] == ']')
				{
					sb.Insert(i, ']');
					i++;
				}
			}

			return sb.ToString();
		}

		//public static string Unescape(string escaped){
		//	int i;
		//	StringBuilder sb = new StringBuilder(escaped);
		//	
		//	for (i = 0; i < sb.Length - 1; i++)
		//	{
		//		if (sb[i] == '[' && sb[i + 1] == '[')
		//		{
		//			sb.Remove(i, 1);
		//		}
		//		else if (sb[i] == ']' && sb[i + 1] == ']')
		//		{
		//			sb.Remove(i, 1);
		//		}
		//	}
		//	
		//	return sb.ToString();
		//}

		/// <summary>
		/// 处理EasyMark的原文本。
		/// </summary>
		/// <param name="easyMarkText">EasyMark的原文本。</param>
		/// <returns>处理后的EasyMark。</returns>
		/// <remarks>
		/// 通过寻找单数的连续的`'['`的尾部，来寻找一个标记的起始。
		/// </remarks>
		public static MarkedEasyMark ProcessEasyMark(string originText)
        {
			int i, moveTemp, realIndex, markPosition;
			int move = 0; //long move = 0;
			//int matchMarks = 0;
			bool inMark = false;
			List<int> marksPosition = new List<int>();
			List<int> marksLength = new List<int>();
			StringBuilder processedText = new StringBuilder(originText);

			MatchCollection matches = Regex.Matches(originText, "[\\[]{1,}|[\\]]{1,}");

            try
            {
				for (i = 0; i < matches.Count; i++)
				{
					Match match = matches[i];
					moveTemp = match.Length / 2;
					realIndex = match.Index - move;
					processedText.Remove(realIndex, moveTemp);
					move += moveTemp;
					if (match.Length % 2 != 0) //(match.Length & 1) == 1
					{
						if (match.Value[0] == '[')
						{
                            if (inMark)
                            {
								throw new FormatException("Repeated left bracket.");
                            }
                            else
                            {
								inMark = true;
                            }
							markPosition = realIndex + (match.Length - 1) - moveTemp;
							if (processedText[markPosition + 1] != ' ')
                            {
								throw new FormatException("After left bracket of beginning of the mark should be ' '.");
							}
							marksPosition.Add(markPosition);
							//matchMarks++;
						}
						else if (match.Value[0] == ']')
						{
							if (inMark)
							{
								marksLength.Add(realIndex - marksPosition.Last() + 1);
								inMark = false;
							}
							else
							{
								throw new FormatException("Lost left bracket.");
							}
							if (processedText[realIndex - 1] != ' ')
							{
								throw new FormatException("Before right bracket of ending of the mark should be ' '.");
							}
							//matchMarks--;
						}
					}
				}
            }
            catch (IndexOutOfRangeException)
            {
				throw new FormatException("Left and right brackets do not match.");
			}

			////这种检查方式较慢，应当直接检查左括号下一个是否为右括号。但是为了提高解析速度，斌没有在每个matchMarks++或--前后检查matchMarks的值。
            //if (matchMarks != 0)
            //{
			//	throw new FormatException("Left and right brackets do not match.");
            //}

			return new MarkedEasyMark(marksPosition, marksLength, processedText.ToString());
		}
	}
}
