using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInteraction : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject.Find("MasterLogic").GetComponent<Counter>().SetFreq();
        GameObject.Find("MasterLogic").GetComponent<Counter>().SetSpeed();
	}
}
