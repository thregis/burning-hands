using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private GameController gameController;
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;

    [SerializeField] private float jumpForce = 100f;
    public LayerMask groundMask; 

    void Start()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = transform.GetComponent<BoxCollider2D>();
    }

    
    void Update()
    {
        Movement();
        ControlPosition();
        Jump();
    }
    
    private void Movement()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float speed = gameController.characterSpeed;
        transform.position = transform.position + new Vector3(horizontalMovement * speed * Time.deltaTime, rigidBody.velocity.y * Time.deltaTime, 0);
        //rigidBody.velocity += new Vector2(horizontalMovement * speed, rigidBody.velocity.y);
    }

    private void Jump()
    {
        if(IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.velocity = Vector2.up * jumpForce;
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, groundMask);
        return raycastHit.collider!= null;
    }
    
    private void ControlPosition()
    {
        if (transform.position.y > gameController.yMax)
        {
            transform.position = new Vector3(transform.position.x, gameController.yMax, 0);
        }

        if (transform.position.x > gameController.xMax)
        {
            transform.position = new Vector3(gameController.xMax, transform.position.y, 0);
        }
        else if (transform.position.x < gameController.xMin)
        {
            transform.position = new Vector3(gameController.xMin, transform.position.y, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.GameOver();
    }

}
