using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Part : MonoBehaviour
{
    public Hint hint;
    VRTK_InteractableObject vRTK_InteractableObject;
    float timer;
    public float speed;
    //public FixedPart ConnectedPart;
    



    void Start()
    {
        speed = 0f;
        GetComponent<VRTK_InteractableObject>().InteractableObjectUngrabbed += Part_InteractableObjectUngrabbed;
        timer = 0f;
    }

    private void Part_InteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
    {
        speed = 0f;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        print("Ungrabbed");
    }



    public void SetHintEnabled(bool enabled)
    {
        if (hint)
        {
            hint.gameObject.SetActive(enabled);
        }
    }

    /*void OnGrab()
    {
        //print(IsKinematic);
        if (vRTK_InteractableObject.Ungrabbed() && IsKinematic)
        {
            IsKinematic = false;
            print(rigidbody.isKinematic);
            print(IsKinematic);
        }
    }*/


    void Update()
    {
        if (!gameObject.GetComponent<Rigidbody>().useGravity )
        {
            speed = 0f;
            timer += Time.deltaTime;
        }
        if(timer > 4)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            timer = 0;
        }
    }
}
