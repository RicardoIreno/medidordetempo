using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using System.Windows;

namespace BackEndProject
{
    public class Repo
    {

        private List<Measure> Measures = new List<Measure>();


               
        // == PERSISTENCE  ==============================================




        public void SaveData()
        {
            JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var str = serializer.Serialize(Measures);

            using (StreamWriter w = new StreamWriter("measures.json"))
            {
                w.Write(str);
            }

        }
        public void OpenData()
        {    
            using (StreamReader r = new StreamReader("measures.json"))
            {
                JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                dynamic json = r.ReadToEnd();
                var z = serializer.Deserialize<List<Measure>>(json);
                Measures = z;

            }  
        } 



  
        // == MEASURE CRUD ============================================



        public Measure NewMeasure (Measure measure )
        {
            this.Measures.Add(measure);
            return measure;

        }
        public Measure UpdateMeasure (Measure measure )
        {
            this.Measures[this.Measures.IndexOf(measure)] = measure;
            return measure;

        }

        public void ExcludeMeasure(Measure measure)
        {
            this.Measures.Remove(measure);
       

        }

        public List<Measure> GetallMeasures()
        {
            return Measures;
        }

    } //class
} //namespace 
