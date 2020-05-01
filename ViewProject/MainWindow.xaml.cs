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
using System.Threading;
using BackEndProject;
using System.Media;


namespace ViewProject
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BackEndProject.Controller controller = new Controller();
            FillData();
            _BoxingBell = new SoundPlayer("smb_coin.wav");
        }

        Controller controller = new Controller();
        Measure workingMeasure = new Measure("Novo");
        private bool BoolRunning = false;
        private bool BoolPlayedPomo = false;
        private SoundPlayer _BoxingBell;
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();






        private void FillData()
        {
            controller.AbrirDados();
            cmbLista.ItemsSource = controller.GetAll();
            cmbLista.DisplayMemberPath = "Nome";
        }


        private void UpdateDisplays()
        {
            lblMeasureTime.Content = workingMeasure.ShowMeasured();
            lblMeasureName.Content = workingMeasure.Nome;



        }

 


        // == POMODORO ============================================




        private void Pomodoro()
        {
            dispatcherTimer.Tick += new EventHandler(Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
   
        }


        private void Tick(object sender, EventArgs e)
        {
            lblPomodoro.Content = workingMeasure.TickPomodoro();
            lblMeasureTime.Content = workingMeasure.TickMeasured();
            
            if (sldPomo.Value <= Convert.ToDouble( workingMeasure.TickInMinutes() ) )
            {
                if (BoolPlayedPomo == false)
                {
                    _BoxingBell.Play();
                    BoolPlayedPomo = true;

                }
            }
        }



        // == CONTROLLERS =============================================




        private void StartStop_Click(object sender, RoutedEventArgs e)
        {
            if (BoolRunning == false)
            {
                btnStartStop.Content = "Stop";
                UpdateDisplays();
                workingMeasure.StartMeasuring();
                BoolRunning = true;
                BoolPlayedPomo = false;
                dispatcherTimer.Start();
                Pomodoro();


            }
            else
            {
                workingMeasure.StopMeasuring();
                BoolRunning = false;
                btnStartStop.Content = "Start";
                dispatcherTimer.Stop();
                UpdateDisplays();
                controller.GravarDados();
                
            }

        }

        private void BtnIncluir_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new WindowInclude();
            if (dialog.ShowDialog() == true)
            {
                controller.Insert(dialog.Nome);
                controller.GravarDados();
                cmbLista.Items.Refresh();
            }
        }


        private void cmbLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (workingMeasure.IsRunning() == false)
            {
                workingMeasure = (Measure)cmbLista.SelectedItem;
                UpdateDisplays();
            }
            else
            {
                MessageBox.Show("Você não pode mudar de projeto enquanto a medida está ocorrendo.");
            }

        }

    } // class
} // namespace
