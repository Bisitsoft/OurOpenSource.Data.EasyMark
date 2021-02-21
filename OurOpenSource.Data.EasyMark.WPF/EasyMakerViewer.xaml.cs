using Microsoft.Win32;
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

namespace OurOpenSource.Data.EasyMark.WPF
{
    /// <summary>
    /// EasyMakerViewer.xaml 的交互逻辑
    /// </summary>
    public partial class EasyMakerViewer : UserControl
    {
        private static readonly string text_FileNotOpened = "File not opened.";

        public EasyMakerViewer()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            button_Open.Margin = new Thickness(button_Refresh.Margin.Left + button_Refresh.RenderSize.Width + 5, 0, 0, 0);
        }

        private string path = null;
        private EasyMarkDocument document = new EasyMarkDocument();

        private void button_Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "打开文件。";
            openFileDialog.InitialDirectory = path == null ? String.Empty : new FileInfo(path).Directory.FullName;
            openFileDialog.Filter =
                "EasyMarkFile(*.em, *.emk, *.emf, *emkf)|*.em;*.emk;*.emf;*emkf|" +
                "所有文件(*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.AddExtension = false;
            openFileDialog.CheckPathExists = true;
            openFileDialog.DereferenceLinks = true;
            openFileDialog.ValidateNames = true;

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
        private void ShowError(string text)
        {
            ShowMessage(text, "Error 错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void ShowWarning(string text)
        {
            ShowMessage(text, "Warning 警告", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        private void ShowInformation(string text)
        {
            ShowMessage(text, "Information 信息", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void ShowMessage(string text, string caption, MessageBoxButton buttons, MessageBoxImage icon)
        {
            MessageBox.Show(text, caption, buttons, icon);
        }
        #endregion
    }
}
