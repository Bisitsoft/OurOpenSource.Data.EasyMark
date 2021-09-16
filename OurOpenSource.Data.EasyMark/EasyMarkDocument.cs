using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OurOpenSource.Data.EasyMark
{
    /// <summary>
    /// EasyMark文档。
    /// </summary>
    public class EasyMarkDocument
    {
        private MarkedEasyMark markedEasyMark = null;
        /// <summary>
        /// 标记过的EasyMark。
        /// </summary>
        public MarkedEasyMark MarkedEasyMark { get { return markedEasyMark; } }

        /// <summary>
        /// 从文件件加载EasyMark文档。
        /// </summary>
        /// <param name="path">文档路径。</param>
        public void LoadFromFile(string path)
        {
            markedEasyMark = EasyMarkLoader.LoadFromFile(path);
        }
        /// <summary>
        /// 直接从标记过的EasyMark加载文档。
        /// </summary>
        /// <param name="markedEasyMark">标记过的EasyMark。</param>
        public void Load(MarkedEasyMark markedEasyMark)
        {
            this.markedEasyMark = markedEasyMark;
        }
    }
}