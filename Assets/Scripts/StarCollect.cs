using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollect : MonoBehaviour {

    public GameObject logic;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Ball" && player.GetComponent<LegalThrow>().GetLegal() == true)
        {
            this.gameObject.SetActive(false);
            logic.GetComponent<Counter>().SetScore(1);
        }
    }

    public void ActivateStars()
    {
        this.gameObject.SetActive(true);
    }

    
}
