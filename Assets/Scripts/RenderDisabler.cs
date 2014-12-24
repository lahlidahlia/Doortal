using UnityEngine;
using System.Collections;

public class RenderDisabler : MonoBehaviour {
    //This script is used to disable the object's renderer every update for player POV purpose
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        renderer.enabled = false;
	}
}
