using UnityEngine;
using System.Collections;

public class HUD_Position : MonoBehaviour {
    //This script will place the HUD element onto the specified screen position
    public Vector2 viewPortPos;
    public Camera HUD_Cam;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = HUD_Cam.ViewportToWorldPoint(new Vector3(viewPortPos.x, viewPortPos.y, 1));
	}
}
