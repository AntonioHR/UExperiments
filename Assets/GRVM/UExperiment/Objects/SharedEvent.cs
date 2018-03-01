using System;
using UnityEngine;

namespace GRVM.UExperiment.Objects
{
    [CreateAssetMenu]
    public class SharedEvent : ScriptableObject
    {
        private event Action ev;

        public void Fire()
        {
            if (ev != null)
                ev();
        }
        public void Subscribe(Action action)
        {
            ev += action;
        }

        public void Unsubscribe(Action action)
        {
            ev -= action;
        }
    }
}
