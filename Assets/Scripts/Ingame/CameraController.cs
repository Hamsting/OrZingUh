using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public static CameraController instance;

    public Transform target;

    public Vector3 margin;

    [SerializeField]
    float lerpTime;

    Transform tr;


    private void Awake()
    {
        tr = GetComponent<Transform>();
        instance = this;
    }

    public void SetTarget(Transform _target) {
        target = _target;
    }

    private void FixedUpdate()
    {
        if (target != null) {
            tr.position = Vector3.Slerp(tr.position, target.position + margin,Time.deltaTime * lerpTime);
        }
    }



}
