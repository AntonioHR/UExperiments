﻿using System;
using UnityEngine;

namespace GRVM.UExperiment.Objects.SharedVariables
{
    public abstract class BaseSharedVariable<T> : ScriptableObject
    {
        
        protected abstract T StartValue { get; }

        [NonSerialized]
        protected T currentValue;

        public virtual T Value
        {
            get
            {
                return currentValue;
            }
            set
            {
                this.currentValue = value;
            }
        }

        private void OnEnable()
        {
            currentValue = StartValue;
        }
    }


    public abstract class FloatSharedVariable : BaseSharedVariable<float>
    {

    }
}