using System;
using System.Collections.Generic;
using System.Text;

namespace OurOpenSource.Data.EasyMark.Marks
{
	/// <summary>
	/// 对象标记。
	/// </summary>
    public class EM_obj : IEasyMark
    {
		/// <summary>
		/// 标记的类型的名称。
		/// </summary>
		public string Name { get { return "obj"; } }

		/// <summary>
		/// 方法`Demark()`的返回值类型。
		/// </summary>
		public EasyMarkReturnType ReturnType { get { return EasyMarkReturnType.Void; } }

		/// <summary>
		/// 解析标记。
		/// </summary>
		/// <param name="basePath">EasyMark所在目录。</param>
		/// <param name="arg">标记中的`arg`部分。如果不存在则为`""`。</param>
		/// <returns>执行结果。如果没有则为`null`。</returns>
		public object Demark(string basePath, string arg)
        {
			return null;
        }

		/// <summary>
		/// 提取obj标记中存储的标记。
		/// </summary>
		/// <param name="arg">obj标志中的参数部分。</param>
		/// <returns>obj标记中存储的标记。</returns>
		public static EasyMarkContent ToMark(string arg)
        {
			return new EasyMarkContent("[ " + arg + " ]");
        }
	}
}
