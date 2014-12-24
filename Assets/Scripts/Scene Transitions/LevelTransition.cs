using UnityEngine;
using System.Collections;

public class LevelTransition : MonoBehaviour 
{ 
	//Assuming were putting this on player
	
	void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log(other.tag);
		if(other.tag == "Goal"){ //Check if the player is standing on the right thing (because the player also uses this function against walls)
			Application.LoadLevel(Application.loadedLevel + 1); 
		}
	} 
}