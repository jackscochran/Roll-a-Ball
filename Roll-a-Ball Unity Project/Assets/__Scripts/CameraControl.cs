using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script that makes camera follow the player
public class CameraControl : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
