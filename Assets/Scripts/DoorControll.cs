using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables;

public class DoorControll : MonoBehaviour
{
    public VRTK_BaseControllable controllable;
    public Transform door;
    public Transform MaxUpPoint;
    public Transform MaxDownPoint;

    void Update()
    {
        if (controllable.AtMaxLimit() && gameObject.name == "buttonUp")
        {
            door.position = Vector3.MoveTowards(door.transform.position, MaxUpPoint.position, Time.deltaTime * 0.5f);
        }
        if (controllable.AtMaxLimit() && gameObject.name == "buttonDown")
        {
            door.position = Vector3.MoveTowards(door.transform.position, MaxDownPoint.position, Time.deltaTime * 0.5f);
        }
    }
}
