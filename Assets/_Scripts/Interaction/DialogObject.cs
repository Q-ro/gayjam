using Scripts.PlayerInput;
using TMPro;
using UnityEngine;

namespace Scripts.Interaction
{
    public class DialogObject : InteractableObjectBase
    {
        [Header("Ink JSON")]
        [SerializeField] private TextAsset inkJson;
        [SerializeField] private GameObject bubbleGameObject;
        [SerializeField] private TextMeshProUGUI bubbleText;
        private DialogueManager dialogueManager;
        protected override void Start()
        {
            base.Start();
            IsInteractable = true;
            dialogueManager = DialogueManager.GetInstance();
        }
        public override void Interact()
        {
            if(dialogueManager.CanExitDialogue){
                Debug.Log("Exit dialog");
                dialogueManager.CanExitDialogue = false;
                IsInteractable = false;
            } else {
                if(!dialogueManager.DialogueIsPlaying){
                    dialogueManager.DialogueBubble = bubbleGameObject;
                    dialogueManager.DialogueText = bubbleText;
                    Debug.Log("Entering Dialogue Mode");
                    dialogueManager.EnterDialogueMode(inkJson);
                }
            }
        }
    }
}