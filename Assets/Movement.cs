using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {
    //The multiplier for the movement, amount in frames
    public float speed = 10.0f;
    //the vertical multiplyier, frames
    public float jumpSpeed = 8.0f;
    //The pull of gravity
    public float gravity = 20.0f;
    public float turnspeed = 10.0f;
    public Scrollbar Scrollbar_MouseSpeed;
    //set a variable to save the location
    private Vector3 moveDirection = Vector3.zero;
    //the variable to let us get the character controller input
    private CharacterController controller;

    void Start()
    {
        //the setting of our variable to a dynamic variable
        controller = GetComponent<CharacterController>();

        // spawn location
        gameObject.transform.position = new Vector3(0, 2, 0);
    }
    //frame by frame updater
    void Update()
    {

        //test to see if object is colliding underneath
        if (controller.isGrounded)
        {
            //use the character control in move direction
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity by removing the force of gravity times time.
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
        //mouselook
        float mouse_x = Input.GetAxis("Mouse X");
        //mybad
        //float mouse_y = Input.GetAxis("Mouse Y"); i need to put this on the camera or something...idk.
        Vector3 lookhere = new Vector3(0, mouse_x*turnspeed*Scrollbar_MouseSpeed.value, 0);
        transform.Rotate(lookhere);


    }
}