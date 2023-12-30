using System;
using TMPro;
using UnityEngine;

namespace Scripts.UI
{
    [Serializable]
    public struct InspectableInfo
    {
        public string name;
        public string color;
        public string material;
        public string brand;
        public string year;
        public string description;
    }

    public class InspectedInfoDisplay : MonoBehaviour
    {
        public static Action<InspectableInfo> OnUpdateInfoDisplay;
        public static Action<bool> OnShowInfoDisplay;

        [SerializeField] TextMeshProUGUI nameDisplay;
        [SerializeField] TextMeshProUGUI colorDisplay;
        [SerializeField] TextMeshProUGUI materialDisplay;
        [SerializeField] TextMeshProUGUI brandlDisplay;
        [SerializeField] TextMeshProUGUI yearDisplay;

        private void Start()
        {
            OnUpdateInfoDisplay += UpdateInfoDisplay;
        }

        private void UpdateInfoDisplay(InspectableInfo info)
        {

        }
    }
}

