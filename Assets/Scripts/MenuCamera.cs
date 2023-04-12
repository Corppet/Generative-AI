using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 20f;

    void Update()
    {
        // rotate along y-axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
