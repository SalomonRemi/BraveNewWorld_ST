﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SoundManagerNamespace;


public class Radio : MonoBehaviour {

    public string startRadioName;
    public string cutRadioName;

    public GameObject node;

    public Animator radioAnim;

    private MeshRenderer nodeMr;

    [HideInInspector] public bool isActivated;


    private void Start()
    {
        nodeMr = node.GetComponent<MeshRenderer>();
    }


    public void TurnOnRadio() //CALL ON ELECTRIC PANNEL GOOD
    {
        nodeMr.material.color = Color.red;
        isActivated = false;
        radioAnim.SetBool("turnOn", true);
    }


    public void StartRadio() //CALL ON BUTTON PRESS ON
    {
        AudioManager.instance.PlaySound("lockerButton");
        nodeMr.material.color = Color.green;
        isActivated = true;

        StartCoroutine(RadioMessage());
    }

    public void CutRadio() //CALL ON BUTTON PRESS OFF
    {
        nodeMr.material.color = Color.red;
        isActivated = false;
        AudioManager.instance.PlaySound("lockerButton");
        AudioManager.instance.StopMusic();
        FindObjectOfType<DialogSystem>().EndDialogue();
        StopAllCoroutines();
    }

    IEnumerator RadioMessage()
    {
        Dialogue dialogue1 = new Dialogue();
        dialogue1.sentences.Add("Kreep message where he's saying stuff about revolution");
        FindObjectOfType<DialogSystem>().StartDialogue(dialogue1);

        //SON DIALOGUE

        yield return new WaitForSeconds(10f);

        StartCoroutine(RadioMessage());
    }
}
