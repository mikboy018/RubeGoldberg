using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLogic : MonoBehaviour {
    public Transform ballMovement;
    private static Transform initialPosition;
    public GameObject startPos;
    public GameObject logic;
    public GameObject poof;
    public GameObject stars;

	// Use this for initialization
	void Start () {
        ballMovement = this.gameObject.transform;
        initialPosition = startPos.transform;

	}
	
	// Update is called once per frame
	void Update () {
		if(ballMovement.position.y < 0f)
        {
            //reset initial position and motion -- use RigidBody instead!
            ballMovement.position = initialPosition.position;
            GameObject poofObj = Object.Instantiate(poof, ballMovement);
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            logic.GetComponent<Counter>().ResetTally();
            logic.GetComponent<Counter>().ResetScore();
            stars.GetComponent<ToggleChildren>().Reactivate();
        }
	}

        private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision enter with " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Movable"))
        {
            collision.gameObject.GetComponent<ObjectUsed>().used = true;
            this.gameObject.GetComponent<SphereCollider>().isTrigger = false;
            logic.GetComponent<Counter>().SetTally(1);
            Debug.Log("Tally is " + logic.GetComponent<Counter>().GetTally());
        }
        if (collision.gameObject.CompareTag("laserMask"))
        {
            this.gameObject.GetComponent<SphereCollider>().isTrigger = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Movable"))
        {
            Debug.Log("collision exit with " + collision.gameObject.name);
            //this.gameObject.GetComponent<SphereCollider>().isTrigger = true;
            
        }
    }

    
}
