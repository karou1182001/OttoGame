using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetAttraction : MonoBehaviour
{
    public float force;
    public Transform target;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (target != null && rb != null) {
            Vector3 direction = target.transform.position - transform.position;
            direction = direction.normalized;
            rb.AddForce(direction * force);
        }
    }
}
