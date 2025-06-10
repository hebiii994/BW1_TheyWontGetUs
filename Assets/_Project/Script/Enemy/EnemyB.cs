using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB : MonoBehaviour
//DISTANZA: il nemico si attiva quando il player triggera il collider più esterno e inizia a sparare 
{
    [Header("Collider esterno che fa da range")]
    [SerializeField] private Collider2D _externalCollider;
    [Header("Spawn point che fa da arma")]
    [SerializeField] private Transform _spawnPoint;
    [Header("Proiettile")]
    [SerializeField] private GameObject _bulletPrefab;
    [Header("Intervallo di sparo")]
    [SerializeField] private float _shotInterval = 0.5f;

    private float _lastShotTimer = 0;
    private bool _playerInRange;

    public bool CanShoot()
    {
        return Time.time - _lastShotTimer >= _shotInterval;
    }
    public void Shoot(Vector3 position, Vector3 direction)
    {
        _lastShotTimer = Time.time;

        GameObject clone = Instantiate(_bulletPrefab);
        Shoot(position, direction);
    }
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(_playerInRange)
        {
            TryShoot(_spawnPoint.position, _spawnPoint.up);
        }
    }
    private void TryShoot(Vector3 position, Vector3 direction)
    {
        if (!CanShoot()) return;
        
        Shoot(position, direction);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInRange = true;
        }
    }
}


