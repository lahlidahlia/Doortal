using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {
    public static int FPS = 60;
    //public enum COLOR { Blue = Color.blue, White = Color.white, Green = Color.green, Red = Color.red};
    public static Color PlayerColor1;
    public static Color PlayerColor2;
    public static Color PlayerColorCombined;
    public static bool colorSelected = true; //Determine which color is being selected right now. True for color1 false for color2
    //static int grid_size = 1; //How large each normal sized tiles are (e.g. walls are currently 1x1)


	// Use this for initialization
	void Start () {
        Application.targetFrameRate = FPS;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
