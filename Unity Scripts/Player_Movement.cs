using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    //Variables
    [SerializeField] private InputActionReference movement;
    Rigidbody2D rb;
    private Vector2 movementInput;
    private Vector2 savedMoveInput;
    [SerializeField] private float currentSpeed = 0.1f;
    [SerializeField] private float maxSpeed = 15f;
    [SerializeField] private float acceleration = 1f;
    [SerializeField] private float deceleration = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Checks the movement input each frame
        if (movement != null)
        {
            movementInput = movement.action.ReadValue<Vector2>();
        }
    }

    void FixedUpdate()
    {
        //checks if movement button has been pressed
        if (movementInput.magnitude > 0)
        {
            savedMoveInput = movementInput;
            //sets the speed of the player character
            currentSpeed += acceleration * maxSpeed;
        }
        else
        {
            //if no movement input is being made, decelerate the player
            currentSpeed -= deceleration * maxSpeed * Time.deltaTime;
        }
        //Sets the player speed
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        //Moves the player based off movement input and speed
        rb.velocity = savedMoveInput * currentSpeed;
    }
    //Sends the player to the game over scene when they collide with a Pillar
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.name == "Pillar(Clone)"){
           SceneManager.LoadScene("Game Over");
        }
        
    } 

}
