using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject optionsMenu;



    public void Start()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Options()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReturnMainMenu()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        
    }


}
