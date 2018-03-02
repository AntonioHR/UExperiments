using GRVM.UExperiment.Objects.SharedVariables;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace GRVM.UExperiment.Objects
{
    [CreateAssetMenu()]
    public class Report : ScriptableObject
    {
        public List<PrintableVar> vars;

        public string fileName;
        

        public string ToCSVLine()
        {
            return string.Join(", ", vars.Select(x => x.PrintableValue).ToArray());
        }

        public void LogCSVLine()
        {
            Debug.Log(ToCSVLine());
        }

        public void SaveToFile()
        {
            StreamWriter sw;
            if (!File.Exists(FilePath))
            {
                sw =  File.CreateText(FilePath);
                sw.WriteLine(Labels);
            } else
            {
                sw = File.AppendText(FilePath);
            }

            sw.WriteLine(ToCSVLine());

            sw.Close();

            Debug.Log("Wrote to " + FilePath);
        }

        private string FilePath
        {
            get
            {
                return Application.persistentDataPath + "/"+ fileName;
            }
        }

        private string Labels
        {
            get
            {
                return string.Join(", ", vars.Select(x => x.label).ToArray());
            }
        }
    }
}
