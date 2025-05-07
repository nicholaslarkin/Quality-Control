using UnityEngine;

public class KOTHTimer : MonoBehaviour
{
    //timer script for KOTH attached to each player
    [SerializeField] private float timeRemaining; //timer start value
    [SerializeField] private float timer;
    [SerializeField] public  bool countingDown = false; //bool var true if they are outside of the circle,gotten from koth script

    public float TimeRemaining => timeRemaining;

    void Update()
    {
        if (timeRemaining <= 0 && countingDown == true)
        {
            timerFinish();
        }
        else if (countingDown == true && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            //Debug.Log("Timer: " + timeRemaining);
            //reminder to display to ui the remaining time
        }
        else if (countingDown == false && timeRemaining <= 0)
        {
            timerRestart();
            //Debug.Log("Restarted in timer");
            //Debug.Log("timer after restart:" +  timeRemaining);
        }
        
    }
    public void timerFinish()
    {
        GetComponent<Transform>().position = DeathTrigger.deathPos;
        DeathTrigger.playerDeathOrder.Add(PlayerManager.playerList.FindIndex(go => go == this.gameObject));
        //Debug.Log("DeathOrderList: " + DeathTrigger.playerDeathOrder);

        GetComponent<Player>().playerAlive = false;
        countingDown = false;
    }

    public void timerPaused()
    {
        timeRemaining = timer;
    }

    public void timerRestart()
    {
        countingDown = true;
        timeRemaining = 15f;
    }
}
