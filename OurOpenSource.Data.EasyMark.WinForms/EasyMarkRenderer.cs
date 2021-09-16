using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace OurOpenSource.Data.EasyMark.WinForms
{
    /// <summary>
    /// EasyMark文本渲染器。
    /// </summary>
    /// <remarks>
    /// 实际上用的是WPF。
    /// </remarks>
    public partial class EasyMarkRenderer : UserControl
    {
#pragma warning disable IDE0044 // 添加只读修饰符
        private ElementHost elementHost = null;
#pragma warning restore IDE0044 // 添加只读修饰符
#pragma warning disable IDE0044 // 添加只读修饰符
        private OurOpenSource.Data.EasyMark.WPF.EasyMarkRenderer easyMarkRenderer = null;
#pragma warning restore IDE0044 // 添加只读修饰符

        /// <summary>
        /// 构造EasyMarkRenderer。
        /// </summary>
        public EasyMarkRenderer()
        {
            InitializeComponent();

            this.elementHost = new ElementHost();
            elementHost.Dock = DockStyle.Fill;
            this.easyMarkRenderer = new OurOpenSource.Data.EasyMark.WPF.EasyMarkRenderer();
            elementHost.Child = (UIElement)easyMarkRenderer;
            this.Controls.Add(elementHost);
        }

        /// <summary>
        /// 渲染处理
        /// </summary>
        /// <param name="markedEasyMark">需要渲染的处理过的EasyMark。</param>
        /// <remarks>
        /// 文本中请不要包含`\r\n`或者只有`\r`，请替换为`\n`。
        /// </remarks>
        public void Render(MarkedEasyMark markedEasyMark)
        {
            easyMarkRenderer.Render(markedEasyMark);
        }
    }
}
