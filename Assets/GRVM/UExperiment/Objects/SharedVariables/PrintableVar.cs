using System;
using UnityEngine;

namespace GRVM.UExperiment.Objects.SharedVariables
{
    [Serializable]
    public class PrintableVar
    {
        public enum DataType { Float, Integer }

        public DataType type;

        public FloatSharedVariable floatVar;
        public IntSharedVariable intVar;


        public float FloatValue
        {
            get
            {
                Debug.Assert(type == DataType.Float);
                return floatVar.Value;
            }
        }
        public int IntValue
        {
            get
            {
                Debug.Assert(type == DataType.Integer);
                return intVar.Value;
            }
        }

        public string PrintableValue
        {
            get
            {
                switch (type)
                {
                    case DataType.Float:
                        return FloatValue.ToString();
                    case DataType.Integer:
                        return IntValue.ToString();
                    default:
                        throw new NotImplementedException();
                }
            }
        }
    }
}
