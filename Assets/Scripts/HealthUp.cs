using UnityEngine;

public class HealthUp : MonoBehaviour
{
    public float healthAmount;
    public PlayerHealth life;

    private void OnTriggerEnter(Collider other)
    {
         

        if (other.CompareTag("Player")&& life.Health < 100)
        {
            life.Health += healthAmount;
            Destroy(gameObject);
        }
    }
}
