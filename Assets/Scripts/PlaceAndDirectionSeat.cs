using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PlaceAndDirectionSeat : MonoBehaviour
{
    public bool Inside;
    public Transform NormalParent;
    public Transform InsideCarParent;
    public Transform VRTKController;

    void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "[VRTK][AUTOGEN][BodyColliderContainer]")
        {
            VRTKController.SetParent(InsideCarParent);
            Inside = true;
        }
    }
     void OnTriggerExit(Collider other)
    {
        if (other.transform.name == "[VRTK][AUTOGEN][BodyColliderContainer]")
        {
            VRTKController.SetParent(NormalParent);
            Inside = false;
        }
    }

}
