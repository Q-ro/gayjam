using TMPro;
using UnityEngine;
using Ink.Runtime;
using Scripts.PlayerInput;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject nextLbl;
    [SerializeField] private GameObject exitLbl;
    [Header("Choices UI")]
    [SerializeField] private GameObject choice1Lbl;
    [SerializeField] private TextMeshProUGUI choice1;
    [SerializeField] private GameObject choice2Lbl;
    [SerializeField] private TextMeshProUGUI choice2;
    [SerializeField] private GameObject choice3Lbl;
    [SerializeField] private TextMeshProUGUI choice3;

    private GameObject dialogueBubble;
    private TextMeshProUGUI dialogueText;

    private Story currentStory;

    private bool canExitDialogue = false;
    private bool dialogueIsPlaying = false;

    public bool CanExitDialogue { get => canExitDialogue; set => canExitDialogue = value; }
    public bool DialogueIsPlaying { get => dialogueIsPlaying; }
    public GameObject DialogueBubble { get => dialogueBubble; set => dialogueBubble = value; }
    public TextMeshProUGUI DialogueText { get => dialogueText; set => dialogueText = value; }

    private void Awake(){
        if( instance != null){
            Debug.LogWarning("Found more than one DIalogue Manager in the scene");
        }
        instance = this;
    }

    private void Start(){
        dialoguePanel.SetActive(false);
        InputManager.SubmitDialogue += OnSubmitDialoguePerformed;
        InputManager.Interact += OnInteractPerformed;
        InputManager.DialogueOption1 += OnDialogueOption1Performed;
        InputManager.DialogueOption2 += OnDialogueOption2Performed;
        InputManager.DialogueOption3 += OnDialogueOption3Performed;
    }

    private void OnDestroy(){
        InputManager.SubmitDialogue -= OnSubmitDialoguePerformed;
        InputManager.Interact -= OnInteractPerformed;
        InputManager.DialogueOption1 -= OnDialogueOption1Performed;
        InputManager.DialogueOption2 -= OnDialogueOption2Performed;
        InputManager.DialogueOption3 -= OnDialogueOption3Performed;
    }

    private void OnDialogueOption1Performed(){
        if(choice1.isActiveAndEnabled){
            currentStory.ChooseChoiceIndex(0);
            ContinueStory();
        }
    }

    private void OnDialogueOption2Performed(){
        if(choice2.isActiveAndEnabled){
            currentStory.ChooseChoiceIndex(1);
            ContinueStory();
        }
    }

    private void OnDialogueOption3Performed(){
        if(choice3.isActiveAndEnabled){
            currentStory.ChooseChoiceIndex(2);
            ContinueStory();
        }
    }

    private void OnSubmitDialoguePerformed(){
        ContinueStory();
    }

    private void OnInteractPerformed(){
        if(canExitDialogue){
            ExitDialogueMode();
        }
    }

    public static DialogueManager GetInstance(){
        return instance;
    }

    private void ContinueStory(){
        if (currentStory.canContinue){
            nextLbl.SetActive(true);
            // set the text for the current dialogue line
            dialogueText.text = currentStory.Continue();
            // display choices, if any, for this dialogue line
            DisplayChoices();
            // chekc if we are at the end of the story
            if(!currentStory.canContinue && currentStory.currentChoices.Count == 0){
                exitLbl.SetActive(true);
                nextLbl.SetActive(false);
                canExitDialogue = true;
            }
        } else {
            exitLbl.SetActive(true);
            nextLbl.SetActive(false);
            canExitDialogue = true;
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON){
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialogueBubble.SetActive(true);
        dialoguePanel.SetActive(true);
        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialogueBubble.SetActive(false);
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        nextLbl.SetActive(false);
        exitLbl.SetActive(false);
    }

    private void DisplayChoices(){
        List<Choice> currentChoices = currentStory.currentChoices;
        // Hardcoded limit for number of choices
        if (currentChoices.Count > 3){
            Debug.LogError("More choices were given than the UI can support. Number of choices given: " + currentChoices.Count);
        }

        if (currentChoices.Count == 0){
            dialoguePanel.SetActive(false);
            return;
        }
        
        nextLbl.SetActive(false);
        dialoguePanel.SetActive(true);
        int index = 0;
        // enable and initialize the choices up to the amount of choices for this line of dialogue
        foreach(Choice choice in currentChoices){
            switch(index){
                case 0:
                    choice1.gameObject.SetActive(true);
                    choice1Lbl.SetActive(true);
                    choice1.text = choice.text;
                    break;
                case 1:
                    choice2.gameObject.SetActive(true);
                    choice2Lbl.SetActive(true);
                    choice2.text = choice.text;
                    break;
                case 2:
                    choice3.gameObject.SetActive(true);
                    choice3Lbl.SetActive(true);
                    choice3.text = choice.text;
                    break;
                default:
                    Debug.LogError("The number of choices has been manipulated to a number not supported.");
                    break;
            }
            index++;
        }
        // go through the remaining choices the UI supports and make sure they're hidden
        for(int i = index; i < 3; i++){
            switch(index){
                case 0:
                    choice1.gameObject.SetActive(false);
                    choice1Lbl.SetActive(false);
                    choice1.text = "";
                    break;
                case 1:
                    choice2.gameObject.SetActive(false);
                    choice2Lbl.SetActive(false);
                    choice2.text = "";
                    break;
                case 2:
                    choice3.gameObject.SetActive(false);
                    choice3Lbl.SetActive(false);
                    choice3.text = "";
                    break;
                default:
                    Debug.LogError("The number of choices has been manipulated to a number not supported.");
                    break;
            }
            index++;
        }
    }
}
