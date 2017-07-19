using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFrequency : MonoBehaviour {

    public Animator animObj;
    public int freq;
    public float animFreq;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        freq = GameObject.Find("MasterLogic").GetComponent<Counter>().GetFreq();
        animFreq = (float)freq/30;
        animObj.speed = animFreq;
    }
}
