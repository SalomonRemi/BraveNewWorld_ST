﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
[SerializeField]
public class DialogSystem : MonoBehaviour {

	public Queue<string> sentences = new Queue<string> ();
	//public TextMeshProUGUI dialogueText;
	public Text dialogueText;

	void Start ()
    {
		dialogueText.text = "";
		sentences = new Queue<string> ();
	}


	public void StartDialogue(Dialogue dialogue) // APPELÉ DANS MISSION MANAGER, DEMARRE UN DIALOGUE
    {
        GameManager.instance.canLOS = false; // DESACTIVE DIALOGUE DYNAMIQUE
		if (sentences.Count != 0)
        {
			sentences.Clear ();
		}
		foreach (string sentence in dialogue.sentences) // RAJOUTE A LA QUEUE LES DIALOGUES ENVOYER A LA METHODE
        {
			sentences.Enqueue (sentence);
		}
		DisplayNextSentence ();
	}

	void DisplayNextSentence()
    {
		if (sentences.Count == 0) // MET FIN AU DIALOGUE SI IL NY A PLUS DE SENTENCES
        {
			EndDialogue();
			return;
		}
		string sentence = sentences.Dequeue (); // RETURN LA SENTENCE AU DEBUT DE QUEUE, ET LA SUPPRIME

		StopAllCoroutines ();
		StartCoroutine (dialogueType (sentence)); // DEMMARE ANIM DE TYPING
	}

	void EndDialogue()
    {
		dialogueText.text = "";
        GameManager.instance.canLOS = true; // ACTIVE DIALOGUE DYNAMIQUE
        MissionManager.instance.canStartExePuzzle = true; // LANCE EXE PUZZLE A LA FIN DE LA CONVERSATION SI EXE PUZZLE IL Y A
    }

	IEnumerator dialogueType(string sentence)
    {
        dialogueText.text = "";

        yield return new WaitForSeconds(.5f);

        float waitingTime = 0;
        dialogueText.text = sentence;

        foreach(char letter in sentence) // EN FONCTION DU NOMBRE DE CHAR IN SETENCES AUGMENTER LE TEMPS DE WAIT
        {
            waitingTime += 0.05f;
        }
        yield return new WaitForSeconds(waitingTime);

		DisplayNextSentence ();
	}
}