using UnityEngine;
using System.Collections;

public class LightControlScript : MonoBehaviour
{
    public Color color;

    public bool lightToggle;       //false is low, true is high
    public float lightToggleLow;    //Light range when toggling between them (High light range increase lighting)
    public float lightToggleHigh;

    public Color lightRed;
    public Color lightGreen;
    public Color lightBlue;
    public Color lightMagenta;
    public Color lightCyan;
    public Color lightYellow;
    public Color lightDefault;

    private Light light;
    // Use this for initialization
    void Start(){
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        //Light color 
        //color = Global.PlayerColorCombined;

        //if (color == Color.blue)
        //{
        //    light.color = lightBlue;
        //}
        //else if (color == Color.red)
        //{
        //    light.color = lightRed;
        //}
        //else if (color == Color.green)
        //{
        //    light.color = lightGreen;
        //}
        //else if (color == Color.magenta)
        //{
        //    light.color = lightMagenta;
        //}
        //else if (color == Color.cyan)
        //{
        //    light.color = lightCyan;
        //}
        //else if (color == new Color(1, 1, 0, 1)) //Because Color.yellow is (1, 0.92, 0.016, 1) but we want to check for pure yellow
        //{
        //    light.color = lightYellow;
        //}
        //else
        //{
        //    light.color = lightDefault;
        //}


        //Light Toggle
        if (lightToggle == false){      //If light is off
            light.range = lightToggleLow;      
            if (Input.GetButtonDown("LightToggle")){
                lightToggle = true;
            }
        }
        else{         //If light is on
            light.range = lightToggleHigh;
            if (Input.GetButtonDown("LightToggle")){
                lightToggle = false;
            }
        }
    }
}
