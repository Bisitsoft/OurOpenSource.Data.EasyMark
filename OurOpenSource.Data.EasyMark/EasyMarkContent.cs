using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OurOpenSource.Data.EasyMark
{
    /// <summary>
    /// 一个EasyMark的内容。
    /// </summary>
    public class EasyMarkContent
    {
        /// <summary>
        /// EasyMark的标记类型名称。
        /// </summary>
        private string name;
        /// <summary>
        /// EasyMark的标记类型名称。
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Name");
                }
                name = value;
            }
        }

        /// <summary>
        /// 参数部分的内容。
        /// </summary>
        private string arg;
        /// <summary>
        /// 参数部分的内容。
        /// </summary>
        public string Arg
        {
            get { return arg; }
            set
            {
                arg = value == null ? "" : value;
            }
        }

        /// <summary>
        /// 输出EasyMark的内容。
        /// </summary>
        /// <returns>
        /// 返回形如`name arg`或`name`的字符串。
        /// </returns>
        public override string ToString()
        {
            if(Arg == "")
            {
                return Name;
            }
            else
            {
                return Name + " " + Arg;
            }
        }
        /// <summary>
        /// 返回整个EasyMArk。
        /// </summary>
        /// <returns>
        /// 返回形如`[ name arg ]`或`[ name ]`的字符串。
        /// </returns>
        public string ToFullyString()
        {
            if (Arg == "")
            {
                return "[ " + Name + " ]";
            }
            else
            {
                return "[ " + Name + " " + Arg + " ]";
            }
        }

        /// <summary>
        /// 构造标记内容。
        /// </summary>
        /// <param name="name">
        /// 标记的类型名称。
        /// </param>
        /// <param name="arg">
        /// 标记的参数部分。
        /// </param>
        /// <remarks>
        /// 如果`arg`为`null`会自动被替换为`""`。
        /// </remarks>
        public EasyMarkContent(string name, string arg = "")
        {
            this.Name = name;
            this.Arg = arg;
        }
        /// <summary>
        /// 构造标记内容。
        /// </summary>
        /// <param name="fullMark">完整的标记文本。</param>
        public EasyMarkContent(string fullMark)
        {
            if(!Regex.Match(fullMark,"^\\[ .* \\]$").Success)
            {
                throw new FormatException("Not a completed mark.");
            }

            string content = fullMark.Substring(2, fullMark.Length - 4);

            string name = new string(content.TakeWhile((char ch) => { return ch != ' '; }).ToArray());
            if (Regex.Match(name, "[^A-Za-z0-9_]").Success)
            {
                throw new FormatException("The name of mark must only has alphabets, numbers and `'_'`.");
            }
            if(name.Length >= content.Length - 1)
            {
                if(name.Length != content.Length)
                {
                    name += " ";
                }
                this.Arg = "";
            }
            else
            {
                this.Arg = content.Substring(name.Length + 1);
            }
            this.Name = name;
        }
    }
}
