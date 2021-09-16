using System;
using System.Collections.Generic;
using System.Text;

namespace OurOpenSource.Data.EasyMark.Marks
{
    /// <summary>
    /// EasyMark类型管理器。
    /// </summary>
    public static class EasyMarksManager
    {
        private static Dictionary<string, IEasyMark> marks = new Dictionary<string, IEasyMark>();
        /// <summary>
        /// 所有已注册EasyMark类型。
        /// </summary>
        public static Dictionary<string, IEasyMark> Marks { get { return marks; } }

        /// <summary>
        /// 注册EasyMark类型。
        /// </summary>
        /// <param name="mark">EasyMark类型。</param>
        public static void Register(IEasyMark mark)
        {
            marks.Add(mark.Name, mark);
        }

        /// <summary>
        /// 注销EasyMark类型。
        /// </summary>
        /// <param name="mark">EasyMark类型。</param>
        public static void Unregister(IEasyMark mark)
        {
            marks.Remove(mark.Name);
        }

        /// <summary>
        /// 初始化本管理器。
        /// </summary>
        /// <remarks>
        /// 目前仅用于加载系统自带的EasyMark类型。
        /// </remarks>
        public static void Initialization()
        {
            Register(new EM_cmt());
            Register(new EM_img());
            Register(new EM_obj());
        }
    }
}
