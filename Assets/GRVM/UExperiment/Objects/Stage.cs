using GRVM.UExperiment.Objects.SharedVariables;
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

        private State state = State.NotStarted;
        private float startTime;
        private float endTime;




        [SerializeField]
        protected string id;

        public AccuracyFloatVariable accuracy;
        public TimerFloatVariable timer;

        public Event Started;
        public Event Finished;




        public string Id { get { return id; } }



        public void Run()
        {
            Debug.Assert(state == State.NotStarted);
            timer.Start();
            Started.Fire();
        }

        public void Finish()
        {
            timer.Stop();
            Finished.Fire();
        }
    }
}
