using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillerMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;


    void Update()
    {
        transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);

        if(transform.position.z <= 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 39 * 0.75f);
        }
    }
}
