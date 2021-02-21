using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OurOpenSource.Data.EasyMark
{
    public class EasyMarkDocument
    {
        private MarkedEasyMark markedEasyMark = null;
        public MarkedEasyMark MarkedEasyMark { get { return markedEasyMark; } }

        public void LoadFromFile(string path)
        {
            markedEasyMark = EasyMarkLoader.LoadFromFile(path);
        }
        public void Load(MarkedEasyMark markedEasyMark)
        {
            this.markedEasyMark = markedEasyMark;
        }
    }
}