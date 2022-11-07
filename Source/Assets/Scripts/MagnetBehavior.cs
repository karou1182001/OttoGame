using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetBehavior : MonoBehaviour
{
    public Transform player;
    private List<GameObject> partsAround;
    void Start()
    {
        partsAround = new List<GameObject>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PARTS") {
            partsAround.Add(col.gameObject);
            MagnetAttraction myMagnetBehavior = col.gameObject.GetComponent<MagnetAttraction>();
            myMagnetBehavior.target = player;
        }
    }

    void OnDisable()
    {
        if (partsAround != null)
        {
            partsAround.ForEach((item) =>
            {
                if (item != null)
                {
                    MagnetAttraction myMagnetBehavior = item.GetComponent<MagnetAttraction>();
                    if (myMagnetBehavior != null)
                    {
                        myMagnetBehavior.target = null;
                    }
                }
            });
            partsAround = new List<GameObject>();
        }
    }

}
