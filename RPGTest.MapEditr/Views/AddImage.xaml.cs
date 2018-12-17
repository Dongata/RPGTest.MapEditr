using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace RPGTest.MapEditr.Views
{
    /// <summary>
    /// Interaction logic for AddImage.xaml
    /// </summary>
    public partial class AddImage : Window
    {
        private readonly App _app;
        private bool txtImagePathValidated = false;
        private bool txtImageNameValidated = false;

        public AddImage()
        {
            InitializeComponent();
            _app = Application.Current as App;
            BtnOk.IsEnabled = false;
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            var openDialog = new OpenFileDialog();
            if (openDialog.ShowDialog() == true)
            {
                TxtImagePath.Text = openDialog.FileName;
            }
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            _app.Sprites.Add(new Image
            {
                Name = TxtImageName.Text,
                Source = new BitmapImage(new Uri(TxtImagePath.Text))
            });

            Close();
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender == TxtImageName)
            {
                txtImageNameValidated = IsValidatedTxt(TxtImageName);
            }

            if (sender == TxtImagePath)
            {
                txtImagePathValidated = IsValidatedTxt(TxtImagePath);
            }

            if (BtnOk != null)
            {
                BtnOk.IsEnabled = txtImagePathValidated && txtImageNameValidated;
            }
        }

        private bool IsValidatedTxt(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                return false;
            }

            return true;
        }
    }
}
