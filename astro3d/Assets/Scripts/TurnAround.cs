using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurnAround : MonoBehaviour
{
    public float TorquePower;
    Rigidbody rb;
    enum State
    {
        Left,
        Right
    }

    State state;

    private void Start()
    {
        TorquePower = Random.Range(4f, 8f);
        rb = GetComponent<Rigidbody>();
        int randomStateSelection = Random.Range(0, 2);
        if(randomStateSelection == 0) {
            state = State.Left;
        }
        else {
            state = State.Right;
        }
    }

    private void FixedUpdate()
    {
        if(state == State.Left) {

            rb.AddTorque(Vector3.up * TorquePower, ForceMode.Impulse);
        }
        else {
            rb.AddTorque(-Vector3.up * TorquePower, ForceMode.Impulse);
        }

    }




}
