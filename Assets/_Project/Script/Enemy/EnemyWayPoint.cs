using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyWayPoint : Enemy
{
    //ARRAY per tutti i punti in cui deve passare il nemico
    [SerializeField] private Transform[] _wayPoint;
    //Primo wayPoint da cui inizia
    private int _currentWaypointIndex = 0;


    protected override void Move()
    {
        if (_wayPoint.Length == 0)
        {
            Debug.Log("Asseganre wayPoint al nemico " + gameObject.name);
        }

        //Non so come mai dentro start attiva la gravità
        for (int i = 0; i < _wayPoint.Length; i++)
        {
            if (_wayPoint[i] != null)
            {
                SpriteRenderer sr = _wayPoint[i].GetComponent<SpriteRenderer>();
                //Non è setActive, perché è una variabile
                sr.enabled = false;
            }
        }

        Transform targetWaypoint = _wayPoint[_currentWaypointIndex];

        Vector2 direction = (targetWaypoint.position - transform.position).normalized;
        rb.velocity = direction * Speed;

        float distance = Vector2.Distance(transform.position, targetWaypoint.position);

        // Tolleranza per dire "ci siamo arrivati"
        if (distance < 0.1f)
        {
            _currentWaypointIndex++;

            // Se siamo arrivati all'ultimo waypoint, si riparte da capo
            if (_currentWaypointIndex >= _wayPoint.Length)
            {
                _currentWaypointIndex = 0;
            }
        }
    }
}
