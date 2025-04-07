using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public PlayerInputManager playerInputManager;
    private List<Player> playerList = new List<Player>();
    [SerializeField] private Player playerPrefab1;
    [SerializeField] private Player playerPrefab2;
    [SerializeField] private Player playerPrefab3;
    [SerializeField] private Player playerPrefab4;
    private Vector3 player1Transform;
    private Vector3 player2Transform;
    private Vector3 player3Transform;
    private Vector3 player4Transform;

    void Update()
    {
        playerInputManager.DisableJoining();
        switch (GameManager.Instance.GameState)
        {
            case (GameManager.GameStateEnums.SelectPlayers):
                playerInputManager.EnableJoining();
                break;
            case (GameManager.GameStateEnums.InGame):
                switch (playerInputManager.playerCount)
                {
                    case (0):
                        Instantiate(playerPrefab1, player1Transform, Quaternion.identity);
                        break;
                    case (1):
                        Instantiate(playerPrefab2, player2Transform, Quaternion.identity);
                        break;
                    case (2):
                        Instantiate(playerPrefab3, player3Transform, Quaternion.identity);
                        break;
                    case (3):
                        Instantiate(playerPrefab4, player4Transform, Quaternion.identity);
                        break;

                }
                break;
        }




    }
}
