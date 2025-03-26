using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class DamageGun : MonoBehaviour
{
   

    public float Damage;
    public float BulletRange;
    public Transform GunTransform;


    
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
                    Debug.Log("Toma mamon");
                    closestEnemy.Health -= Damage;
                    if (closestEnemy.Health <= 0)
                    {
                        if (closestEnemy != null)
                        {
                            enemyIsInRange.Remove(closestEnemy);
                            Debug.Log("El enemigo ha salido");

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
                Debug.Log("Enemigo detectado y añadido a la lista");
            enemy.target.SetActive(true);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Entity enemy = other.gameObject.GetComponent<Entity>();

        if (enemy != null)
        {
            enemyIsInRange.Remove(enemy);
            Debug.Log("El enemigo ha salido");
            enemy.target.SetActive(false);
        }
    }
}
