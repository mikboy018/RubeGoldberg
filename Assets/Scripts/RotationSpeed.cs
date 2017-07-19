using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSpeed : MonoBehaviour {


    public Transform rotatingObject;
    public int speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        speed = GameObject.Find("MasterLogic").GetComponent<Counter>().GetSpeed();
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
