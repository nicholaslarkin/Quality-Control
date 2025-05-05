using System.Collections.Generic;
using UnityEngine;

public class ElectricManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> playerSpawnsElectric = new List<GameObject>();
    
    void Start()
    {
        if (PlayerManager.playerList.Count >= 1)
            PlayerManager.playerList[0].GetComponent<Transform>().position = playerSpawnsElectric[0].GetComponent<Transform>().position;    
        if (PlayerManager.playerList.Count >= 2)
            PlayerManager.playerList[1].GetComponent<Transform>().position = playerSpawnsElectric[1].GetComponent<Transform>().position;
        if (PlayerManager.playerList.Count >= 3)
            PlayerManager.playerList[2].GetComponent<Transform>().position = playerSpawnsElectric[2].GetComponent<Transform>().position;
        if (PlayerManager.playerList.Count >= 4)
            PlayerManager.playerList[3].GetComponent<Transform>().position = playerSpawnsElectric[3].GetComponent<Transform>().position;
    }


    void Update()
    {
        
    }
}
