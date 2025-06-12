using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour

{
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _maxHealth = 10;
    [SerializeField] private bool _isPlayer;

    public enum ON_DEFEAT_BEHAVIOUR {DISABLE = 0, DESTROY = 1, NONE = 2}
    [SerializeField] private ON_DEFEAT_BEHAVIOUR _onDefeatBehaviour = ON_DEFEAT_BEHAVIOUR.DISABLE;


    public float CurrentHealth => _currentHealth;
    
    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void Die()
    {
        if (_currentHealth == 0)
        {
            switch (_onDefeatBehaviour)
            {
                default:
                    break;

                case ON_DEFEAT_BEHAVIOUR.DISABLE:
                    gameObject.SetActive(false);
                    break;
                case ON_DEFEAT_BEHAVIOUR.DESTROY:
                    //SUONO PER LA MORTE
                    Destroy(gameObject);
                    break;
                case ON_DEFEAT_BEHAVIOUR.NONE:
                    break;
            }
        }
    }
      
    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        Debug.Log($"{gameObject.name} ha subito {damage} danni. E ora ha {_currentHealth} di vita."); 
        // INSERIRE CLIP AUDIO PER QUANDO VIENE COLPITO
    }


}
