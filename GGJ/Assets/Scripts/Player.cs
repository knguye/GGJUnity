using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed  = 5f;
    public float jumpSpeed      = 3f;
    bool mIsGrounded;

    [Header("Components")]
    public Rigidbody2D rb;
    public InputManager input;

    void Update()
    {
        // Check grounded
        Vector2 crrtVelocity = rb.velocity;
        mIsGrounded = crrtVelocity.y == 0;

        // Kinematics
        // Horizontal
        Vector2 newVelocity = crrtVelocity;
        newVelocity.x = input.horizontal * movementSpeed;
        // Vertical
        if (mIsGrounded && input.jump)
        {
            newVelocity += Vector2.up * jumpSpeed;
        }
        rb.velocity = newVelocity;
    }

    public Ability SwapAbility(Ability ability)
    {
        input.EnableAbility(ability);
        return input.ConsumeLastAbility();
    }
}
