﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SoundManagerNamespace;


public class Alarm : MonoBehaviour
{
    public Animator alarmAnim;

    public Megaphone megaphone;
    public Radio radio;

    public GameObject alarmSound;

    private Collider col;

    public void TurnOnAlarm() //CALL ON ELECTRIC PANNEL GOOD
    {
        alarmAnim.SetBool("turnOn", true);
        col = GetComponent<Collider>();
    }

    public void DoAlarm() //CALL ON BUTTON
    {
        alarmAnim.SetBool("doAlarm", true);
        AudioManager.instance.PlaySound("lockerButton");

        col.enabled = false;

        megaphone.TurnOffMegaphone();
        radio.TurnOffRadio();

        AudioManager.instance.StopMusic();

        ScreenshakeManager.instance.DoAlarmShake();
        FindObjectOfType<DialogSystem>().EndDialogue();

        alarmSound.SetActive(true);

        EndingManager.instance.StartKreepEnding(); //START ENDING
    }
}
