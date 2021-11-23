using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    NavMeshAgent nav;

    private void Awake()
    {
        //Cari gameObject dengan tag player
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //Mendapatkan reference component
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Memindahkan posisi player
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            nav.SetDestination(player.position);
        }
        //Hentikan moving
        else
        {
            nav.enabled = false;
        }
    }
}
