using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerJoinArms : MonoBehaviour
{
    public GameObject[] partsSlots;
    public GameObject JumpSlot;
    public GameObject MagnetSlot;
    public GameObject JetpackSlot;
    private bool shouldGetObject;
    public PlayerJump myPlayerJump;
    public CircleCollider2D rangeCollider;
    public GameObject TrashExplotion;
    public GameObject fadeOut;
    bool change = false;
    private void Start()
    {

        shouldGetObject = true;
    }

    void Update()
    {
        if (change) {
            SceneManager.LoadScene("Inicio");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PARTS" && shouldGetObject) {
            collision.gameObject.GetComponent<MagnetAttraction>().target = null;
            Destroy(collision.gameObject.GetComponent<Rigidbody2D>());
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            GameObject mySlot = getAvailableArmSlot();
            if (mySlot != null) {
                Transform myCollitionT = collision.transform;
                myCollitionT.SetParent(mySlot.transform);
                collision.transform.localPosition = Vector3.zero;
                collision.transform.localRotation = Quaternion.identity;
            }
        }

        if (collision.gameObject.tag == "HAZARD") {
            if (!hasProtection()) {
                Instantiate(TrashExplotion);
                Destroy(gameObject);
                StartCoroutine(End());
               SceneManager.LoadScene("Inicio");
            }
        }
    }

    IEnumerator End()
    {
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1f);
        change = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "JUMPSLOT")
        {
            StartCoroutine(SetParent(collision, JumpSlot));
            //gameObject.GetComponent<PlayerMovement>().enabled = false;
            myPlayerJump.addJump();
        }

        if (collision.gameObject.tag == "JETPACKSLOT")
        {
            StartCoroutine(SetParent(collision, JetpackSlot));
           // gameObject.GetComponent<PlayerJump>().enabled = false;
            //gameObject.GetComponent<PlayerDash>().enabled = true;
        }

        if (collision.gameObject.tag == "MAGNETSLOT")
        {
            StartCoroutine(SetParent(collision, MagnetSlot));
            rangeCollider.radius = 40;
        }

    }

    private GameObject getAvailableArmSlot() {
        int index = Random.Range(0, partsSlots.Length);
        return partsSlots[index];
    }

    private void dropObjectFormSlots() {
        for (var i = 0; i < partsSlots.Length; i++)
        {
            GameObject slot = partsSlots[i];
            for (var j = 0; j < slot.transform.childCount; j++){
                GameObject mySlotChild =  slot.transform.GetChild(j).gameObject;
                mySlotChild.AddComponent<Rigidbody2D>();
                mySlotChild.transform.SetParent(null);

            }
        }
        StartCoroutine(ResetMagnet());
    }

    IEnumerator ResetMagnet()
    {
        shouldGetObject = false;
        yield return new WaitForSeconds(2f);
        shouldGetObject = true;
    }

    IEnumerator SetParent(Collider2D collision, GameObject parent )
    {
        collision.gameObject.transform.SetParent(parent.transform);
        yield return new WaitForSeconds(0.2f);
        //transform.rotation = Quaternion.identity;
        collision.gameObject.GetComponent<Collider2D>().isTrigger = true;
        collision.gameObject.transform.localRotation = Quaternion.identity;
        collision.gameObject.transform.localPosition = Vector3.zero;
        Destroy(collision.gameObject.GetComponent<Rigidbody2D>());
    }

    private bool hasProtection() {
        bool protection = false;
        for (var i = 0; i < partsSlots.Length; i++)
        {            
            GameObject slot = partsSlots[i];
            for (var j = 0; j < slot.transform.childCount; j++)
            {
                if (slot.transform.GetChild(j) != null) {
                    protection = true;
                }
            }
        }
        return protection;
    }

}
