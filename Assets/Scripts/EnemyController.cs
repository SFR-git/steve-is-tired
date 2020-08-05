﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region variables
    [Tooltip("CircleCollider radius")]
    public float range;

    [Tooltip("Time between enemy attacks in seconds")]
    public float timeBetweenAttacks;
    [Tooltip("Eenemy attack legth in seconds")]
    public float attackLength;
    float attackTime;

    bool isAttacking;

    CircleCollider2D circleCollider;
    Rigidbody2D rb;
    AudioSource source;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

        circleCollider = gameObject.AddComponent<CircleCollider2D>();
        circleCollider.radius = range / transform.localScale.x;
        circleCollider.isTrigger = true;
        circleCollider.enabled = false;

        attackTime = timeBetweenAttacks;
    }

    private void Update()
    {
        attackTime -= Time.deltaTime;

        if (attackTime <= 0)
        {
            if (!isAttacking)
            {
                StartAttack();
                attackTime = attackLength;
            }
            else
            {
                StopAttack();
                attackTime = timeBetweenAttacks;
            }
        }
    }

    public void StartAttack()
    {
        circleCollider.enabled = true;
        isAttacking = true;
        source.Play();
    }

    public void StopAttack()
    {
        circleCollider.enabled = false;
        isAttacking = false;
        source.Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
            player.StartRewind(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
            player.StopRewind();
    }

    private void OnDrawGizmos()
    {
        Color prevColor = Gizmos.color;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.color = prevColor;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }
}
