using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Timers;
//using System.Threading;
using System.Threading.Tasks;


namespace BackEndProject
{
    public class Measure
    {
        public string Nome { get; set; }
        public double Min { get; set; }
        private Stopwatch Measuring { get; set; }
        private bool Running = false;




        public Measure()
        {
        }
        public Measure( string Nome )
        {
            this.Nome = Nome;
        }




        public void StartMeasuring()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            this.Measuring = sw;
            Running = true;
        }


        public void StopMeasuring()
        {
            TimeSpan ts = new TimeSpan();
            
            Measuring.Stop();
            ts += this.Measuring.Elapsed;
            Min += ts.TotalMinutes;

            //Measured += this.Measuring.Elapsed;
            Measuring.Reset();

            //Min += Measured.Minutes;
            Running = false;

        }


        public string ShowMeasured()
        {
            if (Min > 59)
            {
                int mm = Convert.ToInt32(Min);
                int h = mm / 60;
                int m = mm % 60;
                return String.Format("{0:00}:{1:00}", h, m);
            }
            else
            {
                return String.Format("{0:00}:{1:00}", 0, Min);
            }
        } 


        public string TickPomodoro()
        {
            TimeSpan ts = this.Measuring.Elapsed;
            return String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);

        }

        public int TickInMinutes()
        {
            return Measuring.Elapsed.Minutes;
        }


        
        public string TickMeasured()
        {
            TimeSpan ts = this.Measuring.Elapsed;
            int m = TimeSpan.FromMinutes(Min + ts.Minutes).Minutes;
            int h = TimeSpan.FromMinutes(Min + ts.Minutes).Hours;

            return String.Format("{0:00}:{1:00}", h, m);
        }

        public bool IsRunning()
        {
            return Running;
        }



    } // -- class
} // -- namespace
