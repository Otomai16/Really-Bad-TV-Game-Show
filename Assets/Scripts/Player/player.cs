using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");        
    }

    void FixedUpdate()
    {
        //Déplacement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if(movement != Vector2.zero){
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            rb.rotation = angle - 90f;
        }
    }
}
