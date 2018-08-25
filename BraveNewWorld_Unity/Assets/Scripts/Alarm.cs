using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SoundManagerNamespace;


public class Alarm : MonoBehaviour
{
    public Animator alarmAnim;

    public Megaphone megaphone;
    public Radio radio;

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
        //AudioManager.instance.PlayMusic("");

        ScreenshakeManager.instance.DoAlarmShake();
        FindObjectOfType<DialogSystem>().EndDialogue();
    }
}
