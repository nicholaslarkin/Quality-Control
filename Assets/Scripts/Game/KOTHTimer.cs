using UnityEngine;

public class KOTHTimer : MonoBehaviour
{
    //timer script for KOTH attached to each player
    [SerializeField] private float timeRemaining = 10f; //timer start value
    [SerializeField] private float timer;
    [SerializeField] public bool countingDown = false; //bool var true if they are outside of the circle,gotten from koth script

    public float TimeRemaining => timeRemaining;

    void Update()
    {
        if (timeRemaining <= 0)
        {
            timerFinish();
        }
        if (countingDown == true && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            Debug.Log("Timer: " + timeRemaining);
            //reminder to display to ui the remaining time
        }
        else if (countingDown == false && timeRemaining > 0)
        {
            //timerPaused();
        }
        else
        {
            timerFinish();
        }
        
    }
    public void timerFinish()
    {
        Debug.Log("Player timer over");
        Destroy(gameObject);
    }

    public void timerPaused()
    {
        timeRemaining = timer;
    }
}
