using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneGenerator : MonoBehaviour
{

    //Method to generate pickup objects randomly around the map
    public int RandomGenerate(int numOfPickups, GameObject[] pickups) //takes an array of pickup objects as inpput
    {
        int maxScore = 0;
        int pickupIndex = 0;
        System.Random rand = new System.Random();
        for (int i = 0; i < numOfPickups; i++) //loops over for however many pickups there are
        {
            if (pickupIndex == 3) //loops over the different pickups
                pickupIndex = 0;

            int mapSection = rand.Next(5);

            float xLower = 0;
            float xUpper = 0;
            float yLower = 0;
            float yUpper = 0;

            switch (mapSection) //will generate ranges for the chosen map section
            {
                case 0:
                    xLower = -9;
                    xUpper = 9;
                    yLower = -4;
                    yUpper = 4;
                    break;

                case 1:
                    xLower = 11;
                    xUpper = 19;
                    yLower = -24;
                    yUpper = 24;
                    break;

                case 2:
                    xLower = -9;
                    xUpper = 9;
                    yLower = 16;
                    yUpper = 19;
                    break;

                case 3:
                    xLower = -19;
                    xUpper = -11;
                    yLower = -24;
                    yUpper = 24;
                    break;

                case 4:
                    xLower = -9;
                    xUpper = 9;
                    yLower = -24;
                    yUpper = -16;
                    break;
            }

            Vector3 position = new Vector3(Random.Range(xLower, xUpper), 1, Random.Range(yLower, yUpper));
            GameObject newPickup = Instantiate(pickups[pickupIndex]) as GameObject;
            newPickup.transform.position = position;
            maxScore += pickups[pickupIndex].GetComponent<Pickup>().scoreValue; //keep track of the max score a player can achieve 
            pickupIndex++;
        }

        return maxScore; //return the max score
    }
}
