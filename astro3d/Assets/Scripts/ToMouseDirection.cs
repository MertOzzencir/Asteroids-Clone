using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMouseDirection : MonoBehaviour
{
    Camera cam;
    public LayerMask mask;
    public GameObject MouseThreshHolder;
    private void Start()
    {
        cam= Camera.main;
    }
    void Update()
    {
        Ray ray = cam.ScreenPointToRay( Input.mousePosition );
        RaycastHit hit;


        if (Physics.Raycast(ray,out hit,100f,mask) && Vector3.Distance(transform.position,hit.point) >2f){
            MouseThreshHolder.SetActive(true);
            Vector3 forwardtoturn = (hit.point - transform.position).normalized;
            transform.forward = forwardtoturn;
            MouseThreshHolder.transform.position = hit.point;
        }
        else {
            MouseThreshHolder.SetActive(false);
        }

    }
}
