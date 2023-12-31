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
        private GameObject tableObjectSpawnerPosition;

        public void SetUpTableSpawnPosition(GameObject tableObjectSpawnerPosition)
        {
            this.tableObjectSpawnerPosition = tableObjectSpawnerPosition;
        }

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
                //Debug.Log("Exit dialog");

                if (isDroppingObject)
                {
                    if (objectToSpawn == null)
                        return;
                    dialogueManager.CanExitDialogue = false;
                    IsInteractable = false;
                    TableDropObjectSpawner.OnSpawnDropObject?.Invoke(objectToSpawn);
                }
                else
                {
                    Debug.Log("object retrived");
                    //if object is in table
                    var a = GameObject.FindAnyObjectByType<InspectableObject>();
                    if (a == null)
                        return;
                    Debug.Log("Object is not null");
                    Debug.Log("object destroyed");
                    dialogueManager.CanExitDialogue = false;
                    Destroy(a.gameObject);
                    OnObjectWasRetrieved?.Invoke();
                    //Destroy(this.gameObject);
                    // if (a.IsInteractable)
                    // {
                        
                    // }
                }
            }
        }
    }
}