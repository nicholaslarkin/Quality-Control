using UnityEngine;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour
{
    public static Vector3 deathPos = new Vector3(94.7053986f, 19.0300007f, 17.2780991f);
    public static bool oneAlive = false;
    public int playerLiving = 5;
    [SerializeField] public SceneTransition sceneTransition;
    [SerializeField] public static List<int> playerDeathOrder = new List<int>(4);


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().playerAlive = false;
            other.gameObject.GetComponent<Transform>().position = deathPos;
            PlayerManager.playerStatus[other.gameObject.GetComponent<Player>().playerNumber] = false;
        }

    }

    public void Update()
    {

        //if there is only 1 player alive and there are more than 1 players in the game, go next scene
        if (PlayerManager.playerStatus.Count(b => b) == 1 && PlayerManager.playerList.Count > 1)
        {
            oneAlive = true;
            foreach (GameObject player in PlayerManager.playerList)
            {
                //if the player is the one that is alive, give them a point
                if (player.GetComponent<Player>().playerAlive == true)
                {
                    player.GetComponent<Player>().gameScore++;
                    //checks if any player has 6 points
                    ScoreCheck();
                    resetStatus();
                    //goes to next scene after point is given
                    GameObject.Find("PlayerSceneManager").GetComponent<SceneTransition>().goNextScene();
                }
            }
        }
    }

    
    public void resetStatus() //change all players to alive again
    {
        foreach (GameObject player in PlayerManager.playerList)
        {

            player.GetComponent<Player>().playerAlive = true;
        }
        oneAlive = false;
    }
    public void ScoreCheck()
    {
        foreach (GameObject player in PlayerManager.playerList)
        {
            if (player.GetComponent<Player>().gameScore == 6)
            {
                SceneManager.LoadScene(5);
            }
        }

    }
}
