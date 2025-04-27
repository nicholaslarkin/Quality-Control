using UnityEngine;

public class PlayerSceneScript : MonoBehaviour
{
    [SerializeField] private bool countdownStart = false;
    void Update()
    {
        if (PlayerManager.playerList.Count == 1 && countdownStart == false)
        {
            StartCoroutine(GetComponent<SceneTransition>().StartCountdown());
            countdownStart = true;
        }
        
    }

    
}
