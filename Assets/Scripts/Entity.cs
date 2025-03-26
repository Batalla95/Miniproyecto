using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private float StartingHealth;

    public float health;
    public GameObject target;

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
