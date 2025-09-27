using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float attackRange = 3f;
    public float attackInterval = 1f;
    public int attackDamage = 1;
    public GameObject bulletPrefab;
    public Transform firePoint;
    private float timer;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > attackInterval)
        {
            Enemy target = FindTarget();
            if (target != null)
            {
                Shoot(target);
                timer = 0;
            }
        }
    }

    Enemy FindTarget()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
        Enemy nearest = null;
        float shortestDistance = Mathf.Infinity;

        foreach (Enemy e in enemies)
        {
            float distance = Vector3.Distance(transform.position, e.transform.position);
            if (distance <= attackRange && distance < shortestDistance)
            {
                shortestDistance = distance;
                nearest = e;
            }
        }
        return nearest;
    }

    // ’e‚ğ”­Ë
    void Shoot(Enemy target)
    {
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Bullet b = bullet.GetComponent<Bullet>();
            if (b != null)
            {
                b.SetTarget(target, attackDamage);
            }
        }
    }

    // Ë’ö‚ğ‰Â‹‰»iEditor—pj
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
