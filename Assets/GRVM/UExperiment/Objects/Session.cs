using GRVM.UExperiment.Objects.SharedVariables;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GRVM.UExperiment.Objects
{
    [CreateAssetMenu()]
    public class Session : ScriptableObject
    {
        private enum State { NotStarted, Running, Finished }


        [NonSerialized]
        private int stageIndx = -1;

        [NonSerialized]
        private State state = State.NotStarted;



        public List<Stage> stages;
        
        public TimerFloatVariable Timer;

        public SharedEvent Finished;


        public Stage CurrentStage {
            get
            {
                return (state == State.Running) ? stages[stageIndx] : null;
            }
        }

        public void Run()
        {
            Debug.Assert(state == State.NotStarted);
            state = State.Running;
            Timer.Start();
            TryRunNextStage();
        }

        public void OnStageFinished()
        {
            stages[stageIndx].Finished.Unsubscribe(OnStageFinished);
            TryRunNextStage();
        }

        private void TryRunNextStage()
        {
            Debug.Assert(state == State.Running);
            

            stageIndx++;
            if(stageIndx >= stages.Count)
            {
                OnFinished();
            }
            else
            {
                stages[stageIndx].Run();
                stages[stageIndx].Finished.Subscribe(OnStageFinished);
            }
        }

        private void OnFinished()
        {
            state = State.Finished;
            Timer.Stop();
            Finished.Fire();
        }
    }
}