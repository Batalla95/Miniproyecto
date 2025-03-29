using UnityEngine;

public class AmmoUp : MonoBehaviour
{
    public float ammoRecover;
    public Gun ammo1;
    public Gun ammo2;

    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        {
            if (ammo1.CurrentMaxAmmo < ammo1.MaxAmmo)
            {
                ammo1.CurrentMaxAmmo += ammoRecover;
                Destroy(gameObject);
            }

            if (ammo2.CurrentMaxAmmo < ammo2.MaxAmmo)
            {
                ammo2.CurrentMaxAmmo += ammoRecover;
                Destroy(gameObject);
            }

            if(ammo1.CurrentMaxAmmo < ammo1.MaxAmmo && ammo2.CurrentMaxAmmo < ammo2.MaxAmmo)
            {
                ammo1.CurrentMaxAmmo += ammoRecover/2;
                ammo2.CurrentMaxAmmo += ammoRecover/2;
                Destroy(gameObject);
            }
        }
        
    }
}
