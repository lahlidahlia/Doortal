using UnityEngine;
using System.Collections;

public class ParticleDestroy : MonoBehaviour {
    private ParticleSystem part;
	// Use this for initialization
	void Start () {
        part = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (part.isStopped) {
            Destroy(gameObject);
        }
	}
}
