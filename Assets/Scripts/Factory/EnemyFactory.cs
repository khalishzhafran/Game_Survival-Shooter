using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour, IFactory
{
    [SerializeField]
    public GameObject[] enemyPrefabs;

    public GameObject FactoryMethod(Transform[] spawnPoints, int tag)
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        GameObject enemy = Instantiate(enemyPrefabs[tag], spawnPoints[tag].position, spawnPoints[tag].rotation);

        return enemy;
    }
}
