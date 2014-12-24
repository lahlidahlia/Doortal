using UnityEngine;
using System.Collections;

public class ResetScript : MonoBehaviour {

    void Update() {
        if (Input.GetButton("ResetLevel")) {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    //void OnGUI () {
    //        if (GUI.Button (new Rect (20,40,120,140), "MAIN MENU!")) {
    //            Application.LoadLevel (name: "Level 0");
    //        }
    //    }
	}