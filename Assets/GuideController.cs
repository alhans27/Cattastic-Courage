using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideController : MonoBehaviour
{
    [SerializeField] private int fishItemMinimum;
    [SerializeField] private GameObject popUpMessage;
    [SerializeField] private GameObject finishGate;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance.GetFishItem() >= fishItemMinimum)
            {
                ShowSuccessMessage();
                finishGate.SetActive(true);
            }
            else
            {
                ShowAlertMessage(fishItemMinimum);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HideMessage();
        }
    }

    private void ShowAlertMessage(int keyValue)
    {
        // Debug.Log($"You must collect Fish Item {keyValue} in minimum!");
        popUpMessage.gameObject.GetComponentInChildren<TextMesh>().text = $"You must collect\nat least {keyValue} fish items";
        popUpMessage.SetActive(true);

    }
    private void HideMessage()
    {
        popUpMessage.SetActive(false);

    }
    private void ShowSuccessMessage()
    {
        popUpMessage.gameObject.GetComponentInChildren<TextMesh>().text = "Congratulations! Good luck\non your next journey";
        popUpMessage.SetActive(true);

    }
}
