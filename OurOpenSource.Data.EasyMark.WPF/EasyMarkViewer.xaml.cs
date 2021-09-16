using System;
using System.Collections.Generic;
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

using Microsoft.Win32;

namespace OurOpenSource.Data.EasyMark.WPF
{
    /// <summary>
    /// EasyMarkViewer.xaml 的交互逻辑
    /// </summary>
    public partial class EasyMarkViewer : UserControl
    {
        private static readonly string text_FileNotOpened = "File not opened.";

        /// <summary>
        /// 构造EasyMarkViewer。
        /// </summary>
        public EasyMarkViewer()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            button_Open.Margin = new Thickness(button_Refresh.Margin.Left + button_Refresh.RenderSize.Width + 5, 0, 0, 0);
        }

        private string path = null;
#pragma warning disable IDE0044 // 添加只读修饰符
        private EasyMarkDocument document = new EasyMarkDocument();
#pragma warning restore IDE0044 // 添加只读修饰符

        private void button_Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "打开文件。",
                InitialDirectory = path == null ? String.Empty : new FileInfo(path).Directory.FullName,
                Filter =
                "EasyMarkFile(*.em, *.emk, *.emf, *emkf)|*.em;*.emk;*.emf;*emkf|" +
                "所有文件(*.*)|*.*",
                FilterIndex = 1,
                AddExtension = false,
                CheckPathExists = true,
                DereferenceLinks = true,
                ValidateNames = true
            };

            if (openFileDialog.ShowDialog() == true)
            {
                path = openFileDialog.FileName;

                FileInfo file = new FileInfo(path);
                if (!file.Exists)
                {
                    ShowError("File type not support; File has broken; No access permit.");
                    return;
                }
                label_FilePath.Content = path;
            }

            RefreshPage();
        }

        private void button_Refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshPage();
        }

        /// <summary>
        /// 刷新页面。
        /// </summary>
        private void RefreshPage()
        {
            if (path == null)
            {
                ShowInformation("Please open a file first.");
            }
            else
            {
                try
                {
                    document.LoadFromFile(path);
                    this.easyMarkRenderer.Render(document.MarkedEasyMark);
                }
                catch (Exception ex)
                {
                    ShowError(ex.ToString());
                }
            }
        }

        #region ===ShowMessage===
        /// <summary>
        /// 显示错误提示框。
        /// </summary>
        /// <param name="text">显示内容。</param>
        private void ShowError(string text)
        {
            ShowMessage(text, "Error 错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        /// <summary>
        /// 显示警告提示框。
        /// </summary>
        /// <param name="text">显示内容。</param>
        private void ShowWarning(string text)
        {
            ShowMessage(text, "Warning 警告", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        /// <summary>
        /// 显示信息提示框。
        /// </summary>
        /// <param name="text">显示内容。</param>
        private void ShowInformation(string text)
        {
            ShowMessage(text, "Information 信息", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        /// <summary>
        /// 显示提示框。
        /// </summary>
        /// <param name="text">显示内容。</param>
        /// <param name="caption">标题。</param>
        /// <param name="buttons">按钮。</param>
        /// <param name="icon">图标。</param>
        private void ShowMessage(string text, string caption, MessageBoxButton buttons, MessageBoxImage icon)
        {
            MessageBox.Show(text, caption, buttons, icon);
        }
        #endregion
    }
}
