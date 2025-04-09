using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public PlayerInputManager playerInputManager;

    private List<Player> playerList = new List<Player>();
    [SerializeField] private List<GameObject> playerPrefabs = new List<GameObject>();
    [SerializeField] private GameObject playerPrefab;
    //[SerializeField] private GameObject player1Spawn;
    //[SerializeField] private GameObject player2Spawn;
    //[SerializeField] private GameObject player3Spawn;
    //[SerializeField] private GameObject player4Spawn;

    private void Awake()
    {
        
    }

    private void Start()
    {
        playerTotal();
    }

    //eventually rework the multiplayer system to use manual join and the JoinPlayer() method of the playerinputmanager. this will just pair devi
    void Update()
    {
        playerPrefab = PlayerInputManager.instance.playerPrefab = playerPrefabs[playerInputManager.playerCount];
        playerInputManager.DisableJoining();
        switch (GameManager.Instance.GameState)
        {
            case (GameManager.GameStateEnums.SelectPlayers):
                playerInputManager.EnableJoining();
                break;
            //case (GameManager.GameStateEnums.InGame):
            //    playerInputManager.EnableJoining();
            //    break;
            case (GameManager.GameStateEnums.InGame):
                playerInputManager.EnableJoining();
                //spawn player prefab based off player count in game
                switch (playerInputManager.playerCount)
                {
                    case (1):
                        PlayerInputManager.instance.playerPrefab = playerPrefab;
                        //Instantiate(playerPrefab1, player1Spawn.transform.position, Quaternion.identity);
                        playerTotal();
                        break;
                    case (2):
                        PlayerInputManager.instance.playerPrefab = playerPrefab;
                        //Instantiate(playerPrefab2, player2Spawn.transform.position, Quaternion.identity);
                        playerTotal();
                        break;
                    case (3):
                        PlayerInputManager.instance.playerPrefab = playerPrefab;
                        //Instantiate(playerPrefab3, player3Spawn.transform.position, Quaternion.identity);
                        playerTotal();
                        break;
                    case (4):
                        PlayerInputManager.instance.playerPrefab = playerPrefab;
                        //Instantiate(playerPrefab4, player4Spawn.transform.position, Quaternion.identity);
                        playerTotal();
                        break;
                    default:
                        break;

                }
                break;


        }
    }
    public void playerTotal()
    {
        //Debug.Log("total player number: " + playerInputManager.playerCount);
    }



}

