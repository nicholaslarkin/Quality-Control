using UnityEngine;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

public class DeathTrigger : MonoBehaviour
{
    public static Vector3 deathPos;
    public static bool oneAlive = false;
    public int playerLiving = 5;
    [SerializeField] private GameObject player1Spawn;
    [SerializeField] private GameObject player2Spawn;
    [SerializeField] private GameObject player3Spawn;
    [SerializeField] private GameObject player4Spawn;
    [SerializeField] public static List<int> playerDeathOrder = new List<int>(4);


    public void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            playerDeathOrder.Add(PlayerManager.playerList.FindIndex(go => go == other.gameObject));
            other.gameObject.GetComponent<Player>().playerAlive = false;
            other.gameObject.GetComponent<Transform>().position = deathPos;

            if (PlayerManager.playerList.Count > 1 && PlayerManager.playerStatus.Count(b=> b) == 1)
            {
                oneAlive = true;
                PlayerManager.playerList[0].GetComponent<Transform>().position = player1Spawn.transform.position;
                PlayerManager.playerList[1].GetComponent<Transform>().position = player1Spawn.transform.position;
                PlayerManager.playerList[2].GetComponent<Transform>().position = player1Spawn.transform.position;
                PlayerManager.playerList[3].GetComponent<Transform>().position = player1Spawn.transform.position;


            }

        }
    }

    
}
