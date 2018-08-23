using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SoundManagerNamespace;


public class Alarm : MonoBehaviour
{
    public Animator alarmAnim;

    public void TurnOnAlarm() //CALL ON ELECTRIC PANNEL GOOD
    {
        alarmAnim.SetBool("turnOn", true);
    }

    public void DoAlarm() //CALL ON BUTTON
    {
        alarmAnim.SetBool("doAlarm", true);
        AudioManager.instance.PlaySound("lockerButton");
    }
}
