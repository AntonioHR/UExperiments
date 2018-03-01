using UnityEngine;

namespace GRVM.UExperiment.Objects.SharedVariables
{

    [CreateAssetMenu]
    public class SimpleFloatVariable : FloatSharedVariable
    {
        public float startValue;

        protected override float StartValue
        {
            get
            {
                return startValue;
            }
        }
    }

}
