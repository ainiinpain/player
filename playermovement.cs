using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;

    public float jumpHeight = 3f ;

    Vector3 velocity;
    bool isGrounded;
    
    public float gravity = -19.81f;

    public Transform checkground;
    public float groundDistance =0.4f;
    public LayerMask groundMask;



    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(checkground.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            Debug.Log("is grounded");
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float a = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * a;

        controller.Move (move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("jump");
            velocity.y = Mathf.Sqrt(jumpHeight *-2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        
        controller.Move(velocity * Time.deltaTime);


    }
}
