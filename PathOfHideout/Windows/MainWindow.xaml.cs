using PathOfHideout.Services;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace PathOfHideout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HideoutMover _hideoutMover = new();

        public MainWindow()
        {
            InitializeComponent();

            txt_HideoutFilePath.Text = @"F:\hideout.hideout";
            txt_XCoordinate.Text = "10";
            txt_YCoordinate.Text = "10";
        }

        private void btn_MoveDecorations_Click(object sender, RoutedEventArgs e)
        {
            _hideoutMover.MoveDecorations(
                txt_HideoutFilePath.Text, 
                int.Parse(txt_XCoordinate.Text), 
                int.Parse(txt_YCoordinate.Text));
        }
    }
}
