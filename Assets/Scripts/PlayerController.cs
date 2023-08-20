using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float thrust = 10.0f;
    public LayerMask groundLayerMask;
    public float bunnyFloorDistance = 1.0f;
    public Animator animator;
    public float runSpeed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        //We are getting the Rigid Body 2D from our bunny
        rigidBody = GetComponent<Rigidbody2D>();

        //We are setting to 1 the bool variable from the animator that the sprite has.
        animator.SetBool("isAlive", true);
    }

    //Fixed Update is a method that updates the game when it's needed.
    private void FixedUpdate()
    {
        //Here we are updating the Vector2 rigid body x parameter. What velocity defines is the distance moved in each second. 
        if (rigidBody.velocity.x < runSpeed)
        {
            //We instantate the new velocity vector, to allways have the 1.5 x velocity.
            rigidBody.velocity = new Vector2(runSpeed, rigidBody.velocity.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool isOntheGround = IsOnTheGround();
        animator.SetBool("isGrounded", isOntheGround);
        if((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && isOntheGround)
        {
            Jump();
        }
    }

    void Jump()
    {
        rigidBody.AddForce(Vector2.up * thrust, ForceMode2D.Impulse);
    }

    //Raycast is literraly a Ray that is checking the distance between our prefab and other gameobject. In this between the bunny and the ground.
    //We have created a Layer in unity called "ground". And we named our floor prefab the "ground" layer. 
    //So we need to input to the Raycast, the initial position (with transform.position), the direction of the vector (in this case down), the distance between bunny and the floor and finally the int value of the layer mask (in this case ground).
    bool IsOnTheGround()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, bunnyFloorDistance, groundLayerMask.value);
    }
}
