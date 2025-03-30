using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject door;
    public GameObject message;

    public bool canPick=false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&canPick)
        {
            message.SetActive(false);
            door.SetActive(false);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            message.SetActive(true);
            canPick = true;
        }
        
    }
}
