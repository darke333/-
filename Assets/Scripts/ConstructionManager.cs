using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConstructionManager : MonoBehaviour
{
    
    public static ConstructionManager instance = null;
    public Part[] FrontLeft;
    public Part[] FrontRight;
    public Part[] BackLeft;
    public Part[] BackRight;
    public Part[] Connections;
    public Part[] Wheels;

    public GameObject Car;


    public Part[] parts;

    public int FLIndex = 0;
    public int FRIndex = 0;
    public int BLIndex = 0;
    public int BRIndex = 0;
    public int ConnectionIndex = 0;
    public int WheelIndex = 0;


    bool FLFinished = false;
    bool FRFinished = false;
    bool BLFinished = false;
    bool BRFinished = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PartActivate(FLIndex, FrontLeft);
        PartActivate(FRIndex, FrontRight);
        PartActivate(ConnectionIndex, Connections);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            AutoCarFix();
        }
        if(FLFinished && FRFinished && BLFinished && BRFinished)
        {
            Car.GetComponent<CarChangeBehaviour>().enabled = true;
            Destroy(this);
        }
    }

    public void NextHint(int ArrayNumber)
    {
        //ActivatePart(++partIndex);
        if (FRFinished && FLFinished && BLFinished && BRFinished)
        {
            Car.GetComponent<CarChangeBehaviour>().enabled = true;
            Destroy(this);
        }
        switch (ArrayNumber)
        {
            case 1:
                if(FLIndex == FrontLeft.Length - 1)
                {
                    FLFinished = true;
                    
                }
                else
                {
                    print(FLIndex);

                    PartActivate(++FLIndex, FrontLeft);
                }
                break;
            case 2:
                if (FRIndex == FrontRight.Length - 1)
                {
                    FRFinished = true;
                }
                else
                {
                    PartActivate(++FRIndex, FrontRight);
                }
                break;
            case 3:
                if (BLIndex == BackLeft.Length - 1)
                {
                    BLFinished = true;
                }
                else
                {
                    PartActivate(++BLIndex, BackLeft);
                }
                break;
            case 4:
                if (BRIndex == BackRight.Length - 1)
                {
                    BRFinished = true;
                }
                else
                {
                    PartActivate(++BRIndex, BackRight);
                }
                break;
            case 5:
                if (ConnectionIndex == Connections.Length - 1)
                {
                    PartActivate(BLIndex, BackLeft);
                    PartActivate(BRIndex, BackRight);
                    ConnectionIndex++;
                }
                else
                {
                    PartActivate(++ConnectionIndex, Connections);
                }
                break;
        }
    }

    void CheckAndActivate(int i, Part[] PartArray)
    {
        if (FLIndex == FrontLeft.Length)
        {
            FLFinished = true;
        }
        else
        {
            PartActivate(FLIndex++, FrontLeft);
        }
    }

    
    void ActivatePart(int index)
    {
        if (index < 0 || index >= parts.Length)
        {
            return;
        }

        for (int i = 0; i < parts.Length; ++i)
        {
            if (parts[i] == null)
            {
                continue;
            }

            if (i == index)
            {
                parts[i].SetHintEnabled(true);
                GameObject[] otherParts = GameObject.FindGameObjectsWithTag(parts[i].tag);

                foreach (GameObject part in otherParts)
                {
                    FixedPart fixedPart = part.GetComponent<FixedPart>();
                    if (fixedPart && fixedPart.state == FixedPart.State.Disabled)
                    {
                        fixedPart.state = FixedPart.State.Highlighted;
                    }
                }
            }
            else
            {
                parts[i].SetHintEnabled(false);
                GameObject[] otherParts = GameObject.FindGameObjectsWithTag(parts[i].tag);
                foreach (GameObject part in otherParts)
                {
                    FixedPart fixedPart = part.GetComponent<FixedPart>();
                    if (fixedPart && fixedPart.state != FixedPart.State.Visible)
                    {
                        fixedPart.state = FixedPart.State.Disabled;
                    }
                }
            }
        }
    }
    

    void PartActivate(int i, Part[] PartArray)
    {
        //print(i);
        PartArray[i].SetHintEnabled(true);
        GameObject[] otherParts = GameObject.FindGameObjectsWithTag(PartArray[i].tag);
        foreach (GameObject part in otherParts)
        {
            FixedPart fixedPart = part.GetComponent<FixedPart>();
            if (fixedPart && fixedPart.state == FixedPart.State.Disabled)
            {
                fixedPart.state = FixedPart.State.Highlighted;
            }
        }
    }

    public void AutoCarFix()
    {
        if (!FLFinished)
        {
            for (int i = FLIndex; i < FrontLeft.Length; i++)
            {
                Part part = FrontLeft[i];
                GameObject[] OtherPart = GameObject.FindGameObjectsWithTag(part.tag);
                foreach (GameObject parts in OtherPart)
                {
                    FixedPart fixedPart = parts.GetComponent<FixedPart>();
                    if (fixedPart)
                    {
                        parts.transform.Find("SnapDropZone").GetComponent<SnapControll>().NextPart();
                    }
                }
            }
        }
        if (!FRFinished)
        {
            for (int i = FRIndex; i < FrontRight.Length; i++)
            {
                Part part = FrontRight[i];
                GameObject[] OtherPart = GameObject.FindGameObjectsWithTag(part.tag);
                foreach (GameObject parts in OtherPart)
                {
                    FixedPart fixedPart = parts.GetComponent<FixedPart>();
                    if (fixedPart)
                    {
                        parts.transform.Find("SnapDropZone").GetComponent<SnapControll>().NextPart();

                    }
                }
            }
        }
        for (int i = ConnectionIndex; i < Connections.Length ; i++)
        {
            Part part = Connections[i];
            GameObject[] OtherPart = GameObject.FindGameObjectsWithTag(part.tag);
            foreach (GameObject parts in OtherPart)
            {
                FixedPart fixedPart = parts.GetComponent<FixedPart>();
                if (fixedPart)
                {
                    parts.transform.Find("SnapDropZone").GetComponent<SnapControll>().NextPart();


                }
            }
        }
        if (!BLFinished)
        {
            for (int i = BLIndex; i < BackLeft.Length; i++)
            {
                Part part = BackLeft[i];
                GameObject[] OtherPart = GameObject.FindGameObjectsWithTag(part.tag);
                foreach (GameObject parts in OtherPart)
                {
                    FixedPart fixedPart = parts.GetComponent<FixedPart>();
                    if (fixedPart)
                    {
                        parts.transform.Find("SnapDropZone").GetComponent<SnapControll>().NextPart();

                    }
                }
            }
        }
        if (!BRFinished)
        {
            for (int i = BRIndex; i < BackRight.Length; i++)
            {
                Part part = BackRight[i];
                GameObject[] OtherPart = GameObject.FindGameObjectsWithTag(part.tag);
                foreach (GameObject parts in OtherPart)
                {
                    FixedPart fixedPart = parts.GetComponent<FixedPart>();
                    if (fixedPart)
                    {
                        parts.transform.Find("SnapDropZone").GetComponent<SnapControll>().NextPart();

                    }
                }
            }
        }
        Car.GetComponent<CarChangeBehaviour>().enabled = true;
        Destroy(this.gameObject);
    }



}
