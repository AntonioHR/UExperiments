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
            TryRunNextEvent();
        }

        private void TryRunNextEvent()
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
            }
        }
    }
}