using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FlipDirection { UP, DOWN, LEFT, RIGHT };
public class PlayerMovement : MonoBehaviour
{
    public float torque = 10.0f;
    public float timeToAddForce;
    private Rigidbody2D rb;
    public FlipDirection directionMovement;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            directionMovement = FlipDirection.RIGHT;
            StartCoroutine(AddForceToRotote(-1));
        }
        if (Input.GetKey(KeyCode.A))
        {
            directionMovement = FlipDirection.LEFT;
            StartCoroutine(AddForceToRotote(1));
        }
    }

    IEnumerator AddForceToRotote(int sing)
    {
        for (var i = 0; i < timeToAddForce; i++)
        {
           // rb.AddForce(transform.up * torque);
            rb.AddTorque(torque * sing, ForceMode2D.Force);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.1f);
        //rb.angularVelocity = 0;
    }
}
