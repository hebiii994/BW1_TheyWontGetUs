using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private Weapon weaponPrefab;

    private void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            PlayerWeaponInventory inventory = other.GetComponent<PlayerWeaponInventory>();

            if (inventory != null)
            {
                inventory.AddWeapon(weaponPrefab);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("Il Player non ha un componente PlayerWeaponInventory!");
            }
        }
    }
}
