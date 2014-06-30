using UnityEngine;
using System.Collections;

public class TextHints : MonoBehaviour {
    public static bool textOn = false;
    public static string message;
    float timer = 0.0f;

	// Use this for initialization
	void Start () 
    {
        timer = 0.0f;
        textOn = false;
        guiText.text = "";
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (textOn)
        {
            guiText.enabled = true;
            guiText.text = message;
            timer += Time.deltaTime;
        }
        if (timer >= 5)
        {
            textOn = false;
            guiText.enabled = false;
            timer = 0.0f;
        }
	}
}
