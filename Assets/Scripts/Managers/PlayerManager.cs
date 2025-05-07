using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance => instance;
    private static PlayerManager instance;
    public PlayerInputManager playerInputManager;
    public static List<bool> playerStatus = new List<bool>();
    public static List<GameObject> playerList = new List<GameObject>();
    private bool firstTime = false;
    [SerializeField] private List <GameObject> playerPrefabsKoth = new List<GameObject>(); 
    [SerializeField] private GameObject playerPrefab;

    private void Awake()
    {
        instance = this;
    }
    
    //call this after all players join and sets up the list with the amount of players after they all joined
    public void playerStatusSetup(List<bool> status)
    {
        if (firstTime == false) {
            foreach(GameObject player in playerList)
            {
                status.Add(true);
            }
            Debug.Log("Total player count:" + playerStatus.Count);
        }
        firstTime = true;

    }

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    //eventually rework the multiplayer system to use manual join and the JoinPlayer() method of the playerinputmanager. this will just pair device
    void Update()
    {
        playerPrefab = PlayerInputManager.instance.playerPrefab = playerPrefabsKoth[playerInputManager.playerCount];
        playerInputManager.DisableJoining();
        //allow players to join only when gamestate is playerjoin
        switch (GameManager.Instance.GameState)
        {
            case (GameManager.GameStateEnums.PlayersJoin):
                playerInputManager.EnableJoining();
                //spawn player prefab based off player count in game
                switch (playerInputManager.playerCount)
                {
                    case (1):
                        PlayerInputManager.instance.playerPrefab = playerPrefab;
                        break;
                    case (2):
                        PlayerInputManager.instance.playerPrefab = playerPrefab;
                        break;
                    case (3):
                        PlayerInputManager.instance.playerPrefab = playerPrefab;
                        break;
                    case (4):
                        PlayerInputManager.instance.playerPrefab = playerPrefab;
                        break;
                    default:
                        break;

                }
                break;
            case (GameManager.GameStateEnums.InGame):
                playerStatusSetup(playerStatus);
                playerInputManager.DisableJoining();
                break;
            case (GameManager.GameStateEnums.MainMenu):
                playerInputManager.DisableJoining();
                break;
            case (GameManager.GameStateEnums.GameOver):
                playerInputManager.DisableJoining();
                break;
        }

        foreach(GameObject player in playerList)
        {
            if (player.GetComponent<Player>().gameScore == 6)
            {
                GameManager.Instance.GameState = GameManager.GameStateEnums.GameOver;
            }
        }

    }




}

