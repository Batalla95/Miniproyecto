using UnityEngine;

public class MineBehaviour : MonoBehaviour
{
    public PlayerHealth health;
    public float damage;
    public AudioClip explosion;
    public AudioClip preExplosion;
    public AudioSource audioSource;
    public GameObject VFXExplosion;

    public bool playerInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(preExplosion);
            Invoke(nameof(Explosion), 2f);
            Invoke(nameof(DestroyMine), 4f);
            playerInRange = true;
        }
        
        
        

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }

    public void DestroyMine()
    {
        Destroy(gameObject);
    }

    public void Explosion()
    {
        
        audioSource.PlayOneShot(explosion);
        VFXExplosion.SetActive(true);
        if (playerInRange)
        {
            health.Health -= damage;
        }
    }
}
