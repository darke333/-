using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class EnableMagnet : MonoBehaviour
{
    public GameObject MagneticField;


    public void OffMagnet()
    {
        MagneticField.SetActive(false);
    }

    public void OnMagnet()
    {
        MagneticField.SetActive(true);
    }



}
