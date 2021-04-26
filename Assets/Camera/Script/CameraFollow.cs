using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float camerDistance;
    [SerializeField] private float Speed;


    private void FixedUpdate()
    {
        Vector2 pos = Vector2.Lerp ((Vector2)transform.position, (Vector2)player.transform.position, Speed * Time.fixedDeltaTime);
        transform.position = new Vector3(pos.x, pos.y, camerDistance);
    }
}
