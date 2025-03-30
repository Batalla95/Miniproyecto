using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScript : MonoBehaviour
{
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        GameDataManager.ResetData();
    }
}
