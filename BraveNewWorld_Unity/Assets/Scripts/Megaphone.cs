using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SoundManagerNamespace;


public class Megaphone : MonoBehaviour
{

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

        FindObjectOfType<DialogSystem>().EndDialogue(); //BUG HERE

        StartCoroutine(ClickCooldown());
    }

    IEnumerator MegaMessage()
    {
        Dialogue dialogue1 = new Dialogue();

        if (angryCounter == 0)
        {
            dialogue1.sentences.Add("Tiens tu es là ? Cette salle est inutilisée depuis longtemps… Laisse moi le temps de retrouver les caméras… Ah parfait !");
            dialogue1.sentences.Add("Mais qu’est-ce que… Oscar ? C’est lui sur le sol ? Cette saloperie de groupe révolutionnaire aura fini par le tuer, on dirait qu’on a bien fait de le remplacer !");
            dialogue1.sentences.Add("Nous sommes en train de fouiller ses affaires dans votre bureau, il semblerait qu’il ait été manipulé par Kreep, le leader de ce groupe extrémiste.");
            dialogue1.sentences.Add("Nous savons qu’Oscar était le garant de son identité. Wilson, rendez-nous service, trouvez l’identifiant de Kreep et transmettez le moi.”");
        }
        else if (angryCounter == 1)
        {
            dialogue1.sentences.Add("Erm, ces vieux mégaphones ne sont pas fiables, faites vite Wilson, trouvez l’identifiant du terroriste Kreep, nous saurons vous récompenser !");
        }
        else if (angryCounter == 2)
        {
            dialogue1.sentences.Add("Ca n’arrête pas de couper, je vais commencer à croire que vous le faites exprès ! Transmettez-nous l’identifiant de Kreep ou nous viendrons le faire à votre place.");
        }
        //else if (angryCounter == 3)
        //{
        //    dialogue1.sentences.Add("This is the last fucking time... I'am crazy you bloody kreep I want him to die !");
        //}
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