using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SnapControll : MonoBehaviour
{
    public void NextPart()
    {
        FixedPart fixedPart = gameObject.transform.parent.GetComponent<FixedPart>();
        VRTK_SnapDropZone SnapZone = gameObject.GetComponent<VRTK_SnapDropZone>();
        Part part = SnapZone.highlightObjectPrefab.GetComponent<Part>();
        part.SetHintEnabled(false);
        Destroy(part.gameObject);
        part = null;
        fixedPart.state = FixedPart.State.Visible;
        ConstructionManager.instance.NextHint(fixedPart.PartArrayNumber);
        //Destroy(gameObject);
    }
}
