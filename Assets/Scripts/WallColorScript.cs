using UnityEngine;
using System.Collections;

public class WallColorScript : MonoBehaviour {
    /*Script used to determine the color of the wall. Change the wall's color and not the wall's sprite. Wall sprite is dependent on its color*/
    public Color color;
    public Sprite redWall;
    public Sprite greenWall;
    public Sprite blueWall;
    public Sprite magentaWall;
    public Sprite yellowWall;
    public Sprite cyanWall;
    public Sprite defaultWall;

    public SpriteRenderer spriteRenderer;

	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        if (color == Color.blue)
        {
            spriteRenderer.sprite = blueWall;
        }
        if (color == Color.red)
        {
            spriteRenderer.sprite = redWall;
        }
        if (color == Color.green)
        {
            spriteRenderer.sprite = greenWall;
        }
        if (color == Color.cyan)
        {
            spriteRenderer.sprite = cyanWall;
        }
        if (color == new Color(1,1,0))
        {
            spriteRenderer.sprite = yellowWall;
        }
        if (color == Color.magenta)
        {
            spriteRenderer.sprite = magentaWall;
        }
        if (color == Color.white)
        {
            spriteRenderer.sprite = defaultWall;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Global.PlayerColorCombined == color || Global.PlayerColor1 == color || Global.PlayerColor2 == color)
        { //If the player has the same color as the door
            collider2D.isTrigger = true;        //Turn the wall into trigger (i.e. the player can walk through it)
            gameObject.layer = 16; //Use a layer that let light through
        }
        else
        {
            collider2D.isTrigger = false;
            gameObject.layer = 15; //Use a layer that blocks light
        }
	}
}
