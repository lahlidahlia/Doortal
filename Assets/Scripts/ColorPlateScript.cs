using UnityEngine;
using System.Collections;

public class ColorPlateScript : MonoBehaviour {
    /*Script used to determine the color of the plate. Change the plate's sprite and not the plate's color. plate color is dependent on its sprite*/
    private Color color;


    public Sprite RedPlate;
    public Sprite GreenPlate;
    public Sprite BluePlate;
    public Sprite CyanPlate;
    public Sprite YellowPlate;
    public Sprite MagentaPlate;
    public Sprite WhitePlate;

    public ParticleSystem part_ColorPlate;
    public ParticleSystem part_ColorPlate_Combined;
    private ParticleSystem combinedColorParticle; //Particles that denote player combined color
    private Color currentColor;
    // Use this for initialization
    void Start() {
        combinedColorParticle = Instantiate(part_ColorPlate_Combined, transform.position, Quaternion.identity) as ParticleSystem;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == BluePlate) {
            color = Color.blue;
        }
        if (spriteRenderer.sprite == RedPlate) {
            color = Color.red;
        }
        if (spriteRenderer.sprite == GreenPlate) {
            color = Color.green;
        }
        if (spriteRenderer.sprite == CyanPlate) {
            color = Color.cyan;
        }
        if (spriteRenderer.sprite == YellowPlate) {
            color = new Color(1, 1, 0);
        }
        if (spriteRenderer.sprite == MagentaPlate) {
            color = Color.magenta;
        }
        if (spriteRenderer.sprite == WhitePlate) {
            color = Color.white;
        }
    }

    // Update is called once per frame
    void Update() {
        //TODO TODO TODO TODO
        combinedColorParticle.startColor = Global.PlayerColorCombined;
        if (Global.PlayerColor2 != Color.white || Global.PlayerColor1 == Global.PlayerColor2) {
            //Debug.Log("PlayerColor1 = " + Global.PlayerColor1.ToString());
            //Debug.Log("PlayerColor2 = " + Global.PlayerColor2.ToString());

            //Figure out the combined color when there is two different colors in the inventory
            if ((Global.PlayerColor1 == Color.red && Global.PlayerColor2 == Color.green) ||
                (Global.PlayerColor1 == Color.green && Global.PlayerColor2 == Color.red)) { //Red + green = yellow
                Global.PlayerColorCombined = new Color(1, 1, 0, 1);
            }
            else if ((Global.PlayerColor1 == Color.red && Global.PlayerColor2 == Color.blue) ||
                (Global.PlayerColor1 == Color.blue && Global.PlayerColor2 == Color.red)) { //Red + blue = magenta
                Global.PlayerColorCombined = Color.magenta;
            }
            else if ((Global.PlayerColor1 == Color.green && Global.PlayerColor2 == Color.blue) ||
                (Global.PlayerColor1 == Color.blue && Global.PlayerColor2 == Color.green)) { //green + blue = cyan
                Global.PlayerColorCombined = Color.cyan;
            }
            else if ((Global.PlayerColor1 == Color.magenta && Global.PlayerColor2 == new Color(1, 1, 0)) ||
                (Global.PlayerColor1 == new Color(1, 1, 0) && Global.PlayerColor2 == Color.magenta)) { //magenta + yellow = red
                Global.PlayerColorCombined = Color.red;
            }
            else if ((Global.PlayerColor1 == Color.cyan && Global.PlayerColor2 == new Color(1, 1, 0)) ||
                (Global.PlayerColor1 == new Color(1, 1, 0) && Global.PlayerColor2 == Color.cyan)) { //cyan + yellow = green
                Global.PlayerColorCombined = Color.green;
            }
            else if ((Global.PlayerColor1 == Color.cyan && Global.PlayerColor2 == Color.magenta) ||
                (Global.PlayerColor1 == Color.magenta && Global.PlayerColor2 == Color.cyan)) { //cyan + magenta = blue
                Global.PlayerColorCombined = Color.blue;
            }
            else {
                Global.PlayerColorCombined = Global.PlayerColor1;
            }
            //Combining the color into one slot
            if (Input.GetButtonDown("CombineColor")) {
                Global.PlayerColor1 = Global.PlayerColorCombined;
                Global.PlayerColor2 = Color.white;
            }
        }
        else {//If one color is white or both color is the same
            Global.PlayerColorCombined = Global.PlayerColor1;
        }

    }

    void OnTriggerEnter2D(Collider2D col)//When stepping on a colorplate
    {
        if (col.tag == "Player") //Verify that it is the player who stepped on it
        {
            Debug.Log("Stepped on plate!");
            bool colorChanged = false;
            Animator anim = col.GetComponent<Animator>();
            if (Global.colorSelected) { //If slot 2 has white it will default to slot 2
                if (color != Global.PlayerColor2 && color != Global.PlayerColor1) { //In order to avoid having both colors in the inventory
                    Global.PlayerColor1 = color;
                    colorChanged = true;
                }
            }
            else {
                if (color != Global.PlayerColor1 && color != Global.PlayerColor2) {
                    Global.PlayerColor2 = color;
                    colorChanged = true;
                }
            }
            if (colorChanged) {
                ParticleSystem particle = Instantiate(part_ColorPlate, col.transform.position, Quaternion.identity) as ParticleSystem; //Create the particle
                particle.startColor = color; //Set particle color
                anim.SetTrigger("TouchPlate");
            }
        }
    }
}
