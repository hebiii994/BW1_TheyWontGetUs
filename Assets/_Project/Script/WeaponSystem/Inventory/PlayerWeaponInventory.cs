using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerWeaponInventory : MonoBehaviour
{
    [SerializeField] private Transform _weaponHolder;
    private List<Weapon> _activeWeapons = new List<Weapon>();

    private void Awake()
    {
        
        if (_weaponHolder == null)
        {
            _weaponHolder = transform;
        }
    }

    public void AddWeapon(Weapon weaponPrefab)
    {
        Weapon existingWeapon = _activeWeapons.FirstOrDefault(w => w.name.StartsWith(weaponPrefab.name));
        if (existingWeapon != null)
        {
            existingWeapon.LevelUp();
            Debug.Log("Arma potenziata: " + existingWeapon.name);
        }
        else
        {
            Weapon newWeapon = Instantiate(weaponPrefab, _weaponHolder.position, Quaternion.identity);
            newWeapon.transform.SetParent(_weaponHolder);
            _activeWeapons.Add(newWeapon);
            Debug.Log("Nuova arma equipaggiata: " + newWeapon.name);
        }
    }

}
