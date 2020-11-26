using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Entity : MonoBehaviour, IEntity
{
    private CharacterController _characterController;
    public int health { get; set; }
    public EntityType entityType { get; }

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        _characterController.Move(new Vector3(horiz, 0, vert));
    }
}
