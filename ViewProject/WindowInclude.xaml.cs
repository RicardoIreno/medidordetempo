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
using System.Windows.Shapes;
using BackEndProject;

namespace ViewProject
{
    /// <summary>
    /// Interaction logic for WindowInclude.xaml
    /// </summary>
    public partial class WindowInclude : Window
    {
        public WindowInclude()
        {
            InitializeComponent();
        }
        public string Nome
        {
            get { return txtMeasureName.Text; }
            set { txtMeasureName.Text = value; }
        }

        private void btn_Incluir_Click(object sender, RoutedEventArgs e)
        {

            DialogResult = true;

        }
    }
}
