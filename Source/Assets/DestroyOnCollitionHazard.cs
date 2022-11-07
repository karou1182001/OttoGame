using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollitionHazard : MonoBehaviour
{
    public GameObject TrashExplotion;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HAZARD") {
            Instantiate(TrashExplotion, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
