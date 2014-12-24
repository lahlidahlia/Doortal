using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {
    SpriteRenderer spriteRenderer;
    public Color color;
    public Sprite GreenDoor;
    public Sprite BlueDoor;
    public Sprite RedDoor;
    public Sprite WhiteDoor;
	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = WhiteDoor;
        //if (color == Color.green) {
        //    spriteRenderer.sprite = GreenDoor;
        //}
        //if (color == Color.blue) {
        //    spriteRenderer.sprite = BlueDoor;
        //}
        //if (color == Color.red) {
        //    spriteRenderer.sprite = RedDoor;
        //}
        //if (color == Color.white) {
        //    spriteRenderer.sprite = WhiteDoor;
        //}
	}
	
	// Update is called once per frame
	void Update () {
        //if (Global.PlayerColor1 == color){ //If the player has the same color as the door
        //    collider2D.isTrigger = true;        //Turn the door into trigger (i.e. the player can walk through it)
        //    gameObject.layer = 11; //Use a layer that let light through
        //}
        //else {
        //    collider2D.isTrigger = false;
        //    gameObject.layer = 12; //Use a layer that blocks light
        //}
	}


}
