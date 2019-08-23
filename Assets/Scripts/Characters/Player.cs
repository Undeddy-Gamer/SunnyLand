using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController2D))]
public class Player : MonoBehaviour
{

    public float jumpHeight = 5f;  // How hight the Charater Jumps (in units)
    public float climbSpeed = 10f; //How fast the Character Climbs
    public float moveSpeed = 10f;  // How fast the Character Moves

    private CharacterController2D controller;

    // Start is called before the first frame update
    void Start()
    {
        // Gather components at the start of the game to save processing (Cache-ing)
        controller = GetComponent < CharacterController2D>();

    }

    // Update is called once per frame
    void Update()
    {

        /*
         * --- Unity Tip ---
         * 
         * Input.GetAxis - Fake analog
         * Input.GetAxisRaw - instant on/off
         * 
         */

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool isJumping = Input.GetButtonDown("Jump");


        if (isJumping)
        {
            controller.Jump(jumpHeight);
        }

        controller.Climb(vertical * climbSpeed);


        controller.Move(horizontal * moveSpeed);


        //print("Horizontal: " + horizontal);
        //print("Vertical: " + vertical);
    }
}
