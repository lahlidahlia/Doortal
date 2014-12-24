using UnityEngine;
using System.Collections;

public class ColorPlateScript : MonoBehaviour {
    /*Script used to determine the color of the plate. Change the plate's sprite and not the plate's color. plate color is dependent on its sprite*/
    public Color color;

    
    public Sprite RedPlate;
    public Sprite GreenPlate;
    public Sprite BluePlate;
    public Sprite CyanPlate;
    public Sprite YellowPlate;
    public Sprite MagentaPlate;
    public Sprite WhitePlate;

    public ParticleSystem part_ColorPlate;
	// Use this for initialization
	void Start () {
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
        if (spriteRenderer.sprite == CyanPlate)
        {
            color = Color.cyan;
        }
        if (spriteRenderer.sprite == YellowPlate)
        {
            color = new Color(1,1,0);
        }
        if (spriteRenderer.sprite == MagentaPlate)
        {
            color = Color.magenta;
        }
        if (spriteRenderer.sprite == WhitePlate)
        {
            color = Color.white;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        { //If stepping on a colorplate
            Debug.Log("Stepped on plate!");
            bool colorChanged = false;
            Animator anim = col.GetComponent<Animator>();
            if (Global.colorSelected){ //If slot 2 has white it will default to slot 2
                if(color != Global.PlayerColor2 && color != Global.PlayerColor1){ //In order to avoid having both colors in the inventory
                    Global.PlayerColor1 = color;
                    colorChanged = true;
                }
            }
            else {
                if (color != Global.PlayerColor1 && color != Global.PlayerColor2){
                    Global.PlayerColor2 = color;
                    colorChanged = true;
                }
            }
            if (colorChanged) {   
                ParticleSystem part = Instantiate(part_ColorPlate, col.transform.position, Quaternion.identity) as ParticleSystem;
                part.startColor = color;
                anim.SetTrigger("TouchPlate");
            }
        }
    }
}
