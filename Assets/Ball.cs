using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public enum MoveDirection
    {
        Left,
        Right,
    }
    MoveDirection moveDirection = MoveDirection.Right;

    Rigidbody rigid;
    Quaternion originRotate;
    private void Start()
    {
        originRotate = transform.rotation;
        rigid = GetComponent<Rigidbody>();
    }
    void Update()
    {
        IsGameOver();
        Compenstaion();
        ChangeMoveDirection();
        Move();
    }

    private void IsGameOver()
    {
        if (transform.position.y > 1)
            return;
        if (rigid.velocity.sqrMagnitude < 0.1f)
            return;

        print("게임 오바");
        Debug.Break();
    }

    private void Compenstaion()
    {
        transform.rotation = originRotate;
        var velocity = rigid.velocity;
        velocity.x = 0;
        velocity.z = 0;
        rigid.velocity = velocity;
    }

    private void ChangeMoveDirection()
    {
        if (Input.anyKeyDown)
        {
            moveDirection = moveDirection == MoveDirection.Left ? MoveDirection.Right : MoveDirection.Left;
            ScoreUI.instance.AddScore(1);
        }
    }

    Vector3 move = Vector3.zero;
    [SerializeField] float speed = 3;
    private void Move()
    {
        switch (moveDirection)
        {
            case MoveDirection.Left:
                move = Vector3.forward;
                break;
            case MoveDirection.Right:
                move = Vector3.right;
                break;
        }
        transform.Translate(speed * Time.deltaTime * move, Space.Self);
    }
}
