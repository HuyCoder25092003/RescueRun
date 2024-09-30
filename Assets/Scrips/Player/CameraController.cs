using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform trans;
    [SerializeField]Transform target;
    private void Awake()
    {
        trans = transform;
    }
    void LateUpdate()
    {
        trans.position = target.position;   
    }
}
