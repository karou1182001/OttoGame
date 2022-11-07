using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePrensa : MonoBehaviour
{
    public Press myPress;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player") && !myPress.disable)
        {
            myPress.StartSmash();
        }

    }
}
