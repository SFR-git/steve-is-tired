﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    #region variables
    public bool isHeld = false;
    bool playerIsIn = false;
    PlayerController holder;

    string lastState;

    Rigidbody2D rb;
    #endregion

    private void Start()
    {
        holder = FindObjectOfType<PlayerController>();

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 direction = -(holder.GetComponent<Rigidbody2D>().position - rb.position);
        direction.x = Mathf.Round(direction.x);
        direction.y = Mathf.Round(direction.y);
        if (playerIsIn)
        {
            if (Input.GetKeyDown(holder.interactKey))
            {
<<<<<<< HEAD
                isHeld = true;
                //FindObjectOfType<AudioManager>().Play("Box_Pickup");
                transform.parent = holder.transform;
            }
            if (Input.GetKey(holder.interactKey))
            {
                if (holder.lookDirection == direction)
                {
                    if (direction.x > 0)
                    {
                        direction.Set(0.01f, 0);
                    }
                    if (direction.x < 0)
                    {
                        direction.Set(-0.01f, 0);
                    }
                    if (direction.y > 0)
                    {
                        direction.Set(0, 0.01f);
                    }
                    if (direction.y < 0)
                    {
                        direction.Set(0, -0.01f);
                    }
                    rb.position += direction;
                }
            }
            if (Input.GetKeyUp(holder.interactKey))
            {
                isHeld = false;
                transform.parent = null;
            }
        }

        if (direction.magnitude > 1.2)
        {
            transform.parent = null;
=======
                isHeld = !isHeld;
            }
        }
        if (!isHeld)
        {
            rb.isKinematic = true;
            GetComponent<PointEffector2D>().enabled = false;
        }
        else
        {
            rb.isKinematic = false;
            GetComponent<PointEffector2D>().enabled = true;
        }
    }

    private void LateUpdate()
    {
        if (isHeld)
        {
            float offset = 1.5f;

            string state = CheckDirection(holder.lookDirection);
            lastState = state == "" ? lastState : state;
            if (lastState == "LEFT")
                rb.MovePosition(new Vector2(holder.transform.position.x + offset, holder.transform.position.y));
            else if (lastState == "RIGHT")
                rb.MovePosition(new Vector2(holder.transform.position.x - offset, holder.transform.position.y));
            else if (lastState == "UP")
                rb.MovePosition(new Vector2(holder.transform.position.x, holder.transform.position.y + offset));
            else if (lastState == "DOWN")
                rb.MovePosition(new Vector2(holder.transform.position.x, holder.transform.position.y - offset));
>>>>>>> parent of 6e3f8ea... Add push / pull
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            playerIsIn = true;
        }
        else if (!collision.isTrigger)
        {
            rb.isKinematic = false;
            rb.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isHeld)
        {
            playerIsIn = false;
        }
<<<<<<< HEAD
        rb.isKinematic = true;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
=======
    }

    private string CheckDirection(Vector2 dir)
    {
        if (dir == new Vector2(1, 0))
            return "LEFT";
        if (dir == new Vector2(-1, 0))
            return "RIGHT";
        if (dir == new Vector2(0, 1))
            return "UP";
        if (dir == new Vector2(0, -1))
            return "DOWN";

        else return "";
>>>>>>> parent of 6e3f8ea... Add push / pull
    }
}
