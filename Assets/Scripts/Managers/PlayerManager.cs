using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance => instance;
    private static PlayerManager instance;
    public PlayerInputManager playerInputManager;

    public static List<GameObject> playerList = new List<GameObject>();
    public static List<bool> playerStatus = new List<bool>();  
    [SerializeField] private List <GameObject> playerPrefabsKoth = new List<GameObject>();
    [SerializeField] private GameObject playerPrefab;
    
    [SerializeField] public List <GameObject> playerSpawnsBOX = new List<GameObject>();
    [SerializeField] public List <GameObject> playerSpawnsElectric = new List<GameObject>();
    //[SerializeField] private GameObject player1Spawn;
    //[SerializeField] private GameObject player2Spawn;
    //[SerializeField] private GameObject player3Spawn;
    //[SerializeField] private GameObject player4Spawn;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
        playerTotal();
    }

    //eventually rework the multiplayer system to use manual join and the JoinPlayer() method of the playerinputmanager. this will just pair device
    void Update()
    {
        playerPrefab = PlayerInputManager.instance.playerPrefab = playerPrefabsKoth[playerInputManager.playerCount];
        playerInputManager.DisableJoining();
        switch (GameManager.Instance.GameState)
        {
            case (GameManager.GameStateEnums.PlayersJoin):
                playerInputManager.EnableJoining();
                //spawn player prefab based off player count in game
                //switch (playerInputManager.playerCount)
                //{
                //    case (1):
                //        PlayerInputManager.instance.playerPrefab = playerPrefab;
                //        //Instantiate(playerPrefab1, player1Spawn.transform.position, Quaternion.identity);
                //        playerTotal();

                //        break;
                //    case (2):
                //        PlayerInputManager.instance.playerPrefab = playerPrefab;
                //        //Instantiate(playerPrefab2, player2Spawn.transform.position, Quaternion.identity);
                //        playerTotal();
                //        break;
                //    case (3):
                //        PlayerInputManager.instance.playerPrefab = playerPrefab;
                //        //Instantiate(playerPrefab3, player3Spawn.transform.position, Quaternion.identity);
                //        playerTotal();
                //        break;
                //    case (4):
                //        PlayerInputManager.instance.playerPrefab = playerPrefab;
                //        //Instantiate(playerPrefab4, player4Spawn.transform.position, Quaternion.identity);
                //        playerTotal();
                //        break;
                //    default:
                //        break;

                //}
                break;
            //case (GameManager.GameStateEnums.InGame):
            //    playerInputManager.EnableJoining();
            //    break;
            case (GameManager.GameStateEnums.InGame):
                playerInputManager.EnableJoining();
                //playerInputManager.DisableJoining();
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

