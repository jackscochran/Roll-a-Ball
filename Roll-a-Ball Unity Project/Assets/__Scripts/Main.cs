using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{

    public int NUM_OF_PICKUPS; //how many pickups will be on the map
    public GameObject player;
    public GameObject[] pickups;
    private int maxScore;
    public Text scoreText;
    public Text endGameText;
    public GameObject map;


    // Start is called before the first frame update
    void Start()
    {
        
        NewGame();
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<Text>().text = "Score: " + player.GetComponent<PlayerScript>().GetScore().ToString(); //update score text
        if (player.GetComponent<PlayerScript>().GetScore() == maxScore) //check if player has completed the game
        {
            player.gameObject.GetComponent<PlayerScript>().SetScore(0); //reset score
            StartCoroutine(ResetGame()); //pause and reset game
        }

    }


    private IEnumerator ResetGame()
    {
        endGameText.gameObject.SetActive(true); //display winning text
        player.SetActive(false); //hide player object
        yield return new WaitForSeconds(3); //wait 3 seconds
        NewGame(); //start new game
    }



    private void NewGame()
    {
        endGameText.gameObject.SetActive(false); //hide end game text
        player.SetActive(true);
        //reset player position and velocity to 0
        player.gameObject.transform.position = new Vector3(0, 0.75f, 0);
        player.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        
        maxScore = map.gameObject.GetComponent<LevelOneGenerator>().RandomGenerate(NUM_OF_PICKUPS, pickups);
    }

    
}
