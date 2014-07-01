using UnityEngine;
using System.Collections;

public class CoconutWin : MonoBehaviour {
    public static int targets = 0;
    bool hasWon = false;
    public AudioClip win;
    public GameObject battery;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (targets == 3 && hasWon == false)
        {
            targets = 0;
            audio.PlayOneShot(win);
            Instantiate(battery, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), transform.rotation);
            hasWon = true;
        }
	}
}
