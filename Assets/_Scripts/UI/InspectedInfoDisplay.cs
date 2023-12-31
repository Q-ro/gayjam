using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI
{
    public enum SignatureQuality {
        Normal,
        Bad,
        Awful,
        ExtremlyBad
    }
    [Serializable]
    public struct InspectableInfo
    {
        public string name;
        public string color;
        public string material;
        public string brand;
        public string year;
        public string description;
        public SignatureQuality signatureQuality;
    }

    public class InspectedInfoDisplay : MonoBehaviour
    {
        
        public static Action<InspectableInfo> OnUpdateInfoDisplay;
        public static Action<bool> OnShowInfoDisplay;

        [SerializeField] private GameObject inspectedInfoUI;
        [SerializeField] private TextMeshProUGUI nameDisplay;
        [SerializeField] private TextMeshProUGUI colorDisplay;
        [SerializeField] private TextMeshProUGUI materialDisplay;
        [SerializeField] private TextMeshProUGUI brandlDisplay;
        [SerializeField] private TextMeshProUGUI yearDisplay;
        [SerializeField] private TextMeshProUGUI descriptionDisplay;
        [SerializeField] private Image signatureDisplay;
        [SerializeField] private Sprite normalSignauture;
        [SerializeField] private Sprite badSignauture;
        [SerializeField] private Sprite awfulSignauture;
        [SerializeField] private Sprite extremelyBadSignauture;

        private void Start()
        {
            OnUpdateInfoDisplay += UpdateInfoDisplay;
            OnShowInfoDisplay += ToggleInfoDisplay;
            inspectedInfoUI.SetActive(false);
        }

        private void OnDestroy(){
            OnUpdateInfoDisplay += UpdateInfoDisplay;
            OnShowInfoDisplay += ToggleInfoDisplay;
        }

        private void UpdateInfoDisplay(InspectableInfo info)
        {
            nameDisplay.text = info.name;
            colorDisplay.text = info.color;
            materialDisplay.text = info.material;
            brandlDisplay.text = info.brand;
            yearDisplay.text = info.year;
            descriptionDisplay.text = info.description;
            switch(info.signatureQuality){
                case SignatureQuality.Normal:
                    signatureDisplay.sprite = normalSignauture;
                    break;
                case SignatureQuality.Bad:
                    signatureDisplay.sprite = badSignauture;
                    break;
                case SignatureQuality.Awful:
                    signatureDisplay.sprite = awfulSignauture;
                    break;
                case SignatureQuality.ExtremlyBad:
                    signatureDisplay.sprite = extremelyBadSignauture;
                    break;
            }
        }

        private void ToggleInfoDisplay(bool isActive){
            inspectedInfoUI.SetActive(isActive);
        }
    }
}

