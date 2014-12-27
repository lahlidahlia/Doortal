using UnityEngine;
using System.Collections;

public class Intro4Contextual : MonoBehaviour {
    GUIText text;
    private bool activated = false;
    private Color currentColor;
    public float colorTransSpeed;

    // Update is called once per frame
    void Start() {
        text = GetComponent<GUIText>();
        text.material.color = new Color(1, 1, 1, 0f);
        currentColor = text.material.color;
    }
    void Update() {
        if (Global.PlayerColor1 != Color.white && Global.PlayerColor2 != Color.white && !activated) {
            currentColor.a = 1;
            activated = true;
        }
        if (activated && Input.GetButtonDown("PlaceDoor")) {
            currentColor.a = 0;
        }

        text.material.color = Color.Lerp(text.material.color, currentColor, colorTransSpeed * Time.deltaTime);
    }
}
