﻿using UnityEngine;

namespace GRVM.UExperiment.Objects.SharedVariables
{

    [CreateAssetMenu]
    public class AccuracyFloatVariable : FloatSharedVariable
    {
        private float hits = 0;
        private float hitsAndMisses = 0;
        protected override float StartValue
        {
            get
            {
                return 0;
            }
        }

        public void OnHit()
        {
            hits++;
            hitsAndMisses++;
            UpdateVal();
        }
        public void OnMiss()
        {
            hitsAndMisses++;
            UpdateVal();
        }

        private void UpdateVal()
        {
            Value = hits / hitsAndMisses;
        }
    }
}
