
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
    public int sceneIndex;
    public int nextSceneIndex;
    private Scene MainMenu;
    private Scene playerJoinScene;
    private Scene kothScene;
    private Scene boxScene;
    private Scene electricScene;
    [SerializeField] private int playerscreenCountdown = 2;
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

    //private void StartGame()
    //{
    //    SceneManager.LoadScene(playerJoinScene.buildIndex);
    //}
    private void randomizeScene(List<Scene> minigamesAvail)
    {
        //clear and re add minigames to the list if only 1 choice availible
        if (minigamesAvail.Count <= 1)
        {
            Debug.Log("Refreshed in randomizeScene");
            refreshSceneCount();
        }
        nextSceneIndex = Random.Range(1, minigameScenes.Count);
        while (nextSceneIndex == sceneIndex)
        {
            nextSceneIndex = Random.Range(1, 4);
            Debug.Log("Nextsceneindex: " + nextSceneIndex);
        }

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
            case GameManager.GameStateEnums.InGame:
                SceneManager.UnloadSceneAsync(minigameScenes[sceneIndex]);
                randomizeScene(minigameScenes);
                SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
                minigameScenes.RemoveAt(sceneIndex);
                break;
            case GameManager.GameStateEnums.GameOver:
                break;


        }
    }

    public System.Collections.IEnumerator StartCountdown()
    {
        
        while(playerscreenCountdown > 0){
            Debug.Log("Join time remaining: " + playerscreenCountdown);
            yield return new WaitForSeconds(1);
            playerscreenCountdown --;
        }

        GameManager.Instance.GameState = GameManager.GameStateEnums.InGame;
        Destroy(playerSceneCamera.gameObject);
        randomizeScene(minigameScenes);
        sceneSelected = minigameScenes[sceneIndex].name;
        //Debug.Log("MinigameScene Name: " + minigameScenes[sceneIndex].name);
        //Debug.Log("sceneSelected name: " + sceneSelected.name);
        Debug.Log("minigameScenes count" + minigameScenes.Count);
        Debug.Log("NextSceneIndex: " + nextSceneIndex);
        Debug.Log("SceneIndex: " + sceneIndex);
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive); //add a minigamescene from list
        //minigameScenes.RemoveAt(sceneIndex); //remove that scene from the list

    }

    //bool IsSceneLoaded(string name)
    //{
    //    // Check if the scene is already loaded
    //    for (int i = 0; i < SceneManager.sceneCount; i++)
    //    {
    //        Scene scene = SceneManager.GetSceneAt(i);
    //        if (scene.name == name && scene.isLoaded)
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}

    //void GoToScene()
    //{
    //    if (sceneIndex == 0)
    //    {
    //        SceneManager.LoadScene(0);
    //    }
    //    if (sceneIndex == 1)
    //    {
    //        SceneManager.LoadScene(1);
    //    }
    //    if (sceneIndex == 2)
    //    {
    //        SceneManager.LoadScene(2);
    //    }
    //    if (sceneIndex == 3)
    //    {
    //        SceneManager.LoadScene(3);
    //    }
    //    if (sceneIndex == 4)
    //    {
    //        SceneManager.LoadScene(4);
    //    }
    //    if (sceneIndex == 5)
    //    {
    //        SceneManager.LoadScene(5);
    //    }
    //}




}
