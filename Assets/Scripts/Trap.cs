using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    private GameObject player;
    private Vector3 spawnPosition;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        spawnPosition = player.transform.position;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Spikes Detected");
            player.transform.position = spawnPosition;

        }
    }
}
