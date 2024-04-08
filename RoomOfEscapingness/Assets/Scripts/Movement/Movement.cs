using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float speed =7f;
    float startSpeed;
    [SerializeField] float runningMulti=1.5f;
    [SerializeField] float jumpHeight;


    [SerializeField] float gravity =-9.82f;
    [SerializeField] CharacterController controller;


    [SerializeField] Transform groundChecker;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;
    bool isGround;
    Vector3 velocity;

    public AudioSource Walkingsound;
    bool moving;

    void Start()
    {
        startSpeed = speed;
        Cursor.visible = false;
    }


    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        isGround = Physics.CheckSphere(groundChecker.position, groundDistance, groundMask);
       
        if (isGround&& velocity.y<0)
        {
            velocity.y = -2f;
        }

            moving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S);

        if (moving && Walkingsound.isPlaying ==false)
        {
            Walkingsound.Play();
            Debug.Log("playing sound");
        }
        else if(moving ==false)
        {
            Debug.Log("not playing sound");
            Walkingsound.Pause();
        }


        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = startSpeed * runningMulti;
            Walkingsound.pitch = 1.5f;
        }
        else
        {
            speed = startSpeed;
            Walkingsound.pitch = 1;
        }





        Vector3 move = transform.right*x + transform.forward*z;

       controller.Move(move * speed * Time.deltaTime);

      
        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity*Time.deltaTime);
    }
}
