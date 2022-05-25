using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementScript : MonoBehaviour
{
    Rigidbody2D RBody2D;
    [SerializeField] float speed = 2f;
    Vector2 motionVector;
    Animator animator;
    string currentState;
    const string PLAYER_IDLE = "Player_Idle";

    const string PLAYER_UP = "Player_Walk_Up";
    const string PLAYER_DOWN = "Player_Walk_Down";
    const string PLAYER_LEFT = "Player_Walk_Left";
    const string PLAYER_RIGHT = "Player_Walk_Right";




    void Awake()
    {
        RBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        motionVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        RBody2D.velocity = motionVector * speed;
    }



    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }
}
