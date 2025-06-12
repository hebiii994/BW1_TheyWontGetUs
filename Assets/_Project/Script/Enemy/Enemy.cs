using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    
    
    [SerializeField] private float _speed = 3f;
    [SerializeField] private int _damage = 10;
    [SerializeField] [Range(0, 100)] private float dropChance = 15f;
    [SerializeField] private GameObject itemToDrop;
    

    
    protected Transform playerTarget;
    protected Rigidbody2D rb;

    public float Speed { get { return _speed; } }
    public int Damage { get { return _damage; } }

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    protected virtual void Start()
    {
        
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

            LifeController playerLife = collision.gameObject.GetComponent<LifeController>();
            if (playerLife != null)
            {
                playerLife.TakeDamage(_damage);
            }
            Debug.Log(gameObject.name + " si autodistrugge");
            Destroy(gameObject);
            
        }
    }

    public void Die()
    {
        Debug.Log(gameObject.name + " muore");
        GameManager.Instance.AddKill();
        HandleDrop();
        Destroy(gameObject); // distruggiamo il nemico
    }

}