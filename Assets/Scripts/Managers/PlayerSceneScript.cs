using UnityEngine;

public class PlayerSceneScript : MonoBehaviour
{
    [SerializeField] private bool countdownStart = false;
    void Update()
    {
        //starts countdown when player count reaches 2 at minimum when testing change 2 to 1 for single player
        if (PlayerManager.playerList.Count >= 1 && countdownStart == false)
        {
            StartCoroutine(GetComponent<SceneTransition>().StartCountdown());
            countdownStart = true;
        }
        
    }

    
}
