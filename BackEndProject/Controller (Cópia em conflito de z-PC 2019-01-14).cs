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
        public Repo repo = new Repo();
        Measure WorkingMeasure = new Measure();


        public Measure Insert( string Nome )
        {
            Measure measure = new Measure(Nome);
            return this.repo.NewMeasure(measure);
        }

        public Measure Update( Measure measure)
        {
            return this.repo.UpdateMeasure(measure);
        }


        public IList<Measure> GetAll()
        {
            return this.repo.GetallMeasures();
        }
        
        public void GravarDados()
        {
            repo.SaveData();
        }
        
        public void AbrirDados()
        {
            repo.OpenData();
        }
        
        public void tick()
        {

        }

    }
}
