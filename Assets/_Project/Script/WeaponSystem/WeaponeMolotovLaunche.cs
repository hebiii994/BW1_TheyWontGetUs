using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponeMolotovLaunche : Weapon
{
    protected override void Fire()
    {
        if (projectilePrefab == null || currentTarget == null)
        {
            Debug.LogWarning("Proiettile o bersaglio mancante per l'arma MultiDirezione.");
            return;
        }
        GameObject bullet = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Bullet bulletController = bullet.GetComponent<Bullet>();

        if (bulletController != null)
        {
            Vector2 direzione = (currentTarget.position - transform.position).normalized;
            bulletController.SetDirection(direzione);
        }
    }
}
