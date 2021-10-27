using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{

    Animator animator;
    int isWalkingHash;
    int isRunningHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //sets isWalking from string to int
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        //passes the isWalking from animator
        //bool isWalking = animator.GetBool("isWalking");
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool moveForward = Input.GetKey("q");
        bool runActive = Input.GetKey("left shift");

        //set the bool for isWalking to true when key is pressed and the player is not walking
        if (moveForward && !isWalking)
            animator.SetBool(isWalkingHash, true);
        
        //set isWalking to false if key is not pressed and isWalking is true
        if (isWalking && !moveForward)
            animator.SetBool(isWalkingHash, false);

        //checks if player is moving forward and pressing run
        if (!isRunning && moveForward && runActive)
            animator.SetBool("isRunning", true);

        //stops running if moveForward is not pressed or if not runActive
        if(isRunning && !moveForward || !runActive)
            animator.SetBool("isRunning", false);
    }
}
