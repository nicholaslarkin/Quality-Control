
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    /*
    Title = 0
    KOTH = 1
    Box = 2
    Electric = 3
    */
    public static SceneTransition Instance => instance;
    private static SceneTransition instance;
    

    public Camera playerSceneCamera;
    public int sceneIndex; //current scene index
    public int lastSceneIndex; //last scene index
    private Scene MainMenu;
    private Scene playerJoinScene;
    private Scene kothScene;
    private Scene boxScene;
    private Scene electricScene;
    [SerializeField] private int playerscreenCountdown = 5;
    [SerializeField] private List<Scene> minigameScenes = new List<Scene>(3);
    [SerializeField] public string sceneSelected;

    // List<Scene> minigameNext => minigameScenes;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);

    }
    private void Start()
    {
        
        //GoToScene();
        MainMenu = SceneManager.GetSceneByPath(SceneUtility.GetScenePathByBuildIndex(0));
        playerJoinScene = SceneManager.GetSceneByPath(SceneUtility.GetScenePathByBuildIndex(4));
        kothScene = SceneManager.GetSceneByPath(SceneUtility.GetScenePathByBuildIndex(1));
        boxScene = SceneManager.GetSceneByPath(SceneUtility.GetScenePathByBuildIndex(2));
        electricScene = SceneManager.GetSceneByPath(SceneUtility.GetScenePathByBuildIndex(3));
        Debug.Log("Refreshed on start");
        refreshSceneCount();
    }

    private void refreshSceneCount()
    {
        minigameScenes.Clear();
        minigameScenes.Add(kothScene);
        minigameScenes.Add(boxScene);
        minigameScenes.Add(electricScene);
    }

    
    private void randomizeScene()
    {
        int newSceneIndex;
        do
        {
            newSceneIndex = Random.Range(1, 4); // 3 total scenes chooses 1,2,3
        } while (newSceneIndex == lastSceneIndex);

        lastSceneIndex = newSceneIndex;
        SceneManager.LoadSceneAsync(newSceneIndex,LoadSceneMode.Additive);
        Debug.Log("Scene Loaded");

    }

    public void goNextScene()
    {
        switch (GameManager.Instance.GameState)
        {
            case GameManager.GameStateEnums.MainMenu:
                Debug.Log(playerJoinScene);
                Debug.Log(playerJoinScene.name);
                SceneManager.LoadSceneAsync(4);
                SceneManager.UnloadSceneAsync(0);
                break;
            case GameManager.GameStateEnums.PlayersJoin:
                randomizeScene();
                Debug.Log("SceneLoadedGoNext");
                //SceneManager.LoadSceneAsync(sceneIndex,LoadSceneMode.Additive);
                break;
            case GameManager.GameStateEnums.InGame:
                SceneManager.UnloadSceneAsync(minigameScenes[lastSceneIndex]);
                randomizeScene();
                SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
                Debug.Log("next minigame");
                break;
            case GameManager.GameStateEnums.GameOver:
                SceneManager.LoadSceneAsync(5,LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync(sceneIndex);
                break;
        }
    }
    public System.Collections.IEnumerator StartCountdown()
    {
        
        while(playerscreenCountdown > 0){
            Debug.Log("Join time remaining: " + playerscreenCountdown);
            yield return new WaitForSeconds(1);
            playerscreenCountdown--;
        }

        GameManager.Instance.GameState = GameManager.GameStateEnums.InGame;
        Destroy(playerSceneCamera.gameObject);
        randomizeScene();
        //Debug.Log("SceneIndex: " + sceneIndex);
        //SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive); //add a minigamescene from list change to sceneIndex

    }

  



}
