using System;
using UnityEngine;

namespace GRVM.UExperiment.Objects.SharedVariables
{
    [Serializable]
    public class PrintableVar
    {
        public enum DataType { Float, Integer, String }

        public DataType type;

        public string label;

        public StringSharedVariable stringVar;
        public FloatSharedVariable floatVar;
        public IntSharedVariable intVar;
        

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
                    case DataType.String:
                        return StringValue;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        private float FloatValue
        {
            get
            {
                Debug.Assert(type == DataType.Float);
                return floatVar.Value;
            }
        }
        private int IntValue
        {
            get
            {
                Debug.Assert(type == DataType.Integer);
                return intVar.Value;
            }
        }

        public string StringValue
        {
            get
            {
                Debug.Assert(type == DataType.String);
                return stringVar.Value;
            }
        }
    }
}
