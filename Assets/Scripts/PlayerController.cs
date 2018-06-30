using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float Speed;
    public float MaximumVelocity;

    private Rigidbody2D _body;

    public GameObject Player
    {
        get { return gameObject; }
    }

    // Use this for initialization
    void Start ()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var movement = GetMovement();

        if(movement == Vector2.zero)
            RemoveForce(_body);
        else
            AddMovementToForce(movement, _body);
        
    }

    static void RemoveForce(Rigidbody2D body)
    {
        body.velocity = Vector2.zero;
    }

    private void AddMovementToForce(Vector2 movement, Rigidbody2D body)
    {
        ClampMaximumSpeed(body);
        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        body.AddForce(movement * Speed);
    }

    private static Vector2 GetMovement()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        return movement;
    }

    private void ClampMaximumSpeed(Rigidbody2D body)
    {
        var velocityMagnitude = body.velocity;
        body.velocity = Vector2.ClampMagnitude(velocityMagnitude, MaximumVelocity);
    }

    // Update is called once per frame
    void Update () {

	}
}
