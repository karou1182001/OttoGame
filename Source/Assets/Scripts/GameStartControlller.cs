using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameStartControlller : MonoBehaviour
{
    public AudioSource fuente;
    public AudioClip clip;
    //Escribir: Debug.Log("");
    // Start is called before the first frame update
    void Start()
    {
        fuente.clip = clip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    //Función para cerrar juego
    public void closeGame()
    { 
        Application.Quit();
    }

    public void llamarIE(string name)
    {
        StartCoroutine(reproduciraAudioOtto(name));
    }
    //Función para reproducir un sonido
    IEnumerator reproduciraAudioOtto(string name)
    {
        fuente.Play();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(name);

    }
    public void volverInicio(string name)
    {
        SceneManager.LoadScene(name);
    }

   
}




















