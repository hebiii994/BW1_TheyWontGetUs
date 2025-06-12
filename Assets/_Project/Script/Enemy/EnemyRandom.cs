using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandom : Enemy
{
    [SerializeField] private CircleCollider2D randomEnemyCollider;
    private Vector2 randomDirezione;
    private float timer = 0f;
    private float interval = 0.5f;
    private bool isPlayerInRange = false;

    protected override void Awake()
    {
        base.Awake();
        if (randomEnemyCollider != null)
        {
            randomEnemyCollider.isTrigger = true;
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

        ////Utilizzando Vector3 mi restituisce solo un movimento verso destra o verso sinistra
            //Vector3 prodottoRandom = Vector3.Cross(playerTarget.position, transform.position).normalized;

            //Vector2 direction = (prodottoRandom - playerTarget.position).normalized;
            //rb.velocity = direction * Speed; //rb e Speed li prendiamo dalla classe madre

            //Utilizzando una terza variabile che randomizzi
            Vector2 toPlayer = (playerTarget.position - transform.position).normalized;

           // Vector2 Perp = new Vector2(-toPlayer.y, toPlayer.x);

            Vector2 direction = (toPlayer + randomDirezione).normalized;

            rb.velocity = direction * Speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime; 

        if (timer >= interval)
        {
            timer = 0f; 
            randomDirezione = new Vector2(Random.Range(-20, 20), Random.Range(-20, 20)).normalized;
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