using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingCamera : MonoBehaviour
{
    public GameObject PositionReference;
    void Update()
    {
        transform.position = PositionReference.GetComponent<Transform>().position;
    }
}
