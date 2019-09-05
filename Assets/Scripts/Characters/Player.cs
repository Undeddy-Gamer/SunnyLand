using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController2D))]
public class Player : MonoBehaviour
{

    public float jumpHeight = 5f;  // How hight the Charater Jumps (in units)
    public float climbSpeed = 10f; //How fast the Character Climbs
    public float moveSpeed = 10f;  // How fast the Character Moves
    public float portalDistance = 1f;  // How far from the portal for the player to interact


    private CharacterController2D controller;

    private Transform currentPortal; // Reference to Current Portal

    // Start is called before the first frame update
    void Start()
    {
        // Gather components at the start of the game to save processing (Cache-ing)
        controller = GetComponent < CharacterController2D>();

    }

    void OnDrawGizmos()
    {
        if(currentPortal != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(currentPortal.position, portalDistance);
        }
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

        //If over a portal
        if(currentPortal != null)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                // Get distance between player and portal
                float distance = Vector2.Distance(transform.position, currentPortal.position);
                // if the didstance is less than the portal distance
                if (distance < portalDistance)
                {
                    print("Player is in Interactable Distance");
                    // Invoke Action Event on the Portal using 'SendMessage'
                    currentPortal.SendMessage("Interact");
                }

                
            }
        }

        //print("Horizontal: " + horizontal);
        //print("Vertical: " + vertical);
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        // Detect hitting item
        if (col.gameObject.tag == "Item")
        {
            // apply 1 to score
            GameManager.Instance.AddScore(1);
            // -- Play chime sound
            // destroy item
            Destroy(col.gameObject);
        }

        //Detect hitting portal        
        if (col.CompareTag("Portal"))
        {
            currentPortal = col.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        // Detect hitting Portal
        if (col.CompareTag("Portal"))
        {
            currentPortal = null;
        }
    }

    /*
    private void OnTriggerStay2D(Collider2D col)
    {
        //Detect hitting portal
        if (col.CompareTag("Portal"))
        {
            // Check if Up is pressed
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                // Invoke Action Event on the Portal using 'SendMessage'
                col.SendMessage("Interact");
            }

        }
    }
    */
}
