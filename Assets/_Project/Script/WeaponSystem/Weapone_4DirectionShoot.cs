using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapone_4DirectionShoot : Weapon
{
    public float bulletSpeed = 5f;
    protected override void Fire()
    {
        if (projectilePrefab == null || currentTarget == null)
        {
            Debug.LogWarning("Proiettile o bersaglio mancante per l'arma MultiDirezione.");
            return;
        }

        // Quattro direzioni: su, giù, sinistra, destra
        Vector2[] directions = new Vector2[]
        {
        Vector2.up,
        Vector2.down,
        Vector2.left,
        Vector2.right
        };

        foreach (Vector2 direction in directions)
        {
            GameObject bullet = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Bullet bulletController = bullet.GetComponent<Bullet>();

            if (bulletController != null)
            {
                Vector2 direzione = (currentTarget.position - transform.position).normalized;
                bulletController.SetDirection(direction);
            }

        }
    }
}
