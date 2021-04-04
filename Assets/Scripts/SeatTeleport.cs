using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SeatTeleport : MonoBehaviour
{
    public VRTK_DestinationPoint controller;
    public Transform CameraT;
    public Transform teleportPoint;
    public float difference;
    public Vector3 TP;
    public Vector3 C;
    public Vector3 vec;
    Vector3 startPos;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = teleportPoint.position;
        controller.DestinationMarkerEnter += Controller_DestinationMarkerEnter;
    }


    private void Controller_DestinationMarkerEnter(object sender, DestinationMarkerEventArgs e)
    {
        print("Entered");
    }



    // Update is called once per frame
    void Update()
    {

        C = CameraT.position;
        TP = teleportPoint.position;
        difference = C.y - 0.9f;
        vec = TP;
        vec.y = startPos.y - difference;
        teleportPoint.position = vec;

    }
}
