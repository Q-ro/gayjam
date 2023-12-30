using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.UI
{
    public struct InspectableInfo
    {
        public string name;
        public string colot;
        public string material;
        public string brand;
        public string year;
        public string description;
    }

    public class InspectedInfoDisplay : MonoBehaviour
    {
        [SerializeField] InspectableInfo info;

        private void UpdateInfoDisplay(InspectableInfo info)
        {

        }
    }
}

