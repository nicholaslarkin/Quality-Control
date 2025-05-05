using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class KOTHManager : MonoBehaviour
{

    [SerializeField] private List<GameObject> playerSpawnsKOTH = new List<GameObject>();
    
    private void Start()
    {
        //Debug.Log("player list " + PlayerManager.playerList);
        Debug.Log("statusList: " + PlayerManager.playerStatus);
        Debug.Log("player 1 status " + PlayerManager.playerStatus[0]);

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
       
        
    }
}
