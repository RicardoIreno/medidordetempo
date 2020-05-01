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
//using System.Timers;
using System.Threading;
using BackEndProject;


namespace ViewProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BackEndProject.Controller controller = new Controller();
            FillData();
        }

        Controller controller = new Controller();
        bool Running = false;
        Measure workingMeasure = new Measure("Novo");
        private Timer t = new Timer(new TimerCallback(tick), null, 1000, 1000) );

        private void FillData()
        {
            controller.AbrirDados();
            cmbLista.ItemsSource = controller.GetAll();
            cmbLista.DisplayMemberPath = "Nome";
        }

        static void tick(Object state)
        {
            btnStartStop.Content = "test";
        }

        private void btn_Incluir_Click(object sender, RoutedEventArgs e)
        {
            this.controller.Insert(txtMeasureName.Text);
            cmbLista.ItemsSource = controller.GetAll();
            cmbLista.Items.Refresh();
            txtMeasureName.Clear();
        }


        private void StartStop_Click(object sender, RoutedEventArgs e)
        {
            if (Running == false)
            {
                btnStartStop.Content = "Stop";
                UpdateDisplays();
                workingMeasure.StartMeasuring();
                Running = true;


            }
            else
            {
                workingMeasure.StopMeasuring();
                Running = false;
                btnStartStop.Content = "Start";
                UpdateDisplays();
                controller.GravarDados();
            }

        }
        /*
        private void TimeButtonEvent(Object source, ElapsedEventArgs e)
        {
            btnStartStop.Content = DisplayTimeButton();

        }

        void DisplayTimeButton()
        {
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 5, 0);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            btnStartStop.Content
        }
        */


        private void UpdateDisplays()
        {
            lblMeasureTime.Content = workingMeasure.ShowMeasured();
            lblMeasureName.Content = workingMeasure.Nome;
        }

        private void cmbLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            workingMeasure = (Measure)cmbLista.SelectedItem;
            UpdateDisplays();

        }

    } // class
} // namespace
