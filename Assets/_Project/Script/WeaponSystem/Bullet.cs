using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float _speed = 12f;
    [SerializeField] private int _damage = 25;

    private Vector2 _moveDirection;
    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        //distruggiamo il proiettile dopo 5 secondi 
        Destroy(gameObject, 5f);
    }

    public void SetDirection(Vector2 direction)
    {
        _moveDirection = direction.normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //applichiamo la speed alla direzione (il SetDirection lo chiama l'arma quando spara)
        _rb.velocity = _moveDirection * _speed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.isTrigger)
        {
            return; 
        }

        LifeController life = other.GetComponent<LifeController>();
        if (life != null)
        {
            life.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
