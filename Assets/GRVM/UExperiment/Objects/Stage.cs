using GRVM.UExperiment.Objects.SharedVariables;
using System;
using UnityEngine;

namespace GRVM.UExperiment.Objects
{
    [CreateAssetMenu()]
    public class Stage : ScriptableObject
    {
        enum State
        {
            NotStarted, Running, Ended
        }

        [NonSerialized]
        private State state = State.NotStarted;




        [SerializeField]
        protected string id;

        public AccuracyFloatVariable accuracy;
        public TimerFloatVariable timer;

        public SharedEvent Started;
        public SharedEvent Finished;
        


        public string Id { get { return id; } }



        public void Run()
        {
            Debug.Assert(state == State.NotStarted);
            state = State.Running;
            timer.Start();
            Started.Fire();
        }

        public void Finish()
        {
            Debug.Assert(state == State.Running);
            state = State.Ended;
            timer.Stop();
            Finished.Fire();
        }
    }
}
