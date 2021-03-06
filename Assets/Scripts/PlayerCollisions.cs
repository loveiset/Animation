﻿using UnityEngine;
using System.Collections;

public class PlayerCollisions : MonoBehaviour {
    bool doorIsOpen = false;
    bool haveMatches = false;
    float doorTimer = 0.0f;
    GameObject currentDoor;
    public GameObject matchGUI;

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

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject == GameObject.Find("campfire"))
        {
            if (haveMatches)
            {
                haveMatches = false;
                StartCoroutine(LightFire());
            }
            else
            {
                TextHints.textOn = true;
                TextHints.message = "I need some matches to light this camp fire..";
            }
        }

        GameObject crosshairObj = GameObject.Find("Crosshair");
        GUITexture crosshair = crosshairObj.GetComponent<GUITexture>();
        if (hit.collider == GameObject.Find("mat").collider)
        {
            CoconutThrow.canThrow = true;
            crosshair.enabled = true;
            TextHints.textOn = true;
            TextHints.message = "Knock down all 3 at once to win a battery";
            Vector3 lastPosition = GameObject.Find("TextHit GUI").transform.position;
            lastPosition.y = 0.2f;
            GameObject.Find("TextHit GUI").transform.position = lastPosition;
        }
        else
        {
            CoconutThrow.canThrow = false;
            crosshair.enabled = false;
            Vector3 lastPosition = GameObject.Find("TextHit GUI").transform.position;
            lastPosition.y = 0.5f;
            GameObject.Find("TextHit GUI").transform.position = lastPosition;
        }
    }

    IEnumerator LightFire()
    {
        GameObject campfire = GameObject.Find("campfire");
        AudioSource campSound = campfire.GetComponent<AudioSource>();
        campSound.Play();

        GameObject flames = GameObject.Find("FireSystem");
        ParticleEmitter flameEmitter = flames.GetComponent<ParticleEmitter>();
        flameEmitter.emit = true;

        GameObject smoke = GameObject.Find("SmokeSystem");
        ParticleEmitter smokeEmitter = smoke.GetComponent<ParticleEmitter>();
        smokeEmitter.emit = true;

        Destroy(GameObject.Find("MatchGUIPrefab"));

        TextHints.textOn = true;
        TextHints.message = "You lit the fire, you'll survive, well done!";
        yield return new WaitForSeconds(5.0f);
        Application.LoadLevel("Menu");
    }

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
        if (collisionInfo.gameObject.name == "matchbox")
        {
            Destroy(collisionInfo.gameObject);
            haveMatches = true;
            audio.PlayOneShot(batteryCollect);
            GameObject matchGUIobj = Instantiate(matchGUI, new Vector3(0.15f, 0.1f, 0.0f), transform.rotation) as GameObject;
            matchGUIobj.name = matchGUI.name;
            Debug.Log(matchGUI.name);
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