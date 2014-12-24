using UnityEngine;
using System.Collections;

public class GameCoverScript : MonoBehaviour {

    public float colorChangeSpeed;
    public float hue;
    public float saturation;
    private HSBColor hsb;
    private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
        //HSBColor.Test();
        
        spriteRenderer = GetComponent<SpriteRenderer>();


	}
	
	// Update is called once per frame
	void FixedUpdate () {
        hue += colorChangeSpeed;
        if (hue >= 1)
        {
            hue = 0;
        }
        hsb = HSBColor.FromColor(spriteRenderer.color);
        spriteRenderer.color = HSBColor.ToColor(new HSBColor(hue, saturation, 1));
	}

    //void OnGUI()
    //{
    //    if (GUI.Button(new Rect(300, 300, 200, 80), " Start Game!"))
    //    {
    //        Application.LoadLevel(Application.loadedLevel + 1);
    //    }
    //    //if (GUI.Button(new Rect(170, 40, 120, 140), "LEVEL 2!"))
    //    //{
    //    //    Application.LoadLevel(name: "Level 2");
    //    //}
    //    //if (GUI.Button(new Rect(320, 40, 120, 140), "LEVEL 3!"))
    //    //{
    //    //    Application.LoadLevel(name: "Level 3");
    //    //}
    //    //if (GUI.Button(new Rect(470, 40, 120, 140), "LEVEL 5!"))
    //    //{
    //    //    Application.LoadLevel(name: "Level 5");
    //    //}
    //    //if (GUI.Button(new Rect(620, 40, 120, 140), "MORE SOON!"))
    //    //{
    //    //
    //    //}
    //}
}
