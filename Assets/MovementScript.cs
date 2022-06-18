﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


[RequireComponent(typeof(Rigidbody2D))]

//The movement of the Player that also determine 
public class MovementScript : MonoBehaviour
{
    Rigidbody2D RBody2D;
    [SerializeField] float speed = 2f;
    [SerializeField] MarkerManger markerManger;
    [SerializeField] TileReaderController tileReaderController;
    Vector2 motionVector;
    public Vector2 lastMotionVector;
    public Animator animator;
    public bool moving;
    /*
    const string PLAYER_UP = "Player_Walk_Up";
    const string PLAYER_DOWN = "Player_Walk_Down";
    const string PLAYER_LEFT = "Player_Walk_Left";
    const string PLAYER_RIGHT = "Player_Walk_Right";
    */



    void Awake()
    {
        RBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        motionVector = new Vector2(horizontal, vertical);

        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);

        moving = horizontal != 0 || vertical != 0;
        animator.SetBool("moving", moving);

        if (horizontal != 0 || vertical != 0)
        {
            lastMotionVector = new Vector2(horizontal, vertical).normalized;
            animator.SetFloat("lasthorizontal", horizontal);
            animator.SetFloat("lastvertical", vertical);
        }

        
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        RBody2D.velocity = motionVector * speed;
    }


/*
    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }
*/
}
