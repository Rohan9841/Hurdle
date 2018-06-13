using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    //Speed at which the player runs
    public float runSpeed = 0f;
    
    //Maximum running speed
    public float maxSpeed = 7f;

    //acceleration rate
    public float acceleration = 1f;

    //Force at which the player jumps
    public float jumpingForce = 300f;

    //After 0.9 sec the player will be able to jump 
    public float jumpCoolDown = 0.9f;

    //After one jump, the jumpinigTimer will be set to jumpCoolDown
    private float jumpingTimer = 0f;

    //variable to check if the player has reached the finish line
    public bool reachedFinishLine = false;

    public AudioSource aSource;
    public AudioClip aclip;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //In each frame the jumping timer is reduced
        jumpingTimer -= Time.deltaTime;

        //Move player forward

        //accelerating the player
        runSpeed += acceleration * Time.deltaTime;

        //setting runspeed to maxSpeed 
        if(runSpeed > maxSpeed)
        {
            runSpeed = maxSpeed;
        }

        //changing the player's position in each frame
        transform.position += runSpeed * Vector3.forward * Time.deltaTime;

        //Jump the player
        if (Input.GetKeyDown("space") || GvrPointerInputModule.Pointer.TriggerDown)
        {
            //if we are ready to jump
            if (jumpingTimer <= 0)
            {
                this.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpingForce);
                jumpingTimer = jumpCoolDown;
            }
        }

	}

    private void OnCollisionEnter(Collision collision)
    {
         //if player touches the hurdle, reduce speed by half
        if(collision.transform.tag == "Hurdle")
        {
            runSpeed *= 0.5f;
            aSource.PlayOneShot(aclip);
            Debug.Log("Collision on hurdle");
        }

        if(collision.transform.tag == "Finish")
        {
            reachedFinishLine = true;
            aSource.Stop();
            Debug.Log("reached finish");
        }
    }
}
