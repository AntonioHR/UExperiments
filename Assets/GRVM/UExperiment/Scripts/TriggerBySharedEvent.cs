using GRVM.UExperiment.Objects;
using UnityEngine;
using UnityEngine.Events;

public class TriggerBySharedEvent : MonoBehaviour {
    public UnityEvent FiredEvent;
    
    public SharedEvent ListenedEvent;

    private void Awake()
    {
        ListenedEvent.Subscribe(FireIt);
    }

    private void FireIt()
    {
        FiredEvent.Invoke();
    }
}
