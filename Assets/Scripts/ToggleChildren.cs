using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleChildren : MonoBehaviour {

    public void Reactivate()
    {


        foreach (Transform child in transform)
        {
           child.GetComponent<StarCollect>().ActivateStars();

        }
    }
}
