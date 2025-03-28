using UnityEngine;

public class PitfallControll : MonoBehaviour
{
    
    public GameObject player;

    public PlayerHealth health;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.position = SpawnCreate.spawnPoint.position;
            health.Health-=25;
        }
    }
}
