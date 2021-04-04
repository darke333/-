using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmissonRotate : MonoBehaviour
{
    //public Transform UpPart;
    //public Transform MiddlePart;
    public Transform UpPart;
    public float StartZ;
    public Quaternion v1;
    public Quaternion v2;

    void Start()
    {
        StartZ = UpPart.rotation.z;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rotate = UpPart.localRotation;
        Quaternion changiing = transform.rotation;
        transform.localRotation = new Quaternion(0, 0, (rotate.z - StartZ), 0);
        v1 = UpPart.localRotation;
        v2 = transform.localRotation;
    }
}
