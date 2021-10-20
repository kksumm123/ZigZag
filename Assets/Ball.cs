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

    void Update()
    {
        ChangeMoveDirection();
        Move();
    }

    private void ChangeMoveDirection()
    {
        if (Input.anyKeyDown)
            moveDirection = moveDirection == MoveDirection.Left ? MoveDirection.Right : MoveDirection.Left;
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
