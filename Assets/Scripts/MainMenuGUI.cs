using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MainMenuGUI : MonoBehaviour {
    public AudioClip beep;
    public GUISkin menuSkin;
    public float areaWidth;
    public float areaHeight;

    void OnGUI()
    {
        GUI.skin = menuSkin;
        float screenX = ((Screen.width * 0.5f) - (areaWidth * 0.5f));
        float screenY = ((Screen.height / 1.7f) - (areaHeight * 0.5f));

        GUILayout.BeginArea(new Rect(screenX, screenY, areaWidth, areaHeight));
        if (GUILayout.Button("Back"))
        {
            StartCoroutine(OpenLevel("Menu"));
        }
        GUILayout.EndArea();
    }

    IEnumerator OpenLevel(string level)
    {
        audio.PlayOneShot(beep);
        yield return new WaitForSeconds(0.35f);
        Application.LoadLevel(level);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

