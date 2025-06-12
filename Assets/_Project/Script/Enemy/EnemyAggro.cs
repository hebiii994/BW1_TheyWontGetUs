using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggro : Enemy
//RAVVICINATO:  il nemico si attiva quando il player triggera nel collider più esterno
//Quando il collider interno collide con il player il nemuco si distrugge e richiama il metodo ApplyDamageToPlayer
{
    [Header ("Riferimenti da inserire manualmente")]
    [SerializeField] private CircleCollider2D aggroRadiusCollider;

    private bool isPlayerInRange = false;

    protected override void Awake()
    {
        base.Awake();
        if (aggroRadiusCollider != null)
        {
            aggroRadiusCollider.isTrigger = true;
        }
        else
        {
            Debug.LogError("Collider per l'aggro non assegnato su " + gameObject.name);
        }
    }
    protected override void Move()
    {
        if (isPlayerInRange && playerTarget != null)
        {
            Vector2 direction = (playerTarget.position - transform.position).normalized;
            rb.velocity = direction * Speed; //rb e Speed li prendiamo dalla classe madre
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Se il player entra nel nostro raggio del player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entrato nel raggio. Inseguimento ATTIVATO.");
            isPlayerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        // Se il player esce dal nostro raggio del player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player uscito dal raggio. Inseguimento DISATTIVATO.");
            isPlayerInRange = false;
        }
    }
}
