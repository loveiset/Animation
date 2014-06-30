using UnityEngine;
using System.Collections;

public class PlayerCollisions : MonoBehaviour {
    bool doorIsOpen = false;
    float doorTimer = 0.0f;
    GameObject currentDoor;

    public float doorOpenTime = 3.0f;
    public AudioClip doorOpenSound;
    public AudioClip doorShutSound;
    public AudioClip batteryCollect;


    /*
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "outpostDoor" && doorIsOpen == false)
        {
            currentDoor = hit.gameObject;
            Door(doorOpenSound, true, "dooropen", currentDoor);
        }
    }
     */

    void OpenDoor()
    {
        doorIsOpen = true;
        audio.PlayOneShot(doorOpenSound);
        GameObject myOutPost = GameObject.Find("outpost");
        myOutPost.animation.Play("doorOpen");
    }

    void shutDoor()
    {
        audio.PlayOneShot(doorShutSound);
        doorIsOpen = false;
        GameObject myOutpost = GameObject.Find("outpost");
        myOutpost.animation.Play("doorshut");
    }

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "battery")
        {
            BatteryCollect.charge++;
            audio.PlayOneShot(batteryCollect);
            Destroy(collisionInfo.gameObject);
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (doorIsOpen)
        {
            doorTimer += Time.deltaTime;
            if (doorTimer > doorOpenTime)
            {
                Door(doorShutSound, false, "doorshut", currentDoor);
                doorTimer = 0.0f;
            }
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5.0f))
        {
            if (hit.collider.gameObject.tag == "outpostDoor" && doorIsOpen == false && BatteryCollect.charge >= 4)
            {
                currentDoor = hit.collider.gameObject;
                Door(doorOpenSound, true, "dooropen", currentDoor);
                GameObject.Find("Battery GUI").GetComponent<GUITexture>().enabled = false;
            }
            else if (hit.collider.gameObject.tag == "outpostDoor" && doorIsOpen == false && BatteryCollect.charge < 4)
            {
                GameObject.Find("Battery GUI").GetComponent<GUITexture>().enabled = true;
                TextHints.message = "The door seems to need more power..";
                TextHints.textOn = true;
            }
        }
	}

    void Door(AudioClip aClip, bool openCheck, string animName, GameObject thisDoor)
    {
        audio.PlayOneShot(aClip);
        doorIsOpen = openCheck;
        thisDoor.transform.parent.animation.Play(animName);
    }
}