using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_AutoAim : Weapon
{
    // Start is called before the first frame update
    protected override void Fire()
    {
        if (projectilePrefab == null || currentTarget == null)
        {
            Debug.LogWarning("Proiettile o bersaglio mancante per l'arma AutoAim.");
            return;
        }

        GameObject bullet = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Bullet bulletController = bullet.GetComponent<Bullet>();
        if (bulletController != null)
        {
            Vector2 direction = (currentTarget.position - transform.position).normalized;
            bulletController.SetDirection(direction);
        }
    }
}
