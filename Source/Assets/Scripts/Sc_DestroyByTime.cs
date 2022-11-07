using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_DestroyByTime : MonoBehaviour
{
    public float time;
    void Start()
    {
        Destroy(this.gameObject, time);
    }

}
