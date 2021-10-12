using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    CharacterController charCntrl;
    [SerializeField] Vector3 currentMovement;

    //[SerializeField] float charVelocity;
    float moveZ;
    float moveX;

    Vector3 playerMovement;

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
            handlePlayerRotation();
            charIsGrounded = charCntrl.isGrounded;
        }
    }


    void handlePlayerMovement()
    {
        moveZ = Input.GetAxis("Vertical");
        moveX = Input.GetAxis("Horizontal");

        playerMovement = new Vector3(moveX, 0f, moveZ);

        //instantiate currentMove and pass to charCntrl to move player
        currentMovement = new Vector3(playerMovement.x, charIsGrounded ? 0.0f : -1.0f, playerMovement.z) * Time.deltaTime;

        if (charIsGrounded)
        {
            currentMovement.y = jumpVelocity;
        }
        charCntrl.Move(((currentMovement) /**charVelocity* Time.deltaTime*/));
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
