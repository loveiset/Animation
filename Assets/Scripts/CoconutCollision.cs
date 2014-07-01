using UnityEngine;
using System.Collections;

public class CoconutCollision : MonoBehaviour {
    public GameObject targetRoot;
    bool beenHit = false;
    float timer = 0.0f;
    public AudioClip hitSound;
    public AudioClip resetSound;

    void OnCollisionEnter(Collision theObject)
    {
        if (beenHit == false && theObject.gameObject.name == "coconut")
        {
            audio.PlayOneShot(hitSound);
            targetRoot.animation.Play("down");
            beenHit = true;
            CoconutWin.targets++;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (beenHit)
        {
            timer += Time.deltaTime;
        }
        if (timer > 3)
        {
            audio.PlayOneShot(resetSound);
            targetRoot.animation.Play("up");
            beenHit = false;
            CoconutWin.targets--;
            timer = 0.0f;
        }
	}
}
