using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetStops : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Reset());
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
