using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{

    private GameController gameController;
    private Rigidbody2D rigidBody;
    void Start()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = new Vector2(gameController.objectSpeed, 0);
        DestroyObject();
    }

    private void DestroyObject()
    {
        if (transform.position.x < -10)
        {
            Destroy(this.gameObject);
        }
    }
}
