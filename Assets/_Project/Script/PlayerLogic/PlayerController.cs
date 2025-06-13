using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    private Rigidbody2D _rb;
    [SerializeField] private float _speed = 5f;
    private float _h;
    private float _v;
    

    public Vector2 Direction { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");
        Direction = new Vector2(_h, _v).normalized;
    }

    private void FixedUpdate()
    {
        
        _rb.MovePosition(_rb.position + Direction *(_speed * Time.fixedDeltaTime));
    }
}
