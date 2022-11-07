using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeForCredits : MonoBehaviour
{
    bool change;
    public GameObject fadeOut;
    void Start()
    {
        StartCoroutine(End());
    }

    IEnumerator End()
    {        
        yield return new WaitForSeconds(5f);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1f);
        change = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (change) {
            SceneManager.LoadScene("Creditos");
        }
    }
}
