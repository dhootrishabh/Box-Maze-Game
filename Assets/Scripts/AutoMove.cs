using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour {

    public GameObject[] points;

    public float speed;

    private Rigidbody enemy;
    private int nextPoint;

	// Use this for initialization
	void Start () {
        enemy = GetComponent<Rigidbody>();
        nextPoint = 0;
    }
	
	// Update is called once per frame
	void Update () {

        if(enemy.transform.position == points[nextPoint].transform.position)
        {
            nextPoint = (nextPoint+1)%(points.Length);
        }
        else
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, points[nextPoint].transform.position, speed * Time.deltaTime);
        }
        
	}
}
