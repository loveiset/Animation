using UnityEngine;
using System.Collections;

public class BatteryCollect : MonoBehaviour {
    public static int charge = 0;

    public Texture2D charge1tex;
    public Texture2D charge2tex;
    public Texture2D charge3tex;
    public Texture2D charge4tex;
    public Texture2D charge0tex;
    

	// Use this for initialization
	void Start () 
    {
        guiTexture.enabled = false;
        charge = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (charge == 1)
        {
            guiTexture.texture = charge1tex;
            guiTexture.enabled = true;
        }
        else if (charge == 2)
        {
            guiTexture.texture = charge2tex;
        }
        else if (charge == 3)
        {
            guiTexture.texture = charge3tex;
        }
        else if (charge >= 4)
        {
            guiTexture.texture = charge4tex;
        }
        else
        {
            guiTexture.texture = charge0tex;
        }
	}
}
