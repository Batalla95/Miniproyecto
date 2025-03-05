using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class DamageGun : MonoBehaviour
{
    List<String> Enemies=new List<String>();

    public float Damage;
    public float BulletRange;
    private Transform PlayerCamera;
    void Start()
    {
        PlayerCamera = Camera.main.transform;
    }

    // Update is called once per frame
  public void Shoot()
    {
        Ray gunRay = new Ray(PlayerCamera.position, PlayerCamera.forward);
        if(Physics.Raycast(gunRay, out RaycastHit hitInfo, BulletRange))
        {
            if(hitInfo.collider.gameObject.TryGetComponent(out Entity enemy))
            {
                enemy.Health -= Damage;
            }
        }
    }
}
