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
    private float speed;
    private float freq;
    private int objCount;
    private int score;
    private int tally;
    
    //Merry-Go-Round Speed
    public float GetSpeed()
    {
        return speed;
    }
    public void SetSpeed()
    {
        speed = GameObject.Find("GreenLever").GetComponent<Transform>().position.z*1.12f;
    }
    //Bat frequency
    public float GetFreq()
    {
        return freq;
    }public void SetFreq()
    {
        freq = GameObject.Find("BlueLever").GetComponent<Transform>().position.z * 1.12f;
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
    public void SetScore(int win)
    {
        score = score + win;
    }
    //Count of Collectibles captured
    public int GetTally()
    {
        return tally;
    }
    public void setTally(int newObj)
    {
        tally = tally + newObj;
    }


    
}
  