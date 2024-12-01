using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DestroyShip : MonoBehaviour
{
    public List<GameObject> hearts;
    float sayac;
    private void Update()
    {
        sayac += Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && sayac > 3f) {
            sayac = 0;
            if (hearts.Count > 0) {
                StartCoroutine(CameraShaker.instance.CameraShakeEnabled());
                Destroy(hearts[hearts.Count-1]);
                hearts.RemoveAt(hearts.Count - 1); 
            }
            else
                Destroy(gameObject);
        }
            
    }

   


}
