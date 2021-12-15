using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    private GameController gameController;
    private Rigidbody2D rigidbody;
    private bool isInstantiated;
    void Start()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector2(gameController.objectSpeed, 0);

        InstantiateGround();
        DestroyGround();

    }

    private void DestroyGround()
    {
        if(transform.position.x < -20)
        {
            Destroy(this.gameObject);
        }
    }

    private void InstantiateGround()
    {
        if(transform.position.x <= -0.0917 && isInstantiated == false)
        {
            isInstantiated = true;
            gameController.InstantiateGround(transform.position.x);
        }
    }
}
