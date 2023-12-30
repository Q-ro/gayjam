using Scripts.PlayerInput;
using UnityEngine;

namespace Scripts.Interaction
{
    public class DialogObject : InteractableObjectBase
    {
        [Header("Ink JSON")]
        [SerializeField] private TextAsset inkJson;
        protected override void Start()
        {
            base.Start();
            IsInteractable = true;
        }
        public override void Interact()
        {
            IsInteractable = false;
            Debug.Log(inkJson);
        }
    }
}