using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMolotov : Bullet
{

    private float ExplosionTimer = 6f;

    private float timer = 0f;

    CircleCollider2D Molotov;


    // Start is called before the first frame update
    void Start()
    {

        {
            Molotov = GetComponent<CircleCollider2D>();
            if (Molotov != null)
            {
                Molotov.enabled = false;
            }
            else
            {
                Debug.LogWarning("Molotov collider non trovato!");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }



}
