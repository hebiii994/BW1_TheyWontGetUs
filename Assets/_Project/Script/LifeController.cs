using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour

{
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _maxHealth = 10;
    [SerializeField] private bool _isPlayer;

    //public enum ON_DEFEAT_BEHAVIOUR {DISABLE = 0, DESTROY = 1, NONE = 2}
    //[SerializeField] private ON_DEFEAT_BEHAVIOUR _onDefeatBehaviour = ON_DEFEAT_BEHAVIOUR.DISABLE;  <-- spostiamolo nei nemici/player
    private Enemy enemyComponent;

    public float CurrentHealth { get; private set; }

    private void Awake()
    {
        CurrentHealth = _maxHealth;
        if (!_isPlayer)
        {
            enemyComponent = GetComponent<Enemy>();
            if (enemyComponent == null)
            {
                Debug.LogError("LifeController (non player) non ha trovato un componente Enemy!", gameObject);
            }
        }
    }

    //Ora gestito su Enemy
    //public void Die()
    //{
    //    if (_currentHealth == 0)
    //    {
    //        switch (_onDefeatBehaviour)
    //        {
    //            default:
    //                break;

    //            case ON_DEFEAT_BEHAVIOUR.DISABLE:
    //                gameObject.SetActive(false);
    //                break;
    //            case ON_DEFEAT_BEHAVIOUR.DESTROY:
    //                //SUONO PER LA MORTE
    //                Destroy(gameObject);
    //                break;
    //            case ON_DEFEAT_BEHAVIOUR.NONE:
    //                break;
    //        }
    //    }
    //}
      
    public void TakeDamage(float damage)
    {
        if (CurrentHealth <= 0) return;
        CurrentHealth -= damage;
        Debug.Log($"{gameObject.name} ha subito {damage} danni. Vita rimanente: {CurrentHealth}");

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            if (!_isPlayer && enemyComponent != null)
            {
                enemyComponent.Die();
            }
        }
        // INSERIRE CLIP AUDIO PER QUANDO VIENE COLPITO
    }


}
