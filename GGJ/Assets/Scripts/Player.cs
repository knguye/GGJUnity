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

    // Ability/Orb related

    public bool[] activeAbilities; // An array of 3 booleans
    /*
        True if enabled
        0 - Left
        1 - Right
        2 - Up
    */

    public int lastAbilityHeld;

    public GameObject orb; // to instantiate


    void Start()
    {

    }


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

    public Ability SwapAbility(int ability) 
    {
        Ability swapedAbility = input.ConsumeLastAbility();
        if (ability != -1)
        {
            input.EnableAbility((Ability) ability);
        }
        return swapedAbility;
    }
}
