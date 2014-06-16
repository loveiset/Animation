using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
    Vector3 camRot;

	// Use this for initialization
	void Start () 
    {
        Debug.Log(Vector3.up);
        Debug.Log(Quaternion.identity);
        camRot = Camera.main.transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () 
    {
        //camRot.y -= Input.GetAxis("Mouse X");
        //camRot.x += Input.GetAxis("Mouse Y");
        camRot.x = 50;
        //Debug.Log("x" + Input.GetAxis("Mouse X"));
        //Debug.Log("y" + Input.GetAxis("Mouse Y"));
        Camera.main.transform.eulerAngles = camRot;
        Debug.Log("transx"+Camera.main.transform.eulerAngles.x);
        this.transform.Rotate(Time.deltaTime * 30, Time.deltaTime * 30, Time.deltaTime * 30, Space.Self);
	}
}
