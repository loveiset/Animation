using UnityEngine;
using System.Collections;

public class MainMenuBtns : MonoBehaviour {
    public string levelToLoad;
    public Texture2D normalTexture;
    public Texture2D rollOverTexture;
    public AudioClip beep;
    public bool QuitButton = false;


	// Use this for initialization
	void Start () {
	
	}

    void OnMouseEnter()
    {
        guiTexture.texture = rollOverTexture;
    }

    void OnMouseExit()
    {
        guiTexture.texture = normalTexture;
    }

    IEnumerator OnMouseUp()
    {
        audio.PlayOneShot(beep);
        yield return new WaitForSeconds(0.35f);
        if (QuitButton)
        {
            Application.Quit();
        }
        else 
        { 
            Application.LoadLevel(levelToLoad); 
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
