using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class DamageGun : MonoBehaviour
{
   

    public float Damage;
    public float BulletRange;
    public Transform GunTransform;

    public AudioSource enemyDamage;
    public AudioClip enemyDamageClip;



    [SerializeField]
    private List<Entity> enemyIsInRange = new List<Entity>();
   

    // Update is called once per frame
  public void Shoot()
    {
        if (enemyIsInRange.Count > 0)
        {
            Entity closestEnemy = GetClosestEnemy();

            

            Vector3 direction = (closestEnemy.transform.position - GunTransform.position);

           
                if (closestEnemy.GetComponent<Entity>())
                {
                enemyDamage.PlayOneShot(enemyDamageClip);
                    closestEnemy.Health -= Damage;
                    if (closestEnemy.Health <= 0)
                    {
                        if (closestEnemy != null)
                        {
                            enemyIsInRange.Remove(closestEnemy);
                           

                        }
                    }
                }
            
        }
    }


    Entity GetClosestEnemy()
    {
        Entity closestEnemy = null;

        float minDistance = float.MaxValue;

        foreach(Entity enemy in enemyIsInRange)
        {
            float distance = Vector3.Distance(GunTransform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Entity enemy = other.gameObject.GetComponent<Entity>();

        if (enemy != null)
        {
            
                enemyIsInRange.Add(enemy);
                
            enemy.target.SetActive(true);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Entity enemy = other.gameObject.GetComponent<Entity>();

        if (enemy != null)
        {
            enemyIsInRange.Remove(enemy);
           
            enemy.target.SetActive(false);
        }
    }
}
