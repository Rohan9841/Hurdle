using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {

    //reference variables
    public GameObject HurdlePrefab;
    public TextMesh infoText;
    public PlayerScript player;
    public TextMesh finishText;

    //game timer set to zero at the start
    private float gameTimer = 0f;

    //number of hurdles
    public int hurdleNumber = 5;

    //the distance converd by the hurdles in the track
    public float hurdleDistance = 100f;

    // Use this for initialization
    void Start()
    {
        //At the start of the game, hurdles will be instantiated
        for (int i = 0; i <= hurdleNumber; i++)
        {
            GameObject hurdles = Instantiate(HurdlePrefab);
            hurdles.transform.position = new Vector3(
                0f,
                0.7031269f,
                Random.Range(5f, hurdleDistance));
        }
    }

    // Update is called once per frame
    void Update () {
     
        if(player.reachedFinishLine == false)
        {
            gameTimer += Time.deltaTime;
            infoText.text = "Jump over the obstacles.\n Time Elapsed: " + Mathf.Floor(gameTimer)+"s"; 
        }
        else
        {
            //stopping the player
            player.runSpeed = 0f;

            //setting infoText to none
            infoText.text = "";

            //finish text will have some texts
            finishText.text = "Congratulations!\n Your race time was " + Mathf.Floor(gameTimer)+"s";

        }
        
	}

}
