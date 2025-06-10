using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : MonoBehaviour
//RAVVICINATO:  il nemico si attiva quando il player triggera nel collider più esterno
//Quando il collider interno collide con il player il nemuco si distrugge e richiama il metodo ApplyDamageToPlayer
{
    [Header ("Riferimenti da inserire manualmente")]
    [SerializeField] private Collider2D _externalCollider;
    [SerializeField] private Collider2D _internalCollider;

    private Transform _targetPlayer;
    private Enemy motherEnemy;
    private Rigidbody2D _rbEnemy;
    private Vector2 _direction;
    private bool _playerInRange = false;
    //private float _speedEnemy = 0;



    private void Awake()
    {
        _externalCollider = GetComponent<CircleCollider2D>();
        _internalCollider = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        motherEnemy = GetComponent<Enemy>();
        _rbEnemy = GetComponent<Rigidbody2D>();

        if (_targetPlayer == null)
        {
            PlayerController player = FindAnyObjectByType<PlayerController>(FindObjectsInactive.Include);
            _targetPlayer = player.transform;
        }
    }
    void FixedUpdate()
    {
        if (_direction != Vector2.zero)
        {
            float _speedEnemy = motherEnemy.GetSpeedEnemy();
            _rbEnemy.MovePosition(_rbEnemy.position + _direction * (_speedEnemy * Time.deltaTime));
        }

        if (_rbEnemy.velocity == Vector2.zero)
        {
            _direction = Vector2.zero;
        }
    }
    void Update()
    {
        if (_playerInRange)
        {
            UpdateDirection(_targetPlayer.transform.position - transform.position);
        }
    }
    public void UpdateDirection(Vector2 direction)
    {
        float sqrlenght = _direction.sqrMagnitude;
        if (sqrlenght > 1)
        {
            direction /= Mathf.Sqrt(sqrlenght);
        }
        _direction = direction;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Controlla se il player è entrato nel collider esterno
            if (other.IsTouching(_externalCollider))
            {
                _targetPlayer = other.transform;
                _playerInRange = true;
                Debug.Log("Player entrato nell'area esterna - Inseguimento attivato");
            }
            
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        if (collision.otherCollider == _internalCollider)
    //        {
    //            ApplyDamageToPlayer(collision.gameObject);
    //            Destroy(gameObject);
    //        }
    //    }
    //}

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Controlla se il player è completamente uscito dal collider esterno
            if (!other.IsTouching(_externalCollider))
            {
                _playerInRange = false;
                
            
                Debug.Log("Player uscito dall'area esterna - Inseguimento disattivato");
            }
            _rbEnemy.velocity = Vector2.zero;
            Debug.Log("Velocity a 0");
            
        }
    }

    private void ApplyDamageToPlayer(GameObject target)
    {
        Debug.Log("Togli 10 al player");
    }
}
