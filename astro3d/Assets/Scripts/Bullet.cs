using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public int AttackDamage;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed * Time.fixedDeltaTime);
        Destroy(gameObject,.9f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy") {
            collision.gameObject.GetComponent<Die>().Health -= AttackDamage;

            if (collision.gameObject.GetComponent<Die>().Health <= 0) {
                Destroy(collision.gameObject); 
            }
            Destroy(gameObject);


        }



    }




}
