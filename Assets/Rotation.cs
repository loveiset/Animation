using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        transform.rotation = Quaternion.Euler(0f, 0f,-45f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
