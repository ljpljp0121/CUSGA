using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueSystem : MonoBehaviour
{
    private bool isTriggerd;
    public GameObject dialogueAll;
    private int mouceCount;
    public Text dialogueBox;


    [SerializeField] private List<string> DialogueText;


    private bool isTalkOver = false;
    void Start()
    {
        isTriggerd = false;

        mouceCount = 0;
    }

    private void Update()
    {

        if (!isTriggerd)
            return;


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            mouceCount++;
            if (mouceCount < DialogueText.Count)
            {
                dialogueBox.text = DialogueText[mouceCount];

            }
            else
            {
                if (!isTalkOver)
                {
                    isTalkOver = true;
                    OnDialogueEnd();
                }
            }
        }
        ShowDialogue();
    }

    void ShowDialogue()
    {
        if (mouceCount >= DialogueText.Count)
            return;

        dialogueBox.text = DialogueText[mouceCount];
    }

    void OnDialogueEnd()
    {
        dialogueAll.SetActive(false);
        Player.instance.canMove = true;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!isTriggerd)
        {
            isTriggerd = true;
            dialogueAll.SetActive(true);
            Player.instance.canMove = false;
        }
    }
}
