using UnityEngine;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

public class DeathTrigger : MonoBehaviour
{
    public static Vector3 deathPos = new Vector3(94.7053986f, 19.0300007f, 17.2780991f);
    public static bool oneAlive = false;
    public int playerLiving = 5;
    [SerializeField] public SceneTransition sceneTransition;
    [SerializeField] private GameObject player1Spawn;
    [SerializeField] private GameObject player2Spawn;
    [SerializeField] private GameObject player3Spawn;
    [SerializeField] private GameObject player4Spawn;
    [SerializeField] public static List<int> playerDeathOrder = new List<int>(4);


    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        //playerDeathOrder.Add(PlayerManager.playerList.FindIndex(go => go == other.gameObject));
    //        Debug.Log("DeathOrderList: " + DeathTrigger.playerDeathOrder);
    //        other.gameObject.GetComponent<Player>().playerAlive = false;
    //        other.gameObject.GetComponent<Transform>().position = deathPos;
    //    }

    //}

    public void Update()
    {
        if (PlayerManager.playerStatus.Count(b => b) == 1 && PlayerManager.playerList.Count > 1)
        {
            //SceneTransition.goNextScene();
            GameObject.Find("PlayerSceneManager").GetComponent<SceneTransition>().goNextScene();
        }
    }
    //rework this to choose next minigame and load that scene
    //public void resetKOTH()
    //{
    //    if (PlayerManager.playerList.Count > 1 && PlayerManager.playerStatus.Count(b => b) == 1)
    //        {
    //            oneAlive = true;
    //            PlayerManager.playerList[0].GetComponent<Transform>().position = player1Spawn.transform.position;
    //            PlayerManager.playerList[1].GetComponent<Transform>().position = player2Spawn.transform.position;
    //            PlayerManager.playerList[2].GetComponent<Transform>().position = player3Spawn.transform.position;
    //            PlayerManager.playerList[3].GetComponent<Transform>().position = player4Spawn.transform.position;
    //            foreach (GameObject player in PlayerManager.playerList)
    //            {
    //                GetComponent<Player>().playerAlive = true;
    //                GetComponent<KOTHTimer>().timerRestart();
    //            Debug.Log("Restarted in if");   
                    
    //            }
    //        }
    //        else
    //        {
    //            PlayerManager.playerList[0].GetComponent<Player>().playerAlive = true;
    //            PlayerManager.playerList[0].GetComponent<Transform>().position = player1Spawn.transform.position;
    //            PlayerManager.playerList[0].GetComponent<KOTHTimer>().timerRestart();
    //            Debug.Log("restarted in else");
                
    //        }
    //}
}
