using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {
    public Sprite defaultSprite;
    public Sprite onHoverSprite;

    private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = defaultSprite;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseOver() {
        spriteRenderer.sprite = onHoverSprite;
    }
    void OnMouseExit() {
        spriteRenderer.sprite = defaultSprite;
    }
    void OnMouseDown() {
        if (tag == "CreditButton") { 
            //Credit screen transition
            Application.LoadLevel("-1-Credit");
        }
        if (tag == "StartButton") {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
        if (tag == "BackToMenuButton") {
            Application.LoadLevel("0-Main Menu");
        }
        if (tag == "ExitButton") {
            Application.Quit();
        }
    }
}
