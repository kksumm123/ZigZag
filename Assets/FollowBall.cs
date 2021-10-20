using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    public Transform ball;
    float offsetZ;
    void Start()
    {
        offsetZ = ball.transform.position.z - transform.position.z;
    }

    float distanceZ;
    void Update()
    {
        distanceZ = ball.transform.position.z - transform.position.z;
        transform.Translate(new Vector3(0, 0, distanceZ - offsetZ) * Time.deltaTime, Space.World);
    }
}
