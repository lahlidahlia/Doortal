using UnityEngine;
using System.Collections;

public class ResetScript : MonoBehaviour {

    void Update() {
        if (Input.GetButton("ResetLevel")) {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    void OnGUI() {
        if (GUI.Button(new Rect(27, 40, 120, 30), "RESTART LEVEL")) {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}