using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class TPS_Controller : MonoBehaviour
{
    public CharacterController  controller;
    public Transform cam;

    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity; 
    bool isGrounded;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;



    // Update is called once per frame
    void Update(){
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0 ){

            velocity.y = -2f;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(x, 0f, z).normalized;

        if(Input.GetButtonDown("Jump") && isGrounded){
                
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        if (direction.magnitude >= 0.1f) {


        	float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        	float angle = Mathf. SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        	transform.rotation = Quaternion.Euler (0f, angle, 0f);

        	Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            
        	
        	controller.Move(moveDir.normalized * speed * Time.deltaTime);
            


   
         }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}
