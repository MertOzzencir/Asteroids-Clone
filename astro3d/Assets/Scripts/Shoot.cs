using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform[] BulletPoint;
    public GameObject Bullet;
    public bool canMultiple;

    private void Start()
    {
        Die.OnScore += CheckScoreForMulitpleShoot;

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {
            if(!canMultiple) {
                for(int i =0; i <1; i++) {

                    Instantiate(Bullet, BulletPoint[i].position, BulletPoint[i].rotation);
                }
            }
            else {
                for (int i = 0; i < BulletPoint.Length; i++) {

                    Instantiate(Bullet, BulletPoint[i].position, BulletPoint[i].rotation);
                }
            }
        }
    }


    void CheckScoreForMulitpleShoot(int score)
    {
        if(score > 200f) {
            canMultiple = true;
        }
    }
}
