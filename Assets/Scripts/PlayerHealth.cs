using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float StartingHealth;

    public float health;

    public GameObject player;

    public float Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;

            if (health <= 0f)
            {
                Health = StartingHealth;
                player.transform.position=SpawnCreate.spawnPoint.position;
            }
        }
    }

    private void Start()
    {
        Health = StartingHealth;
    }
}
