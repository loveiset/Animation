using UnityEngine;
using System.Collections;

public class CoconutThrow : MonoBehaviour {
    public AudioClip throwSound;
    public Rigidbody coconutObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetButtonUp("Fire1"))
        {
            audio.PlayOneShot(throwSound);
            Rigidbody newCoconut = Instantiate(coconutObject, transform.position, transform.rotation) as Rigidbody;
            newCoconut.name = "coconut";
        }
	}
}
