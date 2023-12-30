using TMPro;
using UnityEngine;
using Ink.Runtime;
using Scripts.PlayerInput;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private Story currentStory;
    private bool dialogueIsPlaying = false;


    private void Awake(){
        if( instance != null){
            Debug.LogWarning("Found more than one DIalogue Manager in the scene");
        }
        instance = this;
    }

    private void Start(){
        dialoguePanel.SetActive(false);
        InputManager.SubmitDialogue += OnSubmitDialoguePerformed;
    }

    private void OnSubmitDialoguePerformed(){
        ContinueStory();
    }

    public static DialogueManager GetInstance(){
        return instance;
    }

    private void ContinueStory(){
        if (currentStory.canContinue){
            dialogueText.text = currentStory.Continue();
        } else {
            ExitDialogueMode();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON){
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }
}
