using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GameManager manager;
    public GameObject deathparticles;
    private Rigidbody player;
    public float moveSpeed;
    private Vector3 spawnPosition;
    private Vector3 input;

    public AudioClip[] audioClips;

    public bool usesManager = true;
	// Use this for initialization
	void Start () {
        
        player = GetComponent<Rigidbody>();
        spawnPosition = player.transform.position;
        if(usesManager)
        {
            manager = manager.GetComponent<GameManager>();
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        if (player.transform.position.y > 0.2f && player.transform.position.y < 0.5f)
        {
            input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            player.AddForce(input * moveSpeed * 10f);
            if (player.transform.position.y < 0.3f)
            {
                player.transform.position = spawnPosition;
            }
        }
        
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Token")
        {
            PlaySound(0);
            if(usesManager)
            {
                manager.AddToken();
            }
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Goal")
        {
            
            Time.timeScale = 0f;
            if(usesManager)
            {
                manager.CompleteLevel();
            }
            PlaySound(1);
        }
    }

    void PlaySound(int clip)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = audioClips[clip];
        audio.Play();


    }

    void Die()
    {
        Instantiate(deathparticles, transform.position, Quaternion.identity);
        player.transform.position = spawnPosition;
    }
}
