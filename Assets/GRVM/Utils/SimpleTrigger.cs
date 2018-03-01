using UnityEngine;
using UnityEngine.Events;

namespace GRVM.Utils
{
    public class SimpleTrigger : MonoBehaviour
    {
        public UnityEvent Triggered;

        public GameObject requiredObject;

        public bool DisableAfterTrigger;


        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject == requiredObject)
                Trigger();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject == requiredObject)
                Trigger();
        }

        private void Trigger()
        {
            if (DisableAfterTrigger)
                enabled = false;

            Triggered.Invoke();
        }
    }
}
