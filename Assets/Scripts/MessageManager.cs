using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
    public GameObject textContainer;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textContainer.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke(nameof(CloseText), 3f);
        }
    }

    public void CloseText()
    {
        textContainer.SetActive(false);
    }
}
