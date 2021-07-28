using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OutScal.PlatFormer {
    public class AttackByPlayer : MonoBehaviour
    {
        [SerializeField] private Transform firePoint;
        [SerializeField] private GameObject bulletPrefab;
        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                SoundManager.Instance.Play(Sounds.GunFire);
            }
        }

        void Shoot()
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }

    }
}