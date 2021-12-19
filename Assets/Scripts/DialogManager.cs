using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text dialogText;

    public GameObject StartTalking;
    public GameObject DialogWindow;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialog(Dialog dialog)
    {
        sentences.Clear();

        foreach(string sentence in dialog.sentences)
        {
           sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialog();
            return;
        }
        string sentence = sentences.Dequeue();
        StartCoroutine(TypeText(sentence));
    }

    IEnumerator TypeText(string sentence)
    {
        dialogText.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
        }

    }

    private void EndDialog()
    {
        DialogWindow.SetActive(false);
        StartTalking.SetActive(false);
    }
}
