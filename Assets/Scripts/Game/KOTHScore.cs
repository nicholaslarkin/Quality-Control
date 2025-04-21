using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class KOTHScore : MonoBehaviour
{
    [SerializeField] public List<int> playerScores = new List<int>(4) { 0, 0, 0, 0 };
    //private Dictionary<GameObject, int> scores = new Dictionary<GameObject, int>();
    private int index;
    private int round = 1;

    private void setScore()
    {
        //foreach (GameObject obj in PlayerManager.playerList)
        //{
        //    scores[obj] = 0;
        //}
    }
    private void Update()
    {
        if (DeathTrigger.oneAlive == true)
        {
            round += 1;
            ScoreUpdate();
            ScoreCheck();
            DeathTrigger.oneAlive = false;
        }
    }
    public void ScoreCheck()
    {
        index = playerScores.FindIndex(i => i >= 12);
        if (index <=3 && index >=0)
        {
            PlayerManager.playerList[index].GetComponent<Player>().gameScore += 1;
        }

    }

    public void ScoreUpdate()
    {
        playerScores[0] += 0;
        playerScores[1] += 1;
        playerScores[2] += 2;
        playerScores[3] += 3;
        DeathTrigger.playerDeathOrder.Clear();
        DeathTrigger.oneAlive = false;
    }
}
