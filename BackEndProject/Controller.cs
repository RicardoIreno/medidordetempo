using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BackEndProject
{
    public class Controller
    {
        public  Repo repo = new Repo();
        static Measure WorkingMeasure = new Measure();



        // == CRUD ========================================



        public  Measure Insert( string Nome )
        {
            Measure measure = new Measure(Nome);
            return this.repo.NewMeasure(measure);
        }

        public Measure Update( Measure measure )
        {
            return this.repo.UpdateMeasure(measure);
        }

        public void Exclude(Measure measure )
        {
            this.repo.ExcludeMeasure(measure);
        }


        public IList<Measure> GetAll()
        {
            return this.repo.GetallMeasures();
        }
        


        // == CALL PERSISTENCE ==========================



        public void GravarDados()
        {
            this.repo.SaveData();
        }
        
        public void AbrirDados()
        {
            repo.OpenData();
        }
    }
}
