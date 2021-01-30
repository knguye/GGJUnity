using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    Vector3 velocity = Vector3.zero;
    float verticalSpeed = 0f;

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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        velocity = Vector3.right * Input.GetAxis("Horizontal");
        if (Input.GetKeyDown("w"))
        {
            verticalSpeed = speed;
        }
        verticalSpeed = Mathf.Max(verticalSpeed - 9.8f * Time.deltaTime, 0f);
        velocity += Vector3.up * verticalSpeed;
    }

    private void FixedUpdate()
    {
        transform.position += velocity * Time.fixedDeltaTime * speed;
    }

    public void changeAbilities(int ability) {
        // Enable the ability picked up, 
        activeAbilities[ability] = true;

        // .. and set the last obtained ability to false
        activeAbilities[lastAbilityHeld] = false;

        // Instantiate an orb @ the player's position with the ability last held
        GameObject orbDropped = Instantiate(orb, transform.position, transform.rotation);
        orbDropped.GetComponent<Orb>().powerUpEffect = lastAbilityHeld;
    }
}
