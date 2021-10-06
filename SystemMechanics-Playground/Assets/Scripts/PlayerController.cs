using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    CharacterController charCntrl;
    [SerializeField] Vector3 currentMovement;

    float velocity;
    float vertical;
    float horizontal;

    Vector3 playerInput;

    bool charIsGrounded;
    float jumpVelocity;


    // Start is called before the first frame update
    void Start()
    {
        charCntrl = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(charCntrl)
        {
            handlePlayerMovement();
            charIsGrounded = charCntrl.isGrounded;
        }
    }


    void handlePlayerMovement()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        playerInput = new Vector3(vertical, 0f, horizontal);

        //instantiate currentMove and pass to charCntrl to move player
        currentMovement = new Vector3(playerInput.x, charIsGrounded ? 0.0f : -1.0f, -playerInput.z) * Time.deltaTime;

        if (charIsGrounded)
        {
            currentMovement.y = jumpVelocity;
        }
        charCntrl.Move(currentMovement);
    }


}
