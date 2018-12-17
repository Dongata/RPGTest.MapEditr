using RPGTest.MapEditr.Entities;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace RPGTest.MapEditr.Views
{
    /// <summary>
    /// Interaction logic for NewMap.xaml
    /// </summary>
    public partial class NewMap : Window
    {
        #region Fields

        private readonly App _app;

        private readonly Regex _onlyNumbers = new Regex("[^0-9]+");
        private bool txtHeightPristine = true;
        private bool txtWidthPristine = true;
        private bool txtNamePristine = true;

        private bool txtHeightValidated = false;
        private bool txtWidthtValidated = false;
        private bool txtNameValidated = false;

        #endregion

        #region Ctor

        public NewMap()
        {
            InitializeComponent();
            _app = (App)Application.Current;
            OkBtn.IsEnabled = false;
        }

        #endregion

        #region Iteraction logic

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            _app.ActualMap = new Map(
                TxtName.Text,
                int.Parse(TxtWidth.Text),
                int.Parse(TxtHeight.Text));

            Close();
        }

        private void TxtHeight_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtHeightPristine)
            {
                TxtHeight.Text = "";
                txtHeightPristine = false;
            }
        }

        private void TxtWidth_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtWidthPristine)
            {
                TxtWidth.Text = "";
                txtWidthPristine = false;
            }
        }

        private void TxtName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtNamePristine)
            {
                TxtName.Text = "";
                txtNamePristine = false;
            }
        }

        private void OnlyNumbers(object sender, System.Windows.Input.TextCompositionEventArgs e) =>
            e.Handled = _onlyNumbers.IsMatch(e.Text);

        private void CancelBtn_Click(object sender, RoutedEventArgs e) => Close();

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender == TxtWidth)
            {
                txtWidthtValidated = IsValidatedTxt(TxtWidth);
            }

            if (sender == TxtHeight)
            {
                txtHeightValidated = IsValidatedTxt(TxtHeight);
            }

            if (sender == TxtName)
            {
                txtNameValidated = IsValidatedTxt(TxtName);
            }

            if (OkBtn != null)
            {
                OkBtn.IsEnabled = txtNameValidated && txtHeightValidated && txtWidthtValidated &&
                    !txtWidthPristine && !txtNamePristine && !txtHeightPristine;
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

        #endregion
    }
}
