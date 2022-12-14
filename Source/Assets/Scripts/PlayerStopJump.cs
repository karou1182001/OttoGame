using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStopJump : MonoBehaviour
{
    public float fallMultiplier = 2.5f;
    public float lowJumMultiplier = 2.0f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

    }
}
