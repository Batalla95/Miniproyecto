using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    public UnityEvent OnGunShoot;
    public float FireCooldown;
    public float RechargeCooldown;
    public float MaxAmmo;
    public float MaxMag;

    public bool Automatic;
    public bool InfinityAmmo;

    private float CurrentCooldown;
    private float CurrentRecharge;
    [SerializeField] private float CurrentMaxAmmo;
    [SerializeField] private float CurrentMaxMag;


    private void Start()
    {
        CurrentCooldown = FireCooldown;
        CurrentRecharge = RechargeCooldown;
        CurrentMaxAmmo = MaxAmmo;
        CurrentMaxMag = MaxMag;
        
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R)||CurrentMaxMag==0)
        {
            Recharge();
            CurrentCooldown = CurrentRecharge;
        }
        
        
        if (Automatic)
        {
            if (Input.GetButton("Fire1"))
            {
                if (CurrentCooldown <= 0 && CurrentMaxMag>0)
                {
                    OnGunShoot?.Invoke();
                    CurrentCooldown = FireCooldown;
                    CurrentMaxMag -= 1;
                    
                }
               
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (CurrentCooldown <= 0 && CurrentMaxMag > 0)
                {
                    OnGunShoot?.Invoke();
                    CurrentCooldown = FireCooldown;
                    CurrentMaxMag -= 1;
                }
                
            }
        }
        CurrentCooldown -= Time.deltaTime;
        CurrentRecharge -= Time.deltaTime;
    }


    public void Recharge()
    {
        if (InfinityAmmo)
        {
            CurrentMaxMag = MaxMag;
        }
        else if(CurrentMaxAmmo>0)
        {
            CurrentMaxAmmo -= MaxMag;
            CurrentMaxMag = MaxMag;
        }
    }
}
