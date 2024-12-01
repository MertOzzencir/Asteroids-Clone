using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class MoveShip : MonoBehaviour
{

    Rigidbody rb;
    public float speed;
    bool canMove;
    int moveBack;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
    }
    void Update()
    {
        if (UnityEngine.Input.GetKey(KeyCode.W)) {
            moveBack = 1;
            canMove = true;

        }
        else if (UnityEngine.Input.GetKey(KeyCode.S)) {
            moveBack = -1;
            canMove = true;

        }
        else
            canMove = false;



    }
    private void FixedUpdate()
    {
        if(canMove)
            rb.AddForce(transform.forward * speed * moveBack);
    }
    

    
}
