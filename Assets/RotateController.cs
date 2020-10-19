using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private void Update()
    {
        var rotation = transform.rotation * Quaternion.AngleAxis(90.0f, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}
