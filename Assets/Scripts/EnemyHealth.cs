﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    
    public float value = 100;
    public Animator animator;
    public PlayerProgress playerProgress;

    public bool IsAlive()
    {
        return value < 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerProgress = FindObjectOfType<PlayerProgress>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DealDamage(float damage)
    {
        playerProgress.AddExperience(damage);
        value -= damage;
        if (value <= 0)
        {
            EnemyDeath();
            //Destroy(gameObject);
        }
        else
        {
            animator.SetTrigger("hit");
        }
    }
    private void EnemyDeath()
    {
        animator.SetTrigger("death");
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        
    }
}
