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

    private MeshRenderer nodeMr;

    private int angryCounter;

    [HideInInspector] public bool isActivated;


    private void Start()
    {
        nodeMr = node.GetComponent<MeshRenderer>();
    }


    public void TurnOnMegaphone() //CALL ON ELECTRIC PANNEL GOOD
    {
        nodeMr.material.color = Color.red;
        isActivated = false;
        megaphoneAnim.SetBool("turnOn", true);
    }


    public void StartMegaphone() //CALL ON BUTTON PRESS ON
    {
        AudioManager.instance.PlaySound("lockerButton");
        nodeMr.material.color = Color.green;
        isActivated = true;

        StartCoroutine(MegaMessage());
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
    }

    IEnumerator MegaMessage()
    {
        Dialogue dialogue1 = new Dialogue();

        if(angryCounter == 0) dialogue1.sentences.Add("Hello this is nice place !");
        else if (angryCounter == 1) dialogue1.sentences.Add("Wow bad network hey stay focus ! So ...");
        else if (angryCounter == 2) dialogue1.sentences.Add("What the fuck dude, come on stop it. I was saying ...");
        else if (angryCounter == 3) dialogue1.sentences.Add("This is the last fucking time...");

        dialogue1.sentences.Add("This is the boss message, I am angry grrrr come on find the goddam code.");
        FindObjectOfType<DialogSystem>().StartDialogue(dialogue1);

        //SON DIALOGUE

        yield return new WaitForSeconds(10f);

        yield return null;
    }
}