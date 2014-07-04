using UnityEngine;
using System.Collections;

public class Animator : MonoBehaviour {
    public float startPosition = -1.0f;
    public float endPosition = 0.5f;
    public float speed=1.0f;
    float startTime;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 tempPosition = transform.position;
        tempPosition.x = Mathf.Lerp(startPosition, endPosition, (Time.time - startTime) * speed);
        transform.position = tempPosition;
	
	}
}
