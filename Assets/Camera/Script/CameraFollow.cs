using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float camerDistance;
    [SerializeField] private float Speed;
    [SerializeField]private float idleOffset = 1f;
    
    private CharacterControllet _characterController;
    
    private void Awake()
    {
        _characterController = player.GetComponent<CharacterControllet>();
    }

    public void FixedUpdate()
    {
        Vector2 pos = Vector2.Lerp ((Vector2)transform.position, (Vector2)player.transform.position, Speed * Time.fixedDeltaTime);
        if (_characterController.facingRight)
        {
            pos.x += idleOffset;
        }
        else if (!_characterController.facingRight)
        {
            pos.x += -idleOffset;
        }

        
        transform.position = new Vector3(pos.x, pos.y, camerDistance);
    }
}
