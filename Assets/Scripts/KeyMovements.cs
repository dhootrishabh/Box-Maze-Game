using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMovements : MonoBehaviour {

    private Rigidbody player;
    public float moveSpeed;
    //private Vector3 spawnPosition;
    private Vector3 input;
    // Use this for initialization
    void Start () {
        player = GetComponent<Rigidbody>();
        //spawnPosition = player.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (player.transform.position.y > 0.2f && player.transform.position.y < 0.5f)
        {
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                input = player.transform.position;
                input.x += 1;
                player.transform.position = input;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                input = player.transform.position;
                input.x -= 1;
                player.transform.position = input;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                input = player.transform.position;
                input.z -= 1;
                player.transform.position = input;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                input = player.transform.position;
                input.z += 1;
                player.transform.position = input;
            }
        }
    }
}
