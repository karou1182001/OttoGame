using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject fadeOut;
    public string name;
    public bool change;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player")) {
           // SceneManager.LoadScene(name);
            StartCoroutine(End());
        }
    }

    IEnumerator End()
    {
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1f);
        change = true;
    }
    private void Update()
    {
        if (change)
        {

            SceneManager.LoadScene(name);
        }
    }
}
