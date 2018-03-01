using GRVM.UExperiment.Objects;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextForCurrentStage : MonoBehaviour {

    public Session session;

    private Text text;
    
	void Awake () {
        text = GetComponent<Text>();	
	}
	
	// Update is called once per frame
	void Update () {
        var stage = session.CurrentStage;
        if (stage == null)
        {
            text.text = "No Stage";
        } else
        {
            text.text = stage.Id;
        }
	}
}
