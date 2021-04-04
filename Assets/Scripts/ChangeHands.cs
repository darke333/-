using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ChangeHands : MonoBehaviour
{
    public VRTK_SDKManager manager;
    public GameObject CustomHandPointerLeft;
    public GameObject CustomHandPointerRight;
    public GameObject LineHandPointerLeft;
    public GameObject LineHandPointerRight;
    bool IsCustom;

    // Start is called before the first frame update
    void Start()
    {
        IsCustom = true;
    }


    public void Change(GameObject o)
    {
        if (o.tag == "left")
        {
            if (IsCustom)
            {
                manager.scriptAliasLeftController = LineHandPointerLeft;
                IsCustom = false;
            }
            else
            {
                manager.scriptAliasLeftController = CustomHandPointerLeft;
                IsCustom = true;
            }
        }
        if (o.tag == "right")
        {
            if (IsCustom)
            {
                manager.scriptAliasRightController = LineHandPointerRight;
                IsCustom = false;
            }
            else
            {
                manager.scriptAliasRightController = CustomHandPointerRight;
                IsCustom = true;
            }
        }
    }
}
