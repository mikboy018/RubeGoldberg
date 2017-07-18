using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
//Repurposed from my Night at the Museum and Maze Projects

public class SignPostText : MonoBehaviour
{
    Text scoreMsg;
    public GameObject logic;


    void Update()
    {
        int rotateSpeed = logic.GetComponent<Counter>().GetSpeed();
        int batFreq = logic.GetComponent<Counter>().GetFreq();
        int objCounter = logic.GetComponent<Counter>().GetObjCount();
        int scoreCount = logic.GetComponent<Counter>().GetScore();
        scoreMsg = GetComponent<Text>();
        scoreMsg.text = "Merry-Go-Round Speed: " + rotateSpeed + "%\nBat Frequency: " + batFreq + "%\nYou've placed " + 
            objCounter + " objects\nin the scene.\nYouv'e scored " + scoreCount + " times";
        Debug.Log("Speed - " + rotateSpeed + " Freq - " + batFreq);
    }

    public void OnSignClick()
    {
        // Reset the scene when the user clicks the sign post
        //Application.Quit();
    }
}