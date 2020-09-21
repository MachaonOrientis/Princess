﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
private float _speed = 3;
 
    private Vector3 moveDirection = Vector3.zero;
    public GameObject player;
    public float turnSpeed = 180f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Animator _anim;
    private CharacterController _controller;
 
 
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _controller = GetComponent<CharacterController>();
 
    }
    // Update is called once per frame
    void Update()
    {
   
          float input_x = Input.GetAxisRaw("Horizontal");
          float input_y = Input.GetAxisRaw("Vertical");
 
        if (_controller.isGrounded)
        {
 
           bool isRunning = (Mathf.Abs(input_x) + Mathf.Abs(input_y)) > 0;
 
           _anim.SetBool("Run", isRunning);
     
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            
			if (Input.anyKey)
			{
				player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, Quaternion.LookRotation(moveDirection), turnSpeed * Time.deltaTime);        

			}
            moveDirection *= _speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        _controller.Move(moveDirection * Time.deltaTime);
 
    }
 
}