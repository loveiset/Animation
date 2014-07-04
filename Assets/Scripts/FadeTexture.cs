using UnityEngine;
using System.Collections;

public class FadeTexture : MonoBehaviour {
    public Texture2D theTexture;
    float startTime;

    void OnLevelWasLoaded()
    {
        startTime = Time.time;
    }

	// Use this for initialization
	void Start () {
	
	}

    void OnGUI()
    {
        GUI.color = Color.white;
        Color tempColor = GUI.color;
        tempColor.a = Mathf.Lerp(1.0f, 0.0f, (Time.time - startTime));
        GUI.color = tempColor;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), theTexture);

    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time - startTime >= 3)
        {
            Destroy(gameObject);
        }
	
	}
}
