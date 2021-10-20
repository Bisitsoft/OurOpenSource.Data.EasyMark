using System;
using System.Collections.Generic;
using System.Text;

namespace OurOpenSource.Data.EasyMark
{
	/// <summary>
	/// EasyMark解码后返回的类型。
	/// </summary>
	public enum EasyMarkReturnType
	{
		/// <summary>
		/// 没有返回值。
		/// </summary>
		Void = 0,
		/// <summary>
		/// 返回字符串。
		/// </summary>
		String = 1,
		/// <summary>
		/// 返回`System.Drawing.Bitmap`。
		/// </summary>
		Bitmap = 2
	}
	
	/// <summary>
	/// EasyMark。
	/// </summary>
	/// <remarks>
	/// 只需提供空的构造函数，对于目前的模式不建议在无参数构造函数中消耗大量资源，因为它要被用于注册。
	/// </remarks>
	public interface IEasyMark
	{
		/// <summary>
		/// 标记的类型的名称。
		/// </summary>
		string Name { get; }

		/// <summary>
		/// 方法`Demark()`的返回值类型。
		/// </summary>
		EasyMarkReturnType ReturnType { get; }

		/// <summary>
		/// 解析标记。
		/// </summary>
		/// <param name="basePath">EasyMark所在目录。</param>
		/// <param name="arg">标记中的`arg`部分。如果不存在则为`""`。</param>
		/// <returns>执行结果。如果没有则为`null`。</returns>
		object Demark(string basePath, string arg);
	}
}
