using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float move = 1f;

    [HideInInspector]
    public Vector3 targetPos;
    private void Start()
    {
        targetPos = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, move * Time.deltaTime);
    }
}
