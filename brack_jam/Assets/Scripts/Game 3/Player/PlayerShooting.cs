using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public bool canShoot = true;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            Shoot();
        }

        
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation * Quaternion.Euler(0, 0, 90));
        StartCoroutine(ShootDelay());
    }

    public IEnumerator ShootDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(0.3f);
        canShoot = true;
    }
}
