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

            if (health > 100)
            {
                health = 100;
            }

            if (vida != null)
            {
                vida.text = health + "/" + StartingHealth;
            }

            GameDataManager.PlayerHealth = health;
        }
    }

    private void Start()
    {
        if (GameDataManager.PlayerHealth > 0)
        {
            health = GameDataManager.PlayerHealth;
        }
        else
        {
            health = StartingHealth;
        }

        if (vida != null)
        {
            vida.text = health + "/" + StartingHealth;
        }

    }
}
