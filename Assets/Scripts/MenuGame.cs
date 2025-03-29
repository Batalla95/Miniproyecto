using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class MenuGame : MonoBehaviour
{
    public GameObject gameMenu;
    public GameObject optionsMenu;
    public bool isPaused=false;

    public void Start()
    {
        gameMenu.SetActive(false);
        optionsMenu.SetActive(false);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&!isPaused)
        {
            PauseGame();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            isPaused = true;
        }
    }

    private void PauseGame()
    {
        gameMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void UnpauseGame()
    {
        gameMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;


    }

    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void Options()
    {
        gameMenu.SetActive(false);
        optionsMenu.SetActive(true);
        

    }
    public void ReturnMenu()
    {
        gameMenu.SetActive(true);
        optionsMenu.SetActive(false);
        
    }


}
