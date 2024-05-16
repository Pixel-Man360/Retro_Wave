using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10f;

    void Update()
    {
        transform.Rotate(new Vector3(1, 0, 0) * rotationSpeed * Time.deltaTime);
    }
}
