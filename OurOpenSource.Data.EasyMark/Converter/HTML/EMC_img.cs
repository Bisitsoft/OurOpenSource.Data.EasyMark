﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OurOpenSource.Data.EasyMark.Converter.HTML
{
    public class EMC_img : IConverter
    {
		/// <summary>
		/// 标记的类型的名称。
		/// </summary>
		public string Name { get { return "img"; } }

		/// <summary>
		/// 转化EasyMark为字符串。
		/// </summary>
		/// <param name="content">EasyMark内容。</param>
		/// <returns>转化后得到的字符串。</returns>
		public string Convert(EasyMarkContent content)
        {
            if (content.Arg[0] != '"')
            {
				return String.Format("<img src=\"{0}\">", content.Arg[0]);
            }
            else
            {
				return String.Format("<img src={0}>", content.Arg[0]);

			}
        }
	}
}
