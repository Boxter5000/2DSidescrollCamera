using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject FloorDistance;
    [SerializeField] private float camerDistance;
    [SerializeField] private float Speed;
    [SerializeField]private float idleOffset = 1f;
    [SerializeField] private float maxFloorDistance;
    [SerializeField] private LayerMask RayMask;
    [SerializeField] private float FloormoveSpeed;

    private float facing;
    private CharacterControllet _characterController;
    
    private void Awake()
    {
        _characterController = player.GetComponent<CharacterControllet>();
    }
    
    public void FixedUpdate()
    {
        Vector2 FloorDistancePos = new Vector2(FloorDistance.transform.position.x, FloorDistance.transform.position.y);
        
        RaycastHit2D hitDistanceDown = Physics2D.Raycast(FloorDistancePos, Vector2.down, maxFloorDistance, RayMask);
        RaycastHit2D hitDistanceUp = Physics2D.Raycast(FloorDistancePos, Vector2.up, maxFloorDistance, RayMask);

        float hitLenghtDown = hitDistanceDown.distance;
        float hitLenghtUp = hitDistanceUp.distance;

        Vector2 cameraMovePos =
            new Vector2(player.transform.position.x + facing, player.transform.position.y + hitLenghtDown);

        Vector2 pos = Vector2.Lerp(
            (Vector2)transform.position,
            (Vector2)player.transform.position,
            Speed * Time.fixedDeltaTime);
        
        if (_characterController.facingRight)
        {
            pos.x += idleOffset;
        }
        else if (!_characterController.facingRight)
        {
            pos.x += -idleOffset;
        }

        if (hitDistanceDown)
        {
            pos.y += FloormoveSpeed;
        }
        if (hitDistanceUp)
        {
            pos.y -= FloormoveSpeed / 2;
        }
        
        transform.position = new Vector3(pos.x, pos.y, camerDistance);
    }
}
