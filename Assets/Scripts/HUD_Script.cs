using UnityEngine;
using System.Collections;

public class HUD_Script : MonoBehaviour {
    public bool isColor1; //Check if this HUD is used for color 1 or color 2
    private SpriteRenderer spriteRenderer;

    public Color selectedBorderColor; //The color of the selected color's border
    public Color defaultBorderColor; //The color of a normal border
    

    //public Transform redBorder;  
    //public Transform greenBorder;
    //public Transform blueBorder;
    //public Transform cyanBorder;
    //public Transform yellowBorder;
    //public Transform magentaBorder;
    public Sprite wheel_R;
    public Sprite wheel_G;
    public Sprite wheel_B;
    public Sprite wheel_C;
    public Sprite wheel_Y;
    public Sprite wheel_M;

    public Sprite wheel_RG;
    public Sprite wheel_RB;
    public Sprite wheel_RC;
    public Sprite wheel_RY;
    public Sprite wheel_RM;

    public Sprite wheel_GR;
    public Sprite wheel_GB;
    public Sprite wheel_GC;
    public Sprite wheel_GY;
    public Sprite wheel_GM;

    public Sprite wheel_BG;
    public Sprite wheel_BR;
    public Sprite wheel_BC;
    public Sprite wheel_BY;
    public Sprite wheel_BM;

    public Sprite wheel_CG;
    public Sprite wheel_CB;
    public Sprite wheel_CR;
    public Sprite wheel_CY;
    public Sprite wheel_CM;

    public Sprite wheel_YG;
    public Sprite wheel_YB;
    public Sprite wheel_YR;
    public Sprite wheel_YC;
    public Sprite wheel_YM;

    public Sprite wheel_MG;
    public Sprite wheel_MB;
    public Sprite wheel_MR;
    public Sprite wheel_MC;
    public Sprite wheel_MY;
    public Sprite wheel_Default;

    public Transform redDot;
    public Transform greenDot;
    public Transform blueDot;
    public Transform cyanDot;
    public Transform yellowDot;
    public Transform magentaDot;

    


	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        
        //Choosing which color wheel is displayed, depending on which color is selected
        //Red
        //Debug.Log(Global.colorSelected);
        if (Global.PlayerColor1 == Color.white && Global.PlayerColor2 == Color.white)
        {
            spriteRenderer.sprite = wheel_Default;
        }

        if (Global.PlayerColor1 == Color.red && Global.PlayerColor2 == Color.white)
        {
            spriteRenderer.sprite = wheel_R;
        }
        //else {
        //    redBorder.renderer.enabled = false; //Turn off border if the player doesn't have this color
        //}  
        //Blue
        if (Global.PlayerColor1 == Color.blue && Global.PlayerColor2 == Color.white){
            spriteRenderer.sprite = wheel_B;
        }
        //else {
        //    blueBorder.renderer.enabled = false;
        //}
        //Green
        if (Global.PlayerColor1 == Color.green && Global.PlayerColor2 == Color.white)
        {
            spriteRenderer.sprite = wheel_G;
        }
        //else {
        //    greenBorder.renderer.enabled = false;
        //}
        //Cyan
        if (Global.PlayerColor1 == Color.cyan && Global.PlayerColor2 == Color.white)
        {
            spriteRenderer.sprite = wheel_C;
        }
        //else {
        //    cyanBorder.renderer.enabled = false;
        //}
        //Yellow
        if (Global.PlayerColor1 == new Color(1, 1, 0) && Global.PlayerColor2 == Color.white)
        {
            spriteRenderer.sprite = wheel_Y;
        }
        //else {
        //    yellowBorder.renderer.enabled = false;
        //}
        //Magenta
        if (Global.PlayerColor1 == Color.magenta && Global.PlayerColor2 == Color.white){
            spriteRenderer.sprite = wheel_M;

        }
        //else {
        //    magentaBorder.renderer.enabled = false;
        //}


        //Red + other colors
        if (Global.PlayerColor1 == Color.red && Global.PlayerColor2 == Color.green)
        {
            spriteRenderer.sprite = wheel_RG;
        }
        if (Global.PlayerColor1 == Color.red && Global.PlayerColor2 == Color.blue)
        {
            spriteRenderer.sprite = wheel_RB;
        }
        if (Global.PlayerColor1 == Color.red && Global.PlayerColor2 == Color.cyan)
        {
            spriteRenderer.sprite = wheel_RC;
        }
        if (Global.PlayerColor1 == Color.red && Global.PlayerColor2 == new Color(1, 1, 0))
        {
            spriteRenderer.sprite = wheel_RY;
        }
        if (Global.PlayerColor1 == Color.red && Global.PlayerColor2 == Color.magenta)
        {
            spriteRenderer.sprite = wheel_RM;
        }

        //Green + other colors
        if (Global.PlayerColor1 == Color.green && Global.PlayerColor2 == Color.red)
        {
            spriteRenderer.sprite = wheel_GR;
        }
        if (Global.PlayerColor1 == Color.green && Global.PlayerColor2 == Color.blue)
        {
            spriteRenderer.sprite = wheel_GB;
        }
        if (Global.PlayerColor1 == Color.green && Global.PlayerColor2 == Color.cyan)
        {
            spriteRenderer.sprite = wheel_GC;
        }
        if (Global.PlayerColor1 == Color.green && Global.PlayerColor2 == new Color(1, 1, 0))
        {
            spriteRenderer.sprite = wheel_GY;
        }
        if (Global.PlayerColor1 == Color.green && Global.PlayerColor2 == Color.magenta)
        {
            spriteRenderer.sprite = wheel_GM;
        }

