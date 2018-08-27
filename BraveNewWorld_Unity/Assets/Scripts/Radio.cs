using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SoundManagerNamespace;


public class Radio : MonoBehaviour {
   
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
        //AudioManager.instance.PlaySound("radioOn");
        AudioManager.instance.PlaySound("lockerButton");

        nodeMr.material.color = Color.green;
        isActivated = true;

        StartCoroutine(RadioMessage());
    }

    public void CutRadio() //CALL ON BUTTON PRESS OFF
    {
        nodeMr.material.color = Color.red;
        isActivated = false;

        //AudioManager.instance.PlaySound("radioOff");
        AudioManager.instance.PlaySound("lockerButton");
        AudioManager.instance.StopMusic();
        FindObjectOfType<DialogSystem>().EndDialogue(); //BUG HERE

        StopAllCoroutines();
    }

    IEnumerator RadioMessage()
    {
        Dialogue dialogue1 = new Dialogue();
        dialogue1.sentences.Add("10 Décembre 630. Kreep. Kreep. Cet enregistrement est le dernier du plan, la dernière marche à franchir avant de changer le monde.");
        dialogue1.sentences.Add("Le code de la mallette que je vous ai confié correspond à l’année à laquelle nous nous sommes rencontrés.");
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
