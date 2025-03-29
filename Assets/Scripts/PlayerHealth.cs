using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float StartingHealth;

    public float health;

    public GameObject player;

    public TMPro.TMP_Text vida;

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
                player.transform.position = SpawnCreate.spawnPoint.position;

               
            }

            if (vida != null)
            {
                vida.text = health + "/" + StartingHealth;
            }

        }
    }

    private void Start()
    {
        Health = StartingHealth;
    }
}
