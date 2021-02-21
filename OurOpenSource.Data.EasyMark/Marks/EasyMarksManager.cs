using System;
using System.Collections.Generic;
using System.Text;

namespace OurOpenSource.Data.EasyMark.Marks
{
    public static class EasyMarksManager
    {
        private static Dictionary<string, IEasyMark> marks = new Dictionary<string, IEasyMark>();
        public static Dictionary<string, IEasyMark> Marks { get { return marks; } }

        public static void Register(IEasyMark mark)
        {
            marks.Add(mark.Name, mark);
        }

        public static void Unregister(IEasyMark mark)
        {
            marks.Remove(mark.Name);
        }

        public static void Initialization()
        {
            Register(new EM_comment());
            Register(new EM_img());
            Register(new EM_object());
        }
    }
}
