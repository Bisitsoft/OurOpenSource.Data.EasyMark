using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using OurOpenSource.Data.EasyMark;
using OurOpenSource.Data.EasyMark.Marks;

namespace OurOpenSource.Data.EasyMark.WPF
{
    /// <summary>
    /// EasyMarkRenderer.xaml 的交互逻辑
    /// </summary>
    public partial class EasyMarkRenderer : UserControl
    {
        /// <summary>
        /// 构造EasyMarkRenderer。
        /// </summary>
        public EasyMarkRenderer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 渲染EasyMark文档。
        /// </summary>
        /// <param name="markedEasyMark">标记过的EasyMark。</param>
        /// <remarks>
        /// 文本中请不要包含`\r\n`或者只有`\r`，请替换为`\n`。
        /// </remarks>
        public void Render(MarkedEasyMark markedEasyMark)
        {
            int i, nowIndex = 0;

            richTextBox.Document.Blocks.Clear();
            StringBuilder lastLine = new StringBuilder();
            Paragraph lastP = new Paragraph();
            Run lastR = new Run();
            void NewRun()
            {
                lastR.Text = lastLine.ToString();
                lastLine.Clear();
                lastP.Inlines.Add(lastR);
                lastR = new Run();
            }
            void NewParagraph()
            {
                richTextBox.Document.Blocks.Add(lastP);
                lastP = new Paragraph();
            }
            void AutoReturn(string text)
            {
                int i;
                for(i = 0; i < text.Length; i++)
                {
                    if (text[i] == '\n')
                    {
                        NewRun();
                        NewParagraph();
                    }
                    else
                    {
                        lastLine.Append(text[i]);
                    }
                }
            }
            void AddObject(IEasyMark easyMark, string arg)
            {
                switch (easyMark.ReturnType)
                {
                    case EasyMarkReturnType.Void:
                        break;
                    case EasyMarkReturnType.String:
                        AutoReturn((string)easyMark.Demark(markedEasyMark.BasePath, arg));
                        break;
                    case EasyMarkReturnType.Bitmap:
                        NewRun();
                        System.Windows.Controls.Image image = ToImage((Bitmap)easyMark.Demark(markedEasyMark.BasePath, arg));
                        lastP.Inlines.Add(image);
                        break;
                    default:
                        throw new Exception(String.Format("Unknown EasyMarkReturnType(value={0}).", (int)easyMark.ReturnType));
                }
            }

            for (i = 0; i < markedEasyMark.MarksPosition.Count; i++)
            {
                AutoReturn(markedEasyMark.Text.Substring(nowIndex, markedEasyMark.MarksPosition[i] - nowIndex));

                EasyMarkContent content = markedEasyMark[i];
                AddObject(EasyMarksManager.Marks[content.Name], content.Arg);

                nowIndex = markedEasyMark.MarksPosition[i] + markedEasyMark.MarksLength[i];
            }
            AutoReturn(markedEasyMark.Text.Substring(nowIndex));
            if (lastLine.Length > 0)
            {
                //简化的NewRun();
                lastR.Text = lastLine.ToString();
                lastLine.Clear();
                lastP.Inlines.Add(lastR);
            }
            if (lastP.Inlines.Count > 0)
            {
                //简化的NewParagraph();
                richTextBox.Document.Blocks.Add(lastP);
            }
        }
        //https://blog.csdn.net/u013139930/article/details/51785687
        private System.Windows.Controls.Image ToImage(Bitmap bitmap)
        {
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] bytes = ms.GetBuffer();  //byte[] bytes = ms.ToArray(); 这两句都可以
            ms.Close();
            //Convert it to BitmapImage
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = new MemoryStream(bytes);
            image.EndInit();
            return new System.Windows.Controls.Image()
            {
                Source = image,
                Stretch = Stretch.None
            };
        }
    }
}
