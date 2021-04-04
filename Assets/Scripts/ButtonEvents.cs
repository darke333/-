using UnityEngine;
using UnityEngine.UI;
using VRTK.Controllables;

public class ButtonEvents : MonoBehaviour
{

    public VRTK_BaseControllable controllable;
    public Transform car;
    public Transform MaxUpPoint;
    public Transform MaxDownPoint;
    public Transform Holder;

    void Update()
    {
        if (controllable.AtMaxLimit() && gameObject.name == "AutoFixbutton")
        {
            if (GameObject.Find("Hints"))
            {
                GameObject.Find("Hints").GetComponent<ConstructionManager>().AutoCarFix();
            }
        }
        if (controllable.AtMaxLimit() && gameObject.name == "buttonUp" && car.position.y - MaxUpPoint.position.y < 0.001)
        {
            car.position = Vector3.MoveTowards(car.transform.position, MaxUpPoint.position, Time.deltaTime * 0.5f);
            //Holder.position = Vector3.MoveTowards(Holder.transform.position, MaxUpPoint.position, Time.deltaTime * 0.5f);

        }
        if (controllable.AtMaxLimit() && gameObject.name == "buttonDown" && car.position.y - MaxDownPoint.position.y > 0.001)
        {
            car.position = Vector3.MoveTowards(car.transform.position, MaxDownPoint.position, Time.deltaTime * 0.5f);
            //Holder.position = Vector3.MoveTowards(Holder.transform.position, MaxDownPoint.position, Time.deltaTime * 0.5f);

        }
    }
}
