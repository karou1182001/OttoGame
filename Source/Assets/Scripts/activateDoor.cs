using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateDoor : MonoBehaviour
{

    [SerializeField]
    GameObject buttonPressed;

    [SerializeField]
    GameObject buttonNotPressed;
    public GameObject door;

    public bool isOn = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = buttonNotPressed.GetComponent<SpriteRenderer>().sprite;
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = buttonPressed.GetComponent<SpriteRenderer>().sprite;
        isOn = true;
        Destroy(door);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
