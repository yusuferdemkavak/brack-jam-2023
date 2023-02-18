using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;

    public float fireRate = 0.3f;
    public GameObject bulletPrefab;

    public bool isShooting = false;

    void Update()
    {
        float horizontal = 0;
        float vertical = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
            horizontal = -1;
        else if (Input.GetKey(KeyCode.RightArrow))
            horizontal = 1;

        if (Input.GetKey(KeyCode.UpArrow))
            vertical = 1;
        else if (Input.GetKey(KeyCode.DownArrow))
            vertical = -1;

        if ((horizontal != 0 || vertical != 0 ) && isShooting == false)
        {
            float angle = Mathf.Atan2(vertical, horizontal) * Mathf.Rad2Deg;

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            
            StartCoroutine(ShootingCooldown());
        }
    }

    public IEnumerator ShootingCooldown()
    {
        isShooting = true;
        yield return new WaitForSeconds(fireRate);
        isShooting = false;
    }
}
