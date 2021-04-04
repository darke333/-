namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.UI;
    using VRTK.Controllables;

    public class ControllableReactor : MonoBehaviour
    {
        public VRTK_BaseControllable controllable;
        public Text displayText;
        public string outputOnMax = "Maximum Reached";
        public string outputOnMin = "Minimum Reached";

  

        protected virtual void OnEnable()
        {
            controllable = (controllable == null ? GetComponent<VRTK_BaseControllable>() : controllable);
            controllable.ValueChanged += ValueChanged;
            controllable.MaxLimitReached += MaxLimitReached;
            controllable.MinLimitReached += MinLimitReached;
            controllable.MaxLimitExited += Controllable_MaxLimitExited;
            controllable.MinLimitExited += Controllable_MinLimitExited;
        }

        private void Controllable_MinLimitExited(object sender, ControllableEventArgs e)
        {
            print("минимум exit");
            
        }

        private void Controllable_MaxLimitExited(object sender, ControllableEventArgs e)
        {
            print("максимум exit");
        }

        protected virtual void ValueChanged(object sender, ControllableEventArgs e)
        {
            if (displayText != null)
            {
                displayText.text = e.value.ToString();
                
            }
        }

        protected virtual void MaxLimitReached(object sender, ControllableEventArgs e)
        {
            displayText.text = e.value.ToString("max");
            print("максимум");
            if (outputOnMax != "")
            {
                Debug.Log(outputOnMax);
            }
        }

        protected virtual void MinLimitReached(object sender, ControllableEventArgs e)
        {
            displayText.text = e.value.ToString("min");
            print("минимум");
            if (outputOnMin != "")
            {
                Debug.Log(outputOnMin);
            }
        }
    }
}