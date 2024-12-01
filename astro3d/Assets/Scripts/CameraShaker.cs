using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public static CameraShaker instance;
    Vector3 StartedPosition;
    [SerializeField] public float cameraShakeAmount = 0.2f;
    float i;
    void Awake()
    {
        
        instance = this;
        StartedPosition = transform.position;
    }

    void Update()
    {
            transform.position = StartedPosition + Random.insideUnitSphere * cameraShakeAmount;

    }
    public IEnumerator CameraShakeEnabled()
    {
        cameraShakeAmount = 0.55f;
        Camera.main.GetComponent<CameraShaker>().enabled = true;

        yield return new WaitForSeconds(.5f);

        Camera.main.GetComponent<CameraShaker>().enabled = false;

    }


}
