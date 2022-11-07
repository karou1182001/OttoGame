using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    private int maxNumberOfDash = 4;
    private int numberDash;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    private void Update()
    {
        if (numberDash <= maxNumberOfDash) {
            if (direction == 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                {
                    numberDash++;
                    direction = 1;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                {
                    numberDash++;
                    direction = 2;
                }
            }
            else {
                if (dashTime <= 0)
                {
                    direction = 0;
                    dashTime = startDashTime;
                    rb.velocity = Vector2.zero;
                }
                else {
                    dashTime -= Time.deltaTime;
                    if (direction == 1)
                    {
                        rb.velocity = Vector2.left * dashSpeed + Vector2.up * dashSpeed / 4;
                        
                    }
                    else if (direction == 2)
                    {
                        rb.velocity = Vector2.right * dashSpeed + Vector2.up * dashSpeed / 2;
                    }
                    else if (direction == 4)
                    {
                        rb.velocity = Vector2.up * dashSpeed + Vector2.up * dashSpeed / 2;
                    }
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FLOOR")
        {
            numberDash = 2;
        }
    }


}
