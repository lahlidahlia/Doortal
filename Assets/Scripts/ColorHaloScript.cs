using UnityEngine;
using System.Collections;

public class ColorHaloScript : MonoBehaviour {
    public bool halo1;
    public int spinRate; //Rate at which color halo spins
    private SpriteRenderer spriteRenderer;
    private Color currentColor;

    // Use this for initialization
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        if (halo1) {
            //currentColor = Global.PlayerColor1;
            currentColor = Global.PlayerColor1;
        } else {
            currentColor = Global.PlayerColor2;
        }
        if (currentColor != Color.white) { //If the halo has a color
            spriteRenderer.color = new Color(currentColor.r, currentColor.g, currentColor.b, 0.5f);
        } else {
            spriteRenderer.color = new Color(0, 0, 0, 0);
        }
        transform.rotation = Quaternion.Euler(new Vector3(0,0, transform.rotation.eulerAngles.z + spinRate));
    }
}
