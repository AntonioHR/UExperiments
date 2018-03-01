using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ClickTrigger : MonoBehaviour {
    Collider col;

    public UnityEvent ev;


	// Use this for initialization
	void Start () {
        col = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            CheckMouseRaycast();
        }
    }

    private void CheckMouseRaycast()
    {
        RaycastHit result;
        if (col.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out result, float.PositiveInfinity))
        {
            ev.Invoke();
        }
    }
}
