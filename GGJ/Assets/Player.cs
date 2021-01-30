using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    Vector3 velocity = Vector3.zero;
    float verticalSpeed = 0f;

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
}
