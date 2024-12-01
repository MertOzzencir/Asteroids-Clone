using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    Rigidbody rb;
    bool canExplode;
    public float GrenadeRadius;
    public float ExplonationForce;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        if (canExplode) {
           
                Collider[] collider = Physics.OverlapSphere(transform.position, GrenadeRadius);
                foreach(Collider colliders in collider) {
                    Rigidbody enemyRb = colliders.GetComponent<Rigidbody>();
                    Die die = colliders.GetComponent<Die>();
                    if(enemyRb != null && die !=null) {

                        enemyRb.AddExplosionForce(ExplonationForce, transform.position, GrenadeRadius);
                    Destroy(die.gameObject);
                    }
                    
                }
            Destroy(gameObject,.55f);

            canExplode = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet") {
            canExplode = true;
            StartCoroutine(CameraShaker.instance.CameraShakeEnabled());

        }
    }


}
