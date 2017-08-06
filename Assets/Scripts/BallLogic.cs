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
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Movable"))
        {
            Debug.Log("collision!" + other.name);
            other.GetComponent<CapsuleCollider>().enabled = false;
            other.GetComponent<MeshCollider>().enabled = true;
            this.gameObject.GetComponent<Collider>().isTrigger = false;
        
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Movable"))
        {
            //other.gameObject.GetComponent<Collider>().isTrigger = true;
            other.GetComponent<CapsuleCollider>().enabled = true;
            other.GetComponent<MeshCollider>().enabled = false;
            this.gameObject.GetComponent<Collider>().isTrigger = true;
        }
    }*/

    /*
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Movable"))
        {
            other.GetComponent<CapsuleCollider>().enabled = false;
            Debug.Log("changing tag");
            EnableMesh(other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.CompareTag("PuzzleObject"))
        {
            other.GetComponent<MeshCollider>().enabled = false;
            Debug.Log("changing tag back");
            DisableMesh(other);
        }
    }

    public void EnableMesh(Collider other)
    {
        other.gameObject.tag = "PuzzleObject";
        other.GetComponent<MeshCollider>().enabled = true;
        Debug.Log("Object Tag Changed to PuzzleObject");
    }

    public void DisableMesh(Collider other)
    {
        other.gameObject.tag = "Movable";
        other.GetComponent<CapsuleCollider>().enabled = true;
        Debug.Log("Object Tag Changed to Movable");
    }
    */
        private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision enter with " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Movable"))
        {
            
            this.gameObject.GetComponent<SphereCollider>().isTrigger = false;
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
