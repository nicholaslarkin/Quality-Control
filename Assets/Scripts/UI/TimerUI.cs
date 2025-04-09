using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    private KOTHTimer timerSource;

    void Start()
    {
        // Get the timer from the player this UI is attached to
        timerSource = GetComponentInParent<KOTHTimer>();
    }

    void Update()
    {
        if (timerSource == null) return;

        float time = timerSource.TimeRemaining;

        // Show time as ss
        float seconds = time % 60f;
        timerText.text = $"{seconds:00.0}";
    }
}
