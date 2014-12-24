using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour {
    public Texture2D helpBox;
    public Texture2D xButton;
    public Vector2 helpBoxPos;
    public Vector2 helpBtnPos;
	// Use this for initialization
    private bool helpBoxOn = false;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI() { 
        Vector3 helpBtnPosition = Camera.main.ViewportToScreenPoint(helpBtnPos);
        Vector3 helpBoxPosition = Camera.main.ViewportToScreenPoint(new Vector2(0.2f, 0.2f));
        //Debug.Log(helpBtnPosition);
        if (GUI.Button(new Rect(helpBtnPosition.x, helpBtnPosition.y, 50, 50), "?"))
        {
            if (helpBoxOn)
            {
                helpBoxOn = false;
            }
            else{
                helpBoxOn = true; 
            }
            
        }
        if (helpBoxOn) {
            GUI.Label(new Rect(helpBoxPosition.x, helpBoxPosition.y, 500, 500), helpBox);
            if(GUI.Button(new Rect(helpBoxPosition.x - 15, helpBoxPosition.y - 15, 30, 30), xButton)){
                helpBoxOn = false;
            }
        }
        //Debug.Log(helpBoxOn);
        
    }
}
