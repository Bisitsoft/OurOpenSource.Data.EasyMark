﻿using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace OurOpenSource.Data.EasyMark.Marks
{
	/// <summary>
	/// 图片标记。
	/// </summary>
    public class EM_img : IEasyMark
    {
		private string src;

		/// <summary>
		/// 标记的类型的名称。
		/// </summary>
		public string Name { get { return "img"; } }

		/// <summary>
		/// 方法`Demark()`的返回值类型。
		/// </summary>
		public EasyMarkReturnType ReturnType { get { return EasyMarkReturnType.Bitmap; } }

		/// <summary>
		/// 解析标记。
		/// </summary>
		/// <param name="arg">标记中的`arg`部分。如果不存在则为`""`。</param>
		/// <returns>执行结果。如果没有则为`null`。</returns>
		public object Demark(string arg)
		{
			return Bitmap.FromFile(arg);
		}
	}
}
