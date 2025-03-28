using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private float StartingHealth;

    public float health;
    public GameObject target;
    EnemyController enemyController;

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
                enemyController.Death(true);
                Invoke(nameof(Eliminate), 3.5f);
            }
        }
    }

    private void Start()
    {
        Health = StartingHealth;
        enemyController = GetComponent<EnemyController>();
    }

    public void Eliminate()
    {
        Destroy(gameObject);
    }

}
