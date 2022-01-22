using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _index = -1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonAddName_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) && !lstNames.Items.Contains(txtName.Text))
            {
                lstNames.Items.Add(txtName.Text);
                txtName.Clear();
            }
        }

        private void NameText_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                ButtonAddName_Click(sender, e);
            }     
        }

        private void ButtonDeleteName_Click(object sender, RoutedEventArgs e)
        {
            if(lstNames.Items.Count == 0)
            {
                MessageBox.Show("There is no name to delete");
            }
            else if(lstNames.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a name to delete");
            }
            else
            {
                lstNames.Items.RemoveAt(lstNames.SelectedIndex);
            }
        }

        private void ButtonSortName_Click(object sender, RoutedEventArgs e)
        {
            var nameList = new List<string>();
            foreach (var item in lstNames.Items)
            {
#pragma warning disable CS8604 // Possible null reference argument.
                nameList.Add(item.ToString());
#pragma warning restore CS8604 // Possible null reference argument.
            }

            var sortedNameList = nameList.OrderBy(x => x.ToString());
            lstNames.Items.Clear();
            foreach (var name in sortedNameList)
            {
                lstNames.Items.Add(name);
            }
        }

        private void ButtonEditName_Click(object sender, RoutedEventArgs e)
        {
            if (lstNames.Items.Count == 0)
            {
                MessageBox.Show("There is no name to edit");
            }
            else if (lstNames.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a name to edit");
            }
            else if(txtName.Text.ToString().Trim().Equals(""))
            {
                // do nothing
            }
            else
            {
                lstNames.Items[_index] = txtName.Text.ToString();
            }
        }

        private void NameListBox_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(lstNames.SelectedIndex >= 0 )//&& txtName.Text.Trim() ! = "")
            {
                txtName.Text = lstNames.SelectedItem.ToString();
                _index = lstNames.SelectedIndex;
            }           
        }
    }
}
