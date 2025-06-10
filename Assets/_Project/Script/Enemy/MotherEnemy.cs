using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherEnemy : MonoBehaviour
{
    //
    [SerializeField] private int _lifeEnemy;
    [SerializeField] private float _speedEnemy;
    [SerializeField] private int _damageEnemy;

    public int GetLifeEnemy() => _lifeEnemy;
    public float GetSpeedEnemy() => _speedEnemy;
    public int GetDamageEnemy() => _damageEnemy;

    public void SetLifeEnemy(int lifeEnemy)
    {
        _lifeEnemy = lifeEnemy;
        Debug.Log("La vita del nemico " + _lifeEnemy);
    }

    public void SetSpeedEnemy(float speedEnemy)
    {
        _speedEnemy = speedEnemy;
        Debug.Log("La velocità del nemico " + speedEnemy);
    }

    public void SetDamageEnemy(int damageEnemy)
    {
        _damageEnemy = damageEnemy;
        Debug.Log("Il danno del nemico " + damageEnemy);
    }
}