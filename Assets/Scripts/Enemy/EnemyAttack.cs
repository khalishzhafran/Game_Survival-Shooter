using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;

    private void Awake()
    {
        //Mencari game object dengan tag "Player"
        player = GameObject.FindGameObjectWithTag("Player");

        //Mendapatkan komponen PlayerHealth
        playerHealth = player.GetComponent<PlayerHealth>();

        //Mendapatkan komponen Animator
        anim = GetComponent<Animator>();

        //Mendapatkan Enemy health
        enemyHealth = GetComponent<EnemyHealth>();
    }

    //Callback jika ada suatu object masuk ke dalam trigger
    private void OnTriggerEnter(Collider other)
    {
        //Set player in range
        if (other.gameObject == player && other.isTrigger == false)
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Set player in range
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack();
        }

        //Mentrigger animasi PlayerDead jika darah player <= 0
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead");
        }
    }

    void Attack()
    {
        //Reset timer
        timer = 0;

        //Taking Damage
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
