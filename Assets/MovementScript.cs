using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

//The movement of the Player that also determine 
public class MovementScript : MonoBehaviour
{
    Rigidbody2D RBody2D;
    [SerializeField] float speed = 2f;
    Vector2 motionVector;
    public Animator animator;
    public int facing;

    void Awake()
    {
        //
        RBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        motionVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        animator.SetFloat("horizontal", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("vertical", Input.GetAxisRaw("Vertical"));
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        RBody2D.velocity = motionVector * speed;
    }
}
