using UnityEngine;

namespace GRVM.UExperiment.Objects.SharedVariables
{
    [CreateAssetMenu]
    public class TimerFloatVariable : FloatSharedVariable
    {
        private enum State { PreStart, Started, Ended}

        private float startTime;
        private float endTime;

        private State state = State.PreStart;

        protected override float StartValue
        {
            get
            {
                return 0;
            }
        }

        public override float Value
        {
            get
            {
                switch (state)
                {
                    case State.PreStart:
                        return 0;
                    case State.Started:
                        return Time.time - startTime;
                    case State.Ended:
                        return endTime - startTime;
                    default:
                        throw new System.NotImplementedException();
                }
            }

            set
            {
                Debug.LogError("Should not try to set a timer value manually");
            }
        }

        public void Start()
        {
            Debug.Assert(state == State.PreStart);
            startTime = Time.time;
            state = State.Started;
        }

        public void Stop()
        {
            Debug.Assert(state == State.Started);
            endTime = Time.time;
            state = State.Ended;
        }
    }
}
