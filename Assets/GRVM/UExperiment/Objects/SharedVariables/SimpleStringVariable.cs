using System;
using UnityEngine;

namespace GRVM.UExperiment.Objects.SharedVariables
{
    [CreateAssetMenu]
    public class SimpleStringVariable : StringSharedVariable
    {
        public string startValue;

        [NonSerialized]
        private bool isUntouched  = false;

        public bool IsUntouched { get { return isUntouched; } }

        public override string Value
        {
            get
            {
                return base.Value;
            }

            set
            {
                isUntouched = false;
                base.Value = value;
            }
        }

        protected override string StartValue
        {
            get
            {
                return startValue;
            }
        }
    }
}
