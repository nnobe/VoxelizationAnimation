using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCamera : MonoBehaviour {

    public Vector3 offset;
    public Transform target;

    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }

}
