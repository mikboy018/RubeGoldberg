using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class BallLogic : MonoBehaviour {
    public Transform ballMovement;
    public GameObject startPos;
    private Transform initialPosition;
    public GameObject logic;
    public GameObject poof;
    public GameObject stars;
    public GameObject goal;

	// Use this for initialization
	void Start () {
        ballMovement = this.gameObject.transform;
        initialPosition = startPos.transform;

	}
	
	// Update is called once per frame
	void Update () {
		if(ballMovement.position.y < 0f)
        {
            ballMovement.position = initialPosition.position;
            //Debug.Log("Transform start pos = " + startPos.transform);
            Object.Instantiate(poof);
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
        //Debug.Log("collision enter with " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Movable"))
        {
            collision.gameObject.GetComponent<ObjectUsed>().used = true;
            this.gameObject.GetComponent<SphereCollider>().isTrigger = false;
            logic.GetComponent<Counter>().SetTally(1);
            //Debug.Log("Tally is " + logic.GetComponent<Counter>().GetTally());
        }
        if (collision.gameObject.CompareTag("laserMask"))
        {
            this.gameObject.GetComponent<SphereCollider>().isTrigger = true;
        }
        if (collision.gameObject.tag == "Goal")
        {
            //Debug.Log("Ball hit goal");
            if (logic.GetComponent<Counter>().GetScore() >= 2)
            {
                //Debug.Log("Score is good enough!");
                //SceneManager.LoadScene("LevelOne");
                goal.GetComponent<SteamVR_LoadLevel>().Trigger();
            }
        }
    }

    
}
