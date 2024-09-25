using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public Transform player;     
    public float moveSpeed = 3f;  
    public float shootingRange = 10f;  
    public GameObject bulletPrefab;    
    public Transform firePoint;        
    public float fireRate = 2f;        
    private float nextFireTime = 0f; 

    void Update()
    {
        // Déplacement vers le joueur
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer > shootingRange)
        {
            MoveTowardsPlayer();
        }

        if (distanceToPlayer <= shootingRange && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void MoveTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        Vector2 direction = (player.position - firePoint.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * 10f;  // 10f est la vitesse de la balle

        Destroy(bullet, 5f);
    }
}
