using System;
using System.Collections.Generic;
using UnityEngine;

namespace GRVM.UExperiment.Objects.SharedVariables
{
    [CreateAssetMenu]
    public class SimpleCounterVariable : IntSharedVariable
    {
        public int startingValue;

        public List<CounterTrigger> triggers;

        protected override int StartValue
        {
            get
            {
                return startingValue;
            }
        }

        public override int Value
        {
            get
            {
                return base.Value;
            }

            set
            {
                base.Value = value;
                foreach (var t in triggers)
                {
                    t.Check(value);
                }
            }
        }

        public void AddOne()
        {
            Value++;
        }
        public void SubtractOne()
        {
            Value--;
        }


        public void Add(int change)
        {
            Value += change;
        }
        public void Subtract(int change)
        {
            Value -= change;
        }


        [Serializable]
        public class CounterTrigger
        {
            public SharedEvent ev;
            public Comparison comp;
            public int value;

            public void Check(int currentValue)
            {
                if(IsTrueFor(currentValue))
                {
                    ev.Fire();
                }
            }

            public bool IsTrueFor(int currentValue)
            {
                switch (comp)
                {
                    case Comparison.GreaterThan:
                        return currentValue > value;
                    case Comparison.Equal:
                        return currentValue == value;
                    case Comparison.LessThan:
                        return currentValue < value;
                    default:
                        throw new NotImplementedException();
                }
            }

            public enum Comparison
            {
                GreaterThan,
                Equal,
                LessThan
            }
        }
    }
}
