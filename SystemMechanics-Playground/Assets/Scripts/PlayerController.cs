﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    CharacterController charCntrl;
    Animator animator;

    [SerializeField] Vector3 currentMovement;

    //[SerializeField] float charVelocity;
    float moveZ;
    float moveX;
    float speed = 3.0f;
    float rotateSpeed = 3.0f;
    //values for animation
    //float anim_VelocityX = 0.0f;
    //float anim_VelocityZ = 0.0f;

    Vector3 playerMovement;

    bool charIsGrounded;
    float jumpVelocity;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        charCntrl = this.GetComponent<CharacterController>();
        //transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(charCntrl)
        {
            handlePlayerMovement();
            //handlePlayerRotation();
            //charIsGrounded = charCntrl.isGrounded;
        }
    }


    void handlePlayerMovement()
    {
        /*moveZ = Input.GetAxis("Vertical");
        moveX = Input.GetAxis("Horizontal");

        playerMovement = new Vector3(moveX, 0f, moveZ);

        //instantiate currentMove and pass to charCntrl to move player
        currentMovement = new Vector3(playerMovement.x, *//*charIsGrounded ? 0.0f : 0.0f*//*-10f, playerMovement.z) * Time.deltaTime;

        if (charIsGrounded)
        {
            //currentMovement.y = 
            //temp fix for setting the player on the ground
            charCntrl.center = new Vector3(0, 1, 0);
        }
        charCntrl.Move(((currentMovement)));
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down), Color.red);*/
        characterSimpleMove();
    }

    //moves withe characterController SimpleMove
    void characterSimpleMove()
    {
        transform.Rotate(0.0f, Input.GetAxis("Horizontal") * rotateSpeed, 0.0f);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float currentSpeed = speed * Input.GetAxis("Vertical");
        charCntrl.SimpleMove(forward * currentSpeed);
    }

    void characterMove()
    {

    }

    void handlePlayerRotation()
    {
        if (moveX > 0)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 2f * Time.deltaTime);
        else if (moveX < 0)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 2f * Time.deltaTime);
        if (moveZ > 0)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 2f * Time.deltaTime);
        else if (moveX < 0)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 2f * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 2.0f);
    }
}
