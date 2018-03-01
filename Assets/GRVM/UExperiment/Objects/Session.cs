using GRVM.UExperiment.Objects.SharedVariables;
using System.Collections.Generic;
using UnityEngine;

namespace GRVM.UExperiment.Objects
{
    [CreateAssetMenu()]
    public class Session : ScriptableObject
    {
        private int stageIndx;

        private bool hasFinished = false;



        public List<Stage> stages;
        
        public TimerFloatVariable Duration;

        public Event Finished;



        public void Run()
        {
            stageIndx = -1;
            TryRunNextStage();
        }

        public void OnStageFinished()
        {
            stages[stageIndx].Finished.Unsubscribe(OnStageFinished);
            TryRunNextStage();
        }

        private void TryRunNextStage()
        {
            Debug.Assert(!hasFinished);
            

            stageIndx++;
            if(stageIndx >= stages.Count)
            {
                hasFinished = true;
                Finished.Fire();
            } else
            {
                stages[stageIndx].Run();
                stages[stageIndx].Finished.Subscribe(OnStageFinished);
            }
        }
    }
}