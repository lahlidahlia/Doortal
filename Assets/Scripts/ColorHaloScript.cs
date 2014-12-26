using UnityEngine;
using System.Collections;

public class ColorHaloScript : MonoBehaviour {
    public bool halo1;
    public int spinRate; //Rate at which color halo spins
    private SpriteRenderer spriteRenderer;
    private Color currentColor;
    public float colorTransSpeed;

    // Use this for initialization
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        if (halo1) { //Halo 1
            if (Global.PlayerColor1 != Color.white) { //If color 1 has a color
                currentColor = Global.PlayerColor1;
            }
            else {
                currentColor = Color.white;
            }
        }
        else { //Halo 2
            if (Global.PlayerColor2 != Color.white) { //If color 2 has a color
                currentColor = Global.PlayerColor2;
            }
            else if (Global.PlayerColor1 != Color.white) { //If color 1 has a color
                currentColor = Global.PlayerColor1;
            }
            else {
                currentColor = Color.white;
            }
        }
        if (Global.PlayerColor1 == Color.white && Global.PlayerColor2 == Color.white) {
            currentColor.a = 0; //Make halo transparent
        }
        else if (Global.PlayerColor1 != Color.white && Global.PlayerColor2 == Color.white) {
            currentColor.a = 0.5f;
        }
        else if (Global.PlayerColor1 != Color.white && Global.PlayerColor2 != Color.white) {
            if (Global.colorSelected && halo1) {
                currentColor.a = 1f;
            }
            else if (!Global.colorSelected && !halo1) {
                currentColor.a = 1f;
            }
            else {
                currentColor.a = 0.2f;
            }
        }

        spriteRenderer.color = Color.Lerp(spriteRenderer.color, currentColor, colorTransSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z + spinRate));
    }
}
