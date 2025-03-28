using UnityEngine;

public class SpawnCreate : MonoBehaviour
{
    public GameObject player;
    public Transform spawn;

    public static Transform spawnPoint;

    public void Start()
    {
        spawnPoint = spawn;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           spawn.position = player.transform.position;
        }
    }
}
