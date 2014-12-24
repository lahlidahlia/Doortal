using UnityEngine;
using System.Collections;

public class SoundScript : MonoBehaviour {
    public AudioClip passWallSound;
    public static SoundScript Sound; //Creating singleton
	// Use this for initialization
    void Awake() {
        Sound = this;
    }
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void MakePasswallSound() {
        MakeSound(passWallSound);
    }

    public void MakeSound(AudioClip originalClip){
        // As it is not 3D audio clip, position doesn't matter.
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}
