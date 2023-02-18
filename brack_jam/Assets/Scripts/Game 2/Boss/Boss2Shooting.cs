using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform player;

    void Start()
    {
        StartCoroutine(Shoot());
    }

    void Update()
    {
        transform.up = player.position - transform.position;
    }

    public IEnumerator Shoot()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation * Quaternion.Euler(0, 0, 90));
        yield return new WaitForSeconds(2f);
        StartCoroutine(Shoot());
    }
}
