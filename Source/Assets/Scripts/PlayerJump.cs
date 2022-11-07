using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerJump : MonoBehaviour
{
    [Range(1,100)]
    public float jumpVelocity = 2.5f;
    public int maxJumps;
    private int jumpTurns = 1;
    public PlayerMovement myPlayerMovement;
    public float speed;
    public float JumpProgress { get; private set; }
    private float initialSpeed;
    public float accelerator;
    Vector3 targetJump;
    public AudioClip sonido;
    AudioSource audio;


    void Start()
    {
        audio = GetComponent<AudioSource>();   
    }

    void Update()
    {

        if (Input.GetButtonDown("Jump") && jumpTurns < maxJumps) {

            int numAl = Random.Range(0, 30);
            if (numAl%3==0)
            {
             audio.PlayOneShot(sonido, 1);
            }
 
            jumpTurns++;
            Vector2 horizontalMovement = Vector2.zero;
            if (Input.GetKey(KeyCode.D))
            {
                horizontalMovement = Vector2.right;
            }
            else if(Input.GetKey(KeyCode.A))
            {
                horizontalMovement = Vector2.left;
            }
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity + horizontalMovement * jumpVelocity*2;
        }

        if (Input.GetButtonDown("Jump") && jumpTurns < maxJumps)
        {
            gameObject.GetComponent<PlayerStopJump>().enabled = true;

        }

    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FLOOR") {
            jumpTurns = 0;
        }
    }

    public void addJump() {
        maxJumps++;
    }

    private IEnumerator JumpCoroutine(Vector3 destination, float maxHeight, float time)
    {
        Vector3 startPos = transform.position;
        Quaternion startRotation = transform.rotation;
        while (JumpProgress <= 1.0)
        {
            ChangeSpeedByMoveProgress(JumpProgress);
            JumpProgress += speed * Time.deltaTime / time;
            var height = Mathf.Sin(Mathf.PI * JumpProgress) * maxHeight;
            if (height < 0f)
            {
                height = 0f;
            }
            transform.position = Vector3.Lerp(startPos, destination, JumpProgress) + Vector3.up * height;
            transform.Rotate(0, 0, speed * 10 * JumpProgress);
            yield return null;
        }
        transform.position = destination;
        transform.rotation = new Quaternion();
    }

    private void ChangeSpeedByMoveProgress(float progress)
    {
        if (progress <= 0.2f)
        {
            speed = initialSpeed + initialSpeed * accelerator;
        }
        else if (progress > 0.2f && progress < 0.8f)
        {
            speed = initialSpeed;
        }
        else if (progress >= 0.8f)
        {
            speed = initialSpeed + initialSpeed * accelerator;
        }

    }
}
