using Performance.PerformanceLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace StopWatch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private delegate void UpdateStuff(string statusText);

        private PerformanceCalculator timer;
        private BackgroundWorker worker;
        private object returnedObject;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                timer = new PerformanceCalculator();

                worker = new BackgroundWorker();
                worker.DoWork += worker_DoWork;
                worker.RunWorkerCompleted += worker_RunWorkerCompleted;
                worker.RunWorkerAsync();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
                CheckBoxTest.IsChecked = true;

            ReturnData.Text += " Data From Method called: " + Convert.ToInt32(returnedObject) + "\n\n\n\n" + "Start Time: " + timer.TimeStarted + " ( Approx. " + Convert.ToDateTime(timer.TimeStarted.ToString()).ToLongTimeString() + ")" + "\n\nEnd Time: " + timer.TimeEnded + " ( Approx. " + Convert.ToDateTime(timer.TimeEnded.ToString()).ToLongTimeString() + ")" +
                               "\n\nElapsed Time: " + timer.ElapsedTime + " (Approx. " + timer.ElapsedTime.Seconds + " seconds)" + "\n\nElapsed Ticks " + timer.ElapsedTicks;



        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            returnedObject = timer.StartStopWatch(CodeNeedRunning, 5, 20,true );

        }

        public object CodeNeedRunning(object min, object max)
        {
            Random rand = new Random();

            return rand.Next(Convert.ToInt32(min), Convert.ToInt32(max));

        }
    }
}
