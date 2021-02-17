using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private int score; //current score
    public float speed; //magnitude of force put on player
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        //Player controls


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector3.left * speed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector3.right * speed);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.forward * speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(Vector3.back * speed);
        }

    }

    //method to detect when game object hits a pickup object
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            score += other.gameObject.GetComponent<Pickup>().scoreValue; //add score value of pickup to player score
            Destroy(other.gameObject);
        }
    }

    //getter method for score
    public int GetScore()
    {
        return score;
    }

    //setter method for score
    public void SetScore(int newScore)
    {
        score = newScore;
    }
}
