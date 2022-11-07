using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Press : MonoBehaviour

{
    Rigidbody2D rb;
    Transform Pos;
    Vector3 posin;
    public Vector3 posfinal;
    public int speed;
    public bool disable = false;
    public AudioClip sonido;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        int sound = 0;
        audio = GetComponent<AudioSource>();
        posin = transform.position;
        rb = GetComponent<Rigidbody2D>();
        disable = false;
        //Debug.Log("pos inicial: "+posin);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("FLOOR"))
        {
            
        }
    }
    

    public void StartSmash() {
        StartCoroutine(goDown(posfinal));
    }

    IEnumerator goDown(Vector3 targetPosition) {
        int sound = 0;
        while (transform.position.y > targetPosition.y) {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
            sound = 1;
           
        }
        //if (sound ==1)
        //{
            audio.PlayOneShot(sonido, 1);
            sound = 0;
        //}
        
        gameObject.GetComponent<Collider2D>().isTrigger = true;
        yield return new WaitForSeconds(1f);
        StartCoroutine(goUp(posin));
       
    }

    IEnumerator goUp(Vector3 targetPosition)
    {
        
        disable = true;
        while (transform.position.y < targetPosition.y)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
        //yield return new WaitForSeconds(4f);
        //disable = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
