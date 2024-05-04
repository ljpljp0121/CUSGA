using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueSystem : MonoBehaviour
{
    public bool isTriggerd;
    public GameObject dialogueAll;
    public int mouceCount;
    public Text dialogueBox;

    public List<string> DialogueText;

    public bool isTalkOver = false;
    void Start()
    {
        mouceCount = 0;
    }

    private void Update()
    {
        if (!isTriggerd)
            return;


        if (Input.GetKeyDown(KeyCode.Mouse0)|| Input.GetKeyDown(KeyCode.E))
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
        Talk();
    }

    public void Talk()
    {
        if (!isTriggerd)
        {
            Player.instance.canMove = false;
            isTriggerd = true;
            dialogueAll.SetActive(true);
        }
    }
}
