using UnityEngine;
using System.Collections;

public class Plot1 : MonoBehaviour {
    public Component a;
    private GUIText text;
    private int counter;
    string[] strings;
    
	// Use this for initialization
	void Start () {
        text = GetComponent<GUIText>();
        counter = 0;
        string str = "Of all the people who go to my school...: None of them are as interesting as the people in Dating Sim XX Forever. I feel like I have a life in this game. WHAT! No! I said something wrong again! I almost had her! The most difficult girl in the whole game too!";
        strings = stringsToDialogue(str, 68, 8);
        //strings = str.Split(':');
	}
	
	// Update is called once per frame
	void Update () {
        if (counter > strings.Length - 1) {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
        else if (Input.GetButtonDown("DialogueScroll")) {
            counter += 1;
        }
        text.text = strings[counter];


        


        //switch (counter) { 
        //    case 0:
        //        text.text = "The Worst Dev. Team Ever Presents...";
        //        break;
        //    case 1:
        //        text.text = "Doortal";
        //        break;
        //    case 2:
        //        text.text = 
        //        break;
                    
        //}
	}
    
    string[] stringsToDialogue(string str, int lineLength, int lineAmnt) { 
        /*
         * split a large string into an array that contains strings that will fit in a dialogue box
         * lineLength : Maximum amount of characters each strings will contain
         * lineAmnt : Maximum amount of lines a dialogue box will support
         */
        string[] strings = str.Split(':');

        string newstr = "";

        foreach (string s in strings) {
            string ts = s;
            //if ((ts.Length - 1) / lineLength > lineAmnt) {
            //    ts = ts.Insert(lineLength * lineAmnt, ":");
            //}
            if (ts.Length > lineLength)
            {
                for (int i = Mathf.Min((ts.Length -1) /lineLength, lineLength*lineAmnt); i > 0; i--) {
                    ts = ts.Insert((lineLength * i) - 1, "\n");
                }
            }
            newstr += ts;
            newstr += ":";
        }

        string[] ret = newstr.Split(':');
        return ret;
    }
}
