using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SoundManagerNamespace;


public class Radio : MonoBehaviour {

    public string startRadioName;
    public string cutRadioName;

    public GameObject node;

    public Animator radioAnim;

    public float cooldownTime;

    private MeshRenderer nodeMr;
    private Collider col;

    [HideInInspector] public bool isActivated;


    private void Start()
    {
        nodeMr = node.GetComponent<MeshRenderer>();
        col = GetComponent<Collider>();
    }


    public void TurnOnRadio() //CALL ON ELECTRIC PANNEL GOOD
    {
        nodeMr.material.color = Color.red;
        isActivated = false;
        radioAnim.SetBool("turnOn", true);
        col.enabled = true;
    }

    public void TurnOffRadio() //CALL ON ALARM
    {
        nodeMr.material.color = Color.red;
        isActivated = false;
        col.enabled = false;
    }


    public void StartRadio() //CALL ON BUTTON PRESS ON
    {
        AudioManager.instance.PlaySound("lockerButton");
        AudioManager.instance.PlaySound(startRadioName);

        nodeMr.material.color = Color.green;
        isActivated = true;

        StartCoroutine(RadioMessage());
    }

    public void CutRadio() //CALL ON BUTTON PRESS OFF
    {
        StopAllCoroutines();

        nodeMr.material.color = Color.red;
        isActivated = false;
        AudioManager.instance.PlaySound(cutRadioName);

        AudioManager.instance.PlaySound("lockerButton");
        AudioManager.instance.StopMusic();
        FindObjectOfType<DialogSystem>().EndDialogue();
    }

    IEnumerator RadioMessage()
    {
        Dialogue dialogue1 = new Dialogue();
        dialogue1.sentences.Add("Kreep message where he's saying stuff about revolution");
        FindObjectOfType<DialogSystem>().StartDialogue(dialogue1);

        //SON DIALOGUE

        yield return new WaitForSeconds(10f);

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
