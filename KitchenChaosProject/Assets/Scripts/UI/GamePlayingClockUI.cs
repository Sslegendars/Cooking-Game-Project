using UnityEngine.UI;
using UnityEngine;

public class GamePlayingClockUI : MonoBehaviour
{
    [SerializeField]
    private Image timerImage;
    private void Update()
    {
        timerImage.fillAmount = GameManager.Instance.GetGamePlayingTimerNormalized();
    }
}
