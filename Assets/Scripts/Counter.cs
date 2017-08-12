using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**This is built from the Maze and Musuem projects
 * This is designed to track each speed, frequency, and
 * score info.
 *  
 * 17 JUL 2017 - Mike Boyer
 **/

public class Counter : MonoBehaviour
{
    private int speed;
    private int freq;
    private int objCount;
    private int score;
    private int tally;
    private float conv = 100*1.35f;
    public GameObject speedLever;
    public GameObject freqLever;
    
    //Merry-Go-Round Speed
    public int GetSpeed()
    {
        return speed;
    }
    public void SetSpeed()
    {
        speed = -(-5 + Mathf.RoundToInt(speedLever.transform.rotation.z*conv));
        //Debug.Log("Speed is changing!");
    }
    //Bat frequency
    public int GetFreq()
    {
        return freq;
    }public void SetFreq()
    {
        freq = -(-5 + Mathf.RoundToInt(freqLever.transform.rotation.z*conv));
        //Debug.Log("Freq is changing!");
    }
    //Count of total objects added by player
    public int GetObjCount()
    {
        return objCount;
    }
    public void SetObjCount(int count)
    {
        objCount = objCount + count;
    }
    //Count of totaltimes player has scored
    public int GetScore()
    {
        return score;
    }
    public void SetScore(int collected)
    {
        score = score + collected;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public int GetTally()
    {
        return tally;
    }

    public void SetTally(int collide)
    {
        tally = tally + collide;
    }

    public void ResetTally()
    {
        tally = 0;
    }




    
}
  