using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Transform TargetEnemyPosition;

    private float speed { get; set; } = 9f;
    public int dannoBullet { get; set; } = 20;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (TargetEnemyPosition != null)
        {

            transform.position = Vector2.MoveTowards(transform.position, TargetEnemyPosition.position, speed * Time.deltaTime);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {



        }
    }
}
