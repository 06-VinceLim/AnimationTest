using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    Animator PlayerAnimin;
    Rigidbody Player;
    public float speed = 5.0f;
    bool Death;

    // Start is called before the first frame update
    void Start()
    {
        PlayerAnimin = GetComponent<Animator>();
        Player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W) && Death == false)
        {
            PlayerAnimin.SetBool("IsStrafe", true);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKeyUp(KeyCode.W) && Death == false)
        {
            PlayerAnimin.SetBool("IsStrafe", false);
        }
        if (Input.GetKeyDown(KeyCode.Z) && Death == false)
        {
            PlayerAnimin.SetTrigger("TriggerAttack");
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Cube"))
        {
            PlayerAnimin.SetTrigger("Death");

            Death = true;
        }
    }
}
