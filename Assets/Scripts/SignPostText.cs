using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
//Repurposed from my Night at the Museum and Maze Projects

public class SignPostText : MonoBehaviour
{
    Text scoreMsg;


    void Update()
    {
        float rotateSpeed = GameObject.Find("MasterLogic").GetComponent<Counter>().GetSpeed();
        float batFreq = GameObject.Find("MasterLogic").GetComponent<Counter>().GetFreq();
        int objCounter = GameObject.Find("MasterLogic").GetComponent<Counter>().GetObjCount();
        int scoreCount = GameObject.Find("MasterLogic").GetComponent<Counter>().GetScore();
        scoreMsg = GetComponent<Text>();
        scoreMsg.text = "Merry-Go-Round Speed: " + rotateSpeed + "%\nBat Frequency: " + batFreq + "%\nYou've placed " + 
            objCounter + " objects\nin the scene.\nYouv'e scored " + scoreCount + " times";

    }

    public void OnSignClick()
    {
        // Reset the scene when the user clicks the sign post
        //Application.Quit();
    }
}