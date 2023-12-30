using Scripts.PlayerInput;
using System;
using TMPro;
using UnityEngine;

namespace Scripts.Interaction
{
    public class DialogObject : InteractableObjectBase
    {
        public static Action OnObjectWasRetrieved;
        [SerializeField] GameObject objectToSpawn;
        [SerializeField] bool isDroppingObject = false;

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

                if (isDroppingObject)
                {
                    if (objectToSpawn == null)
                        return;
                    dialogueManager.CanExitDialogue = false;
                    IsInteractable = false;
                    var spawnPosition = GameObject.FindWithTag("TableObjectSpawnerPosition").transform.position;
                    var go = Instantiate(objectToSpawn);
                    go.transform.position = spawnPosition;
                    //Destroy(this.gameObject);
                }
                else
                {
                    Debug.Log("object retrived");
                    //if object is in table
                    var a = GameObject.FindAnyObjectByType<InspectableObject>();
                    if (a == null)
                        return;
                    if (a.IsInteractable)
                    {
                        dialogueManager.CanExitDialogue = false;
                        Destroy(a.gameObject);
                        OnObjectWasRetrieved?.Invoke();
                        //Destroy(this.gameObject);
                    }
                }
            }
        }
    }
}