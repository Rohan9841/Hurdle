using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    //determines how high the player goes while running
    public float amplitude = 0.25f;

    //determines how fast the player goes up and down
    public float frequency = 2f;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        //TO give running effect
        transform.localPosition = new Vector3(
            transform.localPosition.x,
            Mathf.Cos(transform.position.z * frequency) * amplitude, //changing only the height up and down. I don't know how it works though
            transform.localPosition.z
            );
	}

}
