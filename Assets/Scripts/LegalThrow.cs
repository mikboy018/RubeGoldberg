using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegalThrow : MonoBehaviour
{

    public bool legal = false;

    public bool GetLegal()
    {
        return legal;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collided with: " + other.gameObject.name);
        if (other.gameObject.CompareTag("ThrowBoundary"))
        {
            legal = true;
            //Debug.Log("You may now throw the ball to start the game!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ThrowBoundary"))
        {
            legal = false;
            //Debug.Log("Throwing now causes reset");
        }
    }

}
