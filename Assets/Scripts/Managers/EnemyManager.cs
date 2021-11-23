using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    //public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    [SerializeField]
    MonoBehaviour factory;
    IFactory Factory
    {
        get
        {
            return factory as IFactory;
        }
    }



    private void Start()
    {
        //Mengeksekusi fungsi spawn setiap beberapa detik sesuai dengan nilai spawnTime
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        //Jika player telah mati maka tidak membuat enemy baru
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        //Mendapatkan nilai random
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        //Menduplikasi enemy
        Factory.FactoryMethod(spawnPoints, spawnPointIndex);
    }
}
