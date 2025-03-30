using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveControl : MonoBehaviour
{
    public static float damageCounter;

    public float counter;

    public float maxCounter;

    public GameObject message;

    public string scene;

    public void Start()
    {
        counter=damageCounter;
    }

    public void Update()
    {
        counter = damageCounter;
        if (damageCounter >= maxCounter)
        {
            message.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene(scene);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                damageCounter = 0;
            }
        }

    }

}
