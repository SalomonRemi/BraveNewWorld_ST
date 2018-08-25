using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SoundManagerNamespace;


public class Megaphone : MonoBehaviour
{

    public string startMegaphoneName;
    public string cutMegaphoneName;

    public GameObject node;

    public Animator megaphoneAnim;

    public float cooldownTime;

    private MeshRenderer nodeMr;
    private Collider col;

    private int angryCounter;

    [HideInInspector] public bool isActivated;


    private void Start()
    {
        nodeMr = node.GetComponent<MeshRenderer>();
        col = GetComponent<Collider>();
    }


    public void TurnOnMegaphone() //CALL ON ELECTRIC PANNEL GOOD
    {
        nodeMr.material.color = Color.red;
        isActivated = false;
        megaphoneAnim.SetBool("turnOn", true);
        col.enabled = true;
    }

    public void TurnOffMegaphone() //CALL ON ALARM
    {
        nodeMr.material.color = Color.red;
        isActivated = false;
        col.enabled = false;
    }


    public void StartMegaphone() //CALL ON BUTTON PRESS ON
    {
        AudioManager.instance.PlaySound("lockerButton");
        nodeMr.material.color = Color.green;
        isActivated = true;

        StartCoroutine(MegaMessage());
        StartCoroutine(ClickCooldown());
    }

    public void CutMegaphone() //CALL ON BUTTON PRESS OFF
    {
        StopAllCoroutines();

        nodeMr.material.color = Color.red;
        isActivated = false;
        angryCounter++;

        AudioManager.instance.PlaySound("lockerButton");
        AudioManager.instance.StopMusic();

        FindObjectOfType<DialogSystem>().EndDialogue();

        StartCoroutine(ClickCooldown());
    }

    IEnumerator MegaMessage()
    {
        Dialogue dialogue1 = new Dialogue();

        if(angryCounter == 0) dialogue1.sentences.Add("This is the first time I speak, please kill kreep with Digicode !");
        else if (angryCounter == 1) dialogue1.sentences.Add("Wow bad network hey stay focus ! Kill kreep with Digicode !");
        else if (angryCounter == 2) dialogue1.sentences.Add("What the fuck dude, I can't ear you. You need to kill kreep the son of shmeh");
        else if (angryCounter == 3) dialogue1.sentences.Add("This is the last fucking time... I'am crazy you bloody kreep I want him to die !");
        FindObjectOfType<DialogSystem>().StartDialogue(dialogue1);

        //SON DIALOGUE

        yield return new WaitForSeconds(10f);

        CutMegaphone();

        yield return null;
    }

    IEnumerator ClickCooldown()
    {
        col.enabled = false;

        yield return new WaitForSeconds(cooldownTime);

        col.enabled = true;

        yield return null;
    }
}