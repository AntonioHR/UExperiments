using UnityEngine;

namespace GRVM.UExperiment.Objects.SharedVariables
{

    [CreateAssetMenu]
    public class SimpleFloatVar : FloatSharedVariable
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