        //Blue + other colors
        if (Global.PlayerColor1 == Color.blue && Global.PlayerColor2 == Color.green)
        {
            spriteRenderer.sprite = wheel_BG;
        }
        if (Global.PlayerColor1 == Color.blue && Global.PlayerColor2 == Color.red)
        {
            spriteRenderer.sprite = wheel_BR;
        }
        if (Global.PlayerColor1 == Color.blue && Global.PlayerColor2 == Color.cyan)
        {
            spriteRenderer.sprite = wheel_BC;
        }
        if (Global.PlayerColor1 == Color.blue && Global.PlayerColor2 == new Color(1, 1, 0))
        {
            spriteRenderer.sprite = wheel_BY;
        }
        if (Global.PlayerColor1 == Color.blue && Global.PlayerColor2 == Color.magenta)
        {
            spriteRenderer.sprite = wheel_BM;
        }

        //Cyan + other colors
        if (Global.PlayerColor1 == Color.cyan && Global.PlayerColor2 == Color.green)
        {
            spriteRenderer.sprite = wheel_CG;
        }
        if (Global.PlayerColor1 == Color.cyan && Global.PlayerColor2 == Color.blue)
        {
            spriteRenderer.sprite = wheel_CB;
        }
        if (Global.PlayerColor1 == Color.cyan && Global.PlayerColor2 == Color.red)
        {
            spriteRenderer.sprite = wheel_CR;
        }
        if (Global.PlayerColor1 == Color.cyan && Global.PlayerColor2 == new Color(1, 1, 0))
        {
            spriteRenderer.sprite = wheel_CY;
        }
        if (Global.PlayerColor1 == Color.cyan && Global.PlayerColor2 == Color.magenta)
        {
            spriteRenderer.sprite = wheel_CM;
        }

        //Yellow + Magenta
        if (Global.PlayerColor1 == new Color(1, 1, 0) && Global.PlayerColor2 == Color.green)
        {
            spriteRenderer.sprite = wheel_YG;
        }
        if (Global.PlayerColor1 == new Color(1, 1, 0) && Global.PlayerColor2 == Color.blue)
        {
            spriteRenderer.sprite = wheel_YB;
        }
        if (Global.PlayerColor1 == new Color(1, 1, 0) && Global.PlayerColor2 == Color.cyan)
        {
            spriteRenderer.sprite = wheel_YC;
        }
        if (Global.PlayerColor1 == new Color(1, 1, 0) && Global.PlayerColor2 == Color.red)
        {
            spriteRenderer.sprite = wheel_YR;
        }
        if (Global.PlayerColor1 == new Color(1, 1, 0) && Global.PlayerColor2 == Color.magenta)
        {
            spriteRenderer.sprite = wheel_YM;
        }

        //Magenta + others
        if (Global.PlayerColor1 == Color.magenta && Global.PlayerColor2 == Color.green)
        {
            spriteRenderer.sprite = wheel_MG;
        }
        if (Global.PlayerColor1 == Color.magenta && Global.PlayerColor2 == Color.blue)
        {
            spriteRenderer.sprite = wheel_MB;
        }
        if (Global.PlayerColor1 == Color.magenta && Global.PlayerColor2 == Color.cyan)
        {
            spriteRenderer.sprite = wheel_MC;
        }
        if (Global.PlayerColor1 == Color.magenta && Global.PlayerColor2 == new Color(1, 1, 0))
        {
            spriteRenderer.sprite = wheel_MY;
        }
        if (Global.PlayerColor1 == Color.magenta && Global.PlayerColor2 == Color.red)
        {
            spriteRenderer.sprite = wheel_MR;
        }




        //When a color is selected, a dot appear on it
        //Red
        if ((Global.PlayerColor1 == Color.red && Global.colorSelected) || (Global.PlayerColor2 == Color.red && !Global.colorSelected))
        {
            redDot.renderer.enabled = true;
        }
        else
        {
            redDot.renderer.enabled = false;
        }

        //Blue
        if ((Global.PlayerColor1 == Color.blue && Global.colorSelected) || (Global.PlayerColor2 == Color.blue && !Global.colorSelected))
        {
            blueDot.renderer.enabled = true;
        }
        else
        {
            blueDot.renderer.enabled = false;
        }

        //Green
        if ((Global.PlayerColor1 == Color.green && Global.colorSelected) || (Global.PlayerColor2 == Color.green && !Global.colorSelected))
        {
            greenDot.renderer.enabled = true; 
        }
        else
        {
            greenDot.renderer.enabled = false;
        }

        //Cyan
        if ((Global.PlayerColor1 == Color.cyan && Global.colorSelected) || (Global.PlayerColor2 == Color.cyan && !Global.colorSelected))
        {
            cyanDot.renderer.enabled = true;
        }
        else
        {
            cyanDot.renderer.enabled = false;
        }

        //Yellow
        if ((Global.PlayerColor1 == new Color(1, 1, 0) && Global.colorSelected) || (Global.PlayerColor2 == new Color(1, 1, 0) && !Global.colorSelected))
        {
            
            yellowDot.renderer.enabled = true; 
        }
        else
        { 
            yellowDot.renderer.enabled = false;
        }

        //Magenta
        if ((Global.PlayerColor1 == Color.magenta && Global.colorSelected) || (Global.PlayerColor2 == Color.magenta && !Global.colorSelected))
        {
            magentaDot.renderer.enabled = true; 
        }
        else
        {
            magentaDot.renderer.enabled = false;
        }
        //if (!isColor1) { 
        //    spriteRenderer.color = Global.PlayerColor2; 

        //    if (!Global.colorSelected) { 
        //        border.renderer.enabled = true;
        //    }
        //    else{
        //        border.renderer.enabled = false;
        //    }
        //}

	}
}
