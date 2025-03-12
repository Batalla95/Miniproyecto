using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float StartingHealth;

    public float health;

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
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        Health = StartingHealth;
    }
}
