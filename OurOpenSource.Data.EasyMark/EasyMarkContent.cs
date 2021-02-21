using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OurOpenSource.Data.EasyMark
{
    public class EasyMarkContent
    {
        private string name;
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

        private string arg;
        public string Arg
        {
            get { return arg; }
            set
            {
                arg = value == null ? "" : value;
            }
        }

        /// <returns>返回形如`name arg`或`name`的字符串。</returns>
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
        /// <returns>返回形如`[ name arg ]`或`[ name ]`的字符串。</returns>
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

        /// <remarks>
        /// 如果`arg`为`null`会自动被替换为`""`。
        /// </remarks>
        public EasyMarkContent(string name, string arg = "")
        {
            this.Name = name;
            this.Arg = arg;
        }
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
