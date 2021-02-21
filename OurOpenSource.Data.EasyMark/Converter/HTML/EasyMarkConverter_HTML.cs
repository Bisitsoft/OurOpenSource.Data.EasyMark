using System;
using System.Collections.Generic;
using System.Text;

namespace OurOpenSource.Data.EasyMark.Converter.HTML
{
    public class EasyMarkConverter_HTML : EasyMarkConverter
    {
        public EasyMarkConverter_HTML()
        {
            base.RegisterConverter(new EMC_img());
        }
    }
}
