using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    public UnityEvent OnGunShoot;
    public float FireCooldown;

    public bool Automatic;

    private float CurrentCooldown;

    private void Start()
    {
        CurrentCooldown = FireCooldown;
    }

    private void Update()
    {
        if (Automatic)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (CurrentCooldown <= 0)
                {
                    OnGunShoot?.Invoke();
                    CurrentCooldown = FireCooldown;
                }
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (CurrentCooldown <= 0)
                {
                    OnGunShoot?.Invoke();
                    CurrentCooldown = FireCooldown;
                }
            }
        }
        CurrentCooldown -= Time.deltaTime;
    }
}
