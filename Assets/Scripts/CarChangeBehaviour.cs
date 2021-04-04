using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables;
using VRTK.Controllables.PhysicsBased;

public class CarChangeBehaviour : MonoBehaviour
{
    public GameObject TepeleportingPlace;
    //public GameObject Trigger;

    public Transform FinishingPosition;

    public GameObject CarUpParts;
    public GameObject Finishparts;
    public Transform[] UpParts;
    public Transform[] FinishUpParts;
    public bool UpPartsChanged;

    public GameObject PodObj;
    public Transform PodFinishPoint;
    public GameObject[] PodButtons;
    public GameObject PodColliders;

    void Start()
    {
        UpPartsChanged = false;
    }

    void FixedUpdate()
    {
        if (transform.position == FinishingPosition.position)
        {
            for (int i = 0; i < 4; i++)
            {
                UpParts[i].rotation = Quaternion.RotateTowards(UpParts[i].rotation, FinishUpParts[i].rotation, Time.deltaTime * 5);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, FinishingPosition.position, Time.deltaTime * 0.2f);
        }

        if (UpParts[3].rotation == FinishUpParts[3].rotation)
        {
            Finishparts.SetActive(true);
            CarUpParts.SetActive(false);
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<SimpleCarController>().enabled = true;
            TepeleportingPlace.SetActive(true);
            for (int i = 0; i < 2; i++)
            {
                PodButtons[i].GetComponent<VRTK_PhysicsPusher>().enabled = false;
            }
            PodColliders.SetActive(false);
            UpPartsChanged = true;

        }
        if (UpPartsChanged)
        {
            if (PodObj.transform.position != PodFinishPoint.position)
            {
                PodObj.transform.position = Vector3.MoveTowards(PodObj.transform.position, PodFinishPoint.position, Time.deltaTime * 0.6f);
            }
            else
            {

                for (int i = 0; i < 2; i++)
                {
                    PodColliders.SetActive(true);
                }
                Destroy(this);
            }
        }
    }
}
