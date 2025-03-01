/*****************
BraedenKurfman
Capstone Computing Project
Capy Quest
10/22/24
******************/
using UnityEngine;


public class CapyMove : MonoBehaviour
{
    // Player Speed
    public float moveSpeed = 5f;

    // Gets the RigidBody2d component
    private Rigidbody2D rb;
    // Gets the sprite renderer component
    private SpriteRenderer spriteRenderer;
    // Stores movement input
    private Vector2 movement;
    // Stores the nns for the player in Unity
    private Animator animator;
    // holds the value for if the player is touching the water tilemap since capys can swim.
    private bool isSwimming = false;


    private void Start()
    {
        // starts the animations for idle and walking. Also initializes basic hitboxes and gravity.
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        //prevent the capy from being destroyed.
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        // Capture WASD input (no jumping :) )
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Normalize diagonal movement speed, this is done to prevent an issue with movement where if moving diagonally, 
        // the speed value is taken from moving both horizontally and vertically, 
        // making you move 1.5x faster than normal.
        // This is a cool speedrunning tool, but not good for game design since it can cause glitches
        if (movement.magnitude > 1)
            movement.Normalize();

        // Flip the sprite based on movement direction horizontally (capybara was moving backwards)
        if (movement.x != 0)
        {
            spriteRenderer.flipX = movement.x > 0;
        }

        // When moving, start the Walking animation
        animator.SetBool("isMoving", movement.magnitude > 0);
        // When in water, Swimming animation (animation is just the Capybara but cut in half for now)
        animator.SetBool("isSwimming", isSwimming);
    }

    private void FixedUpdate()
    {
        // Moves the player over time to allow for smoother movement.
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
        // Checks for water tiles
        private void OnTriggerEnter2D(Collider2D other)
        {
        if (other.CompareTag("WaterTile")){
            isSwimming = true; // switch to swimming animation
         }
        }

         private void OnTriggerExit2D(Collider2D other)
        {
        if (other.CompareTag("WaterTile")){
            isSwimming = false; // when on tilemap 1, switch to walking/ idle animations
         }
        }
}