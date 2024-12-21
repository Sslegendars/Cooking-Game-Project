using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField]
    private GameObject hasProgressGameObject;
    [SerializeField]
    private Image barImage;
    private IHasProgress hasProgress;
    private void Start()
    {   
        hasProgress = hasProgressGameObject.GetComponent<IHasProgress>();
        if(hasProgress == null)
        {
            Debug.LogError("Game Object" + hasProgressGameObject + "does not have a componenets that implement IHasPtogress");
        }
        hasProgress.OnProgressChanged += IHasProgress_OnProgressChanged;
        barImage.fillAmount = 0;
        Hide();
    }

    private void IHasProgress_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        barImage.fillAmount = e.progressNormalized;
        if(e.progressNormalized == 0 || e.progressNormalized == 1)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
