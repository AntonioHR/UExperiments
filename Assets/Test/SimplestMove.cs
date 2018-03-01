using UnityEngine;

public class SimplestMove : MonoBehaviour {
    public float speed = 5.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.right * Input.GetAxis("Horizontal") * speed * Time.time;
	}
}
