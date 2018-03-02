using GRVM.UExperiment.Objects.SharedVariables;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GRVM.UExperiment.Objects
{
    [CreateAssetMenu()]
    public class Report : ScriptableObject
    {
        public List<PrintableVar> vars;


        public string ToCSVLine()
        {
            return string.Join(", ", vars.Select(x => x.PrintableValue).ToArray());
        }

        public void LogCSVLine()
        {
            Debug.Log(ToCSVLine());
        }
    }
}
