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
    private bool isReloading=false;

    private float CurrentCooldown;
    private float CurrentRecharge;
    [SerializeField] private float CurrentMaxAmmo;
    [SerializeField] private float CurrentMaxMag;

    public GameObject gunFlash;

    [SerializeField]
    private AudioSource GunAudio;
    public AudioClip shoot;
    public AudioClip recharge;
    
    

    private void Start()
    {
        CurrentCooldown = FireCooldown;
        CurrentRecharge = RechargeCooldown;
        CurrentMaxAmmo = MaxAmmo;
        CurrentMaxMag = MaxMag;
        gunFlash.SetActive(false);
        
        
    }

    private void Update()
    {

        

        if (Input.GetKeyDown(KeyCode.R)||CurrentMaxMag==0)
        {
            Recharge();
            isReloading = true;
            Invoke(nameof(isReloadingReset), CurrentRecharge);
            GunAudio.PlayOneShot(recharge);
            
        }
        
        
        if (Automatic)
        {
            if (Input.GetButton("Fire1"))
            {
                if (CurrentCooldown <= 0 && CurrentMaxMag>0 && !isReloading)
                {
                    OnGunShoot?.Invoke();
                    gunFlash.SetActive(true);
                    CurrentCooldown = FireCooldown;
                    CurrentMaxMag -= 1;
                    GunAudio.PlayOneShot(shoot);
                    Invoke(nameof(SetOffGunFlash), 0.5f);
                    

                }
               
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (CurrentCooldown <= 0 && CurrentMaxMag > 0 && !isReloading)
                {
                    OnGunShoot?.Invoke();
                    gunFlash.SetActive(true);
                    CurrentCooldown = FireCooldown;
                    CurrentMaxMag -= 1;
                    Invoke(nameof(SetOffGunFlash), 0.5f);
                    GunAudio.PlayOneShot(shoot);

                }
                
            }
        }
        CurrentCooldown -= Time.deltaTime;
        
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

    public void isReloadingReset()
    {
        isReloading = false;
    }

    public void SetOffGunFlash()
    {
        gunFlash.SetActive(false);
    }
}
