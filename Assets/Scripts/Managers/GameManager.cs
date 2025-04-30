using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{   
    public static GameManager Instance=> instance;
    public GameStateEnums GameState;
    private static GameManager instance;

    public enum GameStateEnums
    {
        MainMenu,
        PlayersJoin,
        InGame,
        GameOver,
    }

    private void Awake()
    {
        instance = this;
    }



}
