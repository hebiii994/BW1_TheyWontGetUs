using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    
    [SerializeField] private int _maxLife = 100;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private int _damage = 10;
    [SerializeField] private float dropChance = 15f;
    [SerializeField] private GameObject itemToDrop;
    [SerializeField] private LifeController _lifeController;

    protected int currentHealth;
    protected Transform playerTarget;
    protected Rigidbody2D rb;

    public int MaxHealth { get { return _maxLife; } }
    public float Speed { get { return _speed; } }
    public int Damage { get { return _damage; } }

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _lifeController = GetComponent<LifeController>();
    }

    protected virtual void Start()
    {
        currentHealth = _maxLife;
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected virtual void Update()
    {
        if (playerTarget == null) return;
        Move();
    }

    protected abstract void Move();

    protected void HandleDrop()
    {
        if (itemToDrop != null)
        {
            float randomValue = Random.Range(0f, 100f);
            if (randomValue <= dropChance)
            {
                Instantiate(itemToDrop, transform.position, Quaternion.identity);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
                _lifeController.TakeDamage(_damage);
                Destroy(gameObject);
            
        }
    }

}