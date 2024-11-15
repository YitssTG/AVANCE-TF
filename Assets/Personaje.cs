using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    private Rigidbody2D _componentRigiboby2D;
    public float speedx;
    public float horizontal;
    public bool canJump;
    public bool isJumping;
    public float jumpForce;
    private void Awake()
    {
        _componentRigiboby2D = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") == true && canJump == true)
        {
            isJumping = true;
        }
    }
    void FixedUpdate()
    {
        _componentRigiboby2D.velocity = new Vector2(horizontal * speedx, _componentRigiboby2D.velocity.y);

        if (isJumping == true)
        {
            _componentRigiboby2D.AddForce(new Vector2(0, jumpForce),ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.gameObject.tag == "Ground")
        {
            canJump = false;
            isJumping = false;
        }
    }
}
