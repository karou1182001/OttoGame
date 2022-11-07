using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnetBehavior : MonoBehaviour
{
    public GameObject myMagnet;
    public GameObject particlesAttractEffect;
    public GameObject particlesRejectEffect;

    void Start()
    {
        myMagnet.SetActive(false);
        particlesRejectEffect.SetActive(false);
        particlesAttractEffect.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && myMagnet.activeSelf)
        {
            myMagnet.SetActive(false);
            particlesAttractEffect.SetActive(false);
        }
        else if (Input.GetMouseButtonDown(0) && !myMagnet.activeSelf)
        {
            myMagnet.SetActive(true);
            particlesAttractEffect.SetActive(true);
        }


       /* if (Input.GetMouseButtonUp(1))
        {
            myMagnet.SetActive(false);
            particlesRejectEffect.SetActive(true);
            particlesAttractEffect.SetActive(false);
        }*/
    }

}
