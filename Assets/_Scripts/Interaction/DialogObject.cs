using Scripts.PlayerInput;
using TMPro;
using UnityEngine;

namespace Scripts.Interaction
{
    public class DialogObject : InteractableObjectBase
    {
        [SerializeField] GameObject objectToSpawn;

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
            InputManager.OnInteract += EndDialogue;
        }

        private void OnDestroy()
        {
            InputManager.OnInteract -= EndDialogue;
        }
        public override void Interact()
        {

        }

        public override void StartInteraction()
        {
            if (!dialogueManager.CanExitDialogue && !dialogueManager.DialogueIsPlaying)
            {
                dialogueManager.DialogueBubble = bubbleGameObject;
                dialogueManager.DialogueText = bubbleText;
                Debug.Log("Entering Dialogue Mode");
                dialogueManager.EnterDialogueMode(inkJson);
            }

        }

        public override void EndInteraction()
        {

        }

        private void EndDialogue()
        {
            if (dialogueManager.CanExitDialogue)
            {
                Debug.Log("Exit dialog");
                dialogueManager.CanExitDialogue = false;
                IsInteractable = false;
                if (objectToSpawn == null)
                    return;
                var spawnPosition = GameObject.FindWithTag("TableObjectSpawnerPosition").transform.position;
                var go = Instantiate(objectToSpawn);
                go.transform.position = spawnPosition;
            }
        }
    }
}