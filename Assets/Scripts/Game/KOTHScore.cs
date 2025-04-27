using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class KOTHScore : MonoBehaviour
{

    //private Dictionary<GameObject, int> scores = new Dictionary<GameObject, int>();
    [SerializeField] private int index;
    [SerializeField] private List<GameObject> playerSpawnsKOTH = new List<GameObject>();
    //[SerializeField] private PlayerManager playerManager = GameObject.FindGameObjectWithTag("PlayerManager");
    private void setScore()
    {
        //foreach (GameObject obj in PlayerManager.playerList)
        //{
        //    scores[obj] = 0;
        //}
    }
    private void Start()
    {
        //Debug.Log("player list " + PlayerManager.playerList);
        //Debug.Log("koth spawnhs " + playerSpawnsKOTH);

        if (PlayerManager.playerList.Count >= 1)
            PlayerManager.playerList[0].GetComponent<Transform>().position = playerSpawnsKOTH[0].GetComponent<Transform>().position;
        if (PlayerManager.playerList.Count >= 2)
            PlayerManager.playerList[1].GetComponent<Transform>().position = playerSpawnsKOTH[1].GetComponent<Transform>().position;
        if (PlayerManager.playerList.Count >= 3)
            PlayerManager.playerList[2].GetComponent<Transform>().position = playerSpawnsKOTH[2].GetComponent<Transform>().position;
        if (PlayerManager.playerList.Count >= 4)
            PlayerManager.playerList[3].GetComponent<Transform>().position = playerSpawnsKOTH[3].GetComponent<Transform>().position;
    }
    private void Update()
    {
        foreach(GameObject player in PlayerManager.playerList)
        {
            player.GetComponent<KOTHTimer>().enabled = true;
        }
       
        if (DeathTrigger.oneAlive == true)
        {
            Debug.Log("one Alive in kothscore" + DeathTrigger.oneAlive);
            ScoreUpdate();
            ScoreCheck();
            DeathTrigger.oneAlive = false;
        }
    }
    public void ScoreCheck()
    {
        foreach(GameObject player in PlayerManager.playerList)
        {
            if (player.GetComponent<Player>().gameScore == 6)
            {
                SceneManager.LoadScene(5);
            }
        }

    }

    public void ScoreUpdate()
    {
        for (int i = 0;i < PlayerManager.playerStatus.Count; i++)
        {
            if (PlayerManager.playerStatus[i] == true)
            {
                PlayerManager.playerList[i].GetComponent<Player>().gameScore += 1;
            }
        }
        DeathTrigger.playerDeathOrder.Clear();
        DeathTrigger.oneAlive = false;
    }
}
