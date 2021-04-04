using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetWork : MonoBehaviour
{

    public Transform MagnetToPoint;


    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            other.GetComponent<Rigidbody>().useGravity = false;
            other.GetComponent<Part>().speed += Time.deltaTime;
            print(other.GetComponent<Part>().speed);
            other.transform.position = Vector3.MoveTowards(other.transform.position, MagnetToPoint.position, other.GetComponent<Part>().speed);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            other.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
