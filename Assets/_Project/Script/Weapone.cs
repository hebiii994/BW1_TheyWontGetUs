using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Weapone : MonoBehaviour
{

    [SerializeField] GameObject BaseBullet;


    private float FireRate { get; set; } = 1;
    private int Proiettili { get; set; } = 15;
    private float _Timer = 0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Transform bersaglio = FindNearestEnemy();
        if (bersaglio != null)
        {
            _Timer += Time.deltaTime;
            if (_Timer >= FireRate && Proiettili > 0)
            {
                GameObject bullet = Instantiate(BaseBullet, transform.position, Quaternion.identity);

                Proiettili--;
                Debug.Log("Proiettili rimanenti: " + Proiettili);

                _Timer = 0;
            }



        }
    }
    Transform FindNearestEnemy()
    {
        GameObject[] nemici = GameObject.FindGameObjectsWithTag("Enemy");
        Transform nemicoVicino = null;
        float distanzaMinima = Mathf.Infinity;
        Vector3 posizioneGiocatore = transform.position;

        foreach (GameObject nemico in nemici)
        {
            float distanza = Vector3.Distance(posizioneGiocatore, nemico.transform.position);
            if (distanza < distanzaMinima)
            {
                distanzaMinima = distanza;
                nemicoVicino = nemico.transform;
            }
        }

        return nemicoVicino;
    }
}
