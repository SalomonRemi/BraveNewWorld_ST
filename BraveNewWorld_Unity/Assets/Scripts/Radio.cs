using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SoundManagerNamespace;


public class Radio : MonoBehaviour {
   
    public Animator radioAnim;
    public Animator tapeAnim;
    public GameObject radioSound;

    private Animator buttonAnim;

    public float cooldownTime;


    private Collider col;

    [HideInInspector] public bool isActivated;


    private void Start()
    {
        col = GetComponent<Collider>();
        buttonAnim = GetComponent<Animator>();
        tapeAnim.speed = 0f;
    }


    public void TurnOnRadio() //CALL ON ELECTRIC PANNEL GOOD
    {
        isActivated = false;
        radioAnim.SetBool("turnOn", true);
        col.enabled = true;
    }

    public void TurnOffRadio() //CALL ON ALARM
    {
        isActivated = false;
        col.enabled = false;
        tapeAnim.speed = 0f;
    }


    public void StartRadio() //CALL ON BUTTON PRESS ON
    {
        //AudioManager.instance.PlaySound("radioOn");
        AudioManager.instance.PlaySound("lockerButton");

        buttonAnim.SetBool("SetOn", true);
        isActivated = true;

        StartCoroutine(RadioMessage());
        tapeAnim.speed = 1f;

        //radioSound.SetActive(true);
    }

    public void CutRadio() //CALL ON BUTTON PRESS OFF
    {
        isActivated = false;

        //AudioManager.instance.PlaySound("radioOff");
        AudioManager.instance.PlaySound("lockerButton");
        AudioManager.instance.StopMusic();
        FindObjectOfType<DialogSystem>().EndDialogue(); 

        buttonAnim.SetBool("SetOn", false);
        StopAllCoroutines();
        tapeAnim.speed = 0f;
        //radioSound.SetActive(false);
    }

    IEnumerator RadioMessage()
    {
        Dialogue dialogue1 = new Dialogue();
        dialogue1.sentences.Add("Kreep. Kreep. Cet enregistrement est le dernier du plan, la dernière marche à franchir avant de changer le monde.");
        dialogue1.sentences.Add("Le code de la mallette que je vous ai confié correspond à l’année à laquelle nous nous sommes rencontrés. N’ayez plus peur.");
        FindObjectOfType<DialogSystem>().StartDialogue(dialogue1);

        //SON DIALOGUE

        yield return new WaitForSeconds(12f);

        yield return null;

        StartCoroutine(RadioMessage());
    }

    IEnumerator ClickCooldown()
    {
        col.enabled = false;

        yield return new WaitForSeconds(cooldownTime);

        col.enabled = true;
        yield return null;
    }
}