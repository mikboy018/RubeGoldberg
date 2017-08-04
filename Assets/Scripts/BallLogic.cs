using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLogic : MonoBehaviour {
    public Transform ballMovement;
    private static Transform initialPosition;
    public GameObject startPos;
	// Use this for initialization
	void Start () {
        ballMovement = this.gameObject.transform;
        initialPosition = startPos.transform;

	}
	
	// Update is called once per frame
	void Update () {
		if(ballMovement.position.y < -3.16f)
        {
            //reset initial position and motion -- use RigidBody instead!
            ballMovement.position = initialPosition.position;
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
                
        }
	}

    private void OnTriggerEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Movable"))
        {
            Debug.Log("The ball hit the movable object!");
        }
    }
}
