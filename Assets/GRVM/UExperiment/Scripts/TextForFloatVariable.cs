using GRVM.UExperiment.Objects.SharedVariables;
using UnityEngine;
using UnityEngine.UI;

namespace GRVM.UExperiment.Scripts
{
    [RequireComponent(typeof (Text))]
    public class TextForFloatVariable : MonoBehaviour
    {
        private Text text;

        public string format;
        public FloatSharedVariable var;

        private void Awake()
        {
            text = GetComponent<Text>();
        }

        private void Update()
        {
            if (format.Length == 0)
                text.text = var.Value.ToString();
            else
                text.text = string.Format(format, var.Value);
        }
    }
}
