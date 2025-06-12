using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected float fireRate = 1f;


    private float _fireTimer;
    private float _targetAcquisitionTimer;
    protected Transform currentTarget; // il nemico da targettare

    //bersaglio
    [SerializeField] protected string targetTag = "Enemy";


    // Update is called once per frame
    protected virtual void Update()
    {
        _targetAcquisitionTimer += Time.deltaTime;  
        if (_targetAcquisitionTimer >= 0.25f) // ogni 0.25 cerchiamo un target
        {
            AcquireTarget();
            _targetAcquisitionTimer = 0f;
        }
        _fireTimer += Time.deltaTime;

        if (_fireTimer >= 1f / fireRate)
        {
            if (currentTarget != null)
            {
                Fire(); // lo implementiamo nelle sottoclassi reali
                _fireTimer = 0f;
            }
        }

    }

    // Trova il nemico più vicino all'arma e lo imposta come 'currentTarget'.
    // Trova tutti gli oggetti con il tag "Enemy", calcola la distanza ps: lo facciamo ogni 0.25 e non ogni frame per ottimizzare
    // memorizza il più vicino.
    private void AcquireTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);
        Transform nearestTarget = null;
        float minDistance = Mathf.Infinity;
        foreach (GameObject target in targets)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestTarget = target.transform;
            }
        }
        currentTarget = nearestTarget;
    }
    public virtual void LevelUp()
    {
        //da pensare i vari potenziamenti
        fireRate *= 1.2f;
        Debug.Log(gameObject.name + " Level Up! Nuovo rateo di fuoco: " + fireRate);
    }
    protected abstract void Fire(); //ogni arma avrà la sua logica di sparo

}
