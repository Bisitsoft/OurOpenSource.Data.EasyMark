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
    /// EasyMark文本查看器。
    /// </summary>
    /// <remarks>
    /// 实际上用的是WPF。
    /// </remarks>
    public partial class EasyMarkViewer : UserControl
    {
        private ElementHost elementHost = null;
        private OurOpenSource.Data.EasyMark.WPF.EasyMarkViewer easyMarkViewer = null;

        /// <summary>
        /// 构造EasyMarkViewer。
        /// </summary>
        public EasyMarkViewer()
        {
            InitializeComponent();

            this.elementHost = new ElementHost();
            elementHost.Dock = DockStyle.Fill;
            this.easyMarkViewer = new OurOpenSource.Data.EasyMark.WPF.EasyMarkViewer();
            elementHost.Child = (UIElement)easyMarkViewer;
            this.Controls.Add(elementHost);
        }
    }
}
