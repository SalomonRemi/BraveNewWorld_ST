using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SoundManagerNamespace;


public class Megaphone : MonoBehaviour
{
    public Animator megaphoneAnim;
    public Animator speakerAnim;
    public Animator buttonAnim;

    public float cooldownTime;

    private Collider col;

    private int angryCounter;

    [HideInInspector] public bool isActivated;


    private void Start()
    {
        col = GetComponent<Collider>();
    }


    public void TurnOnMegaphone() //CALL ON ELECTRIC PANNEL GOOD
    {
        isActivated = false;
        megaphoneAnim.SetBool("turnOn", true);
        col.enabled = true;
    }

    public void TurnOffMegaphone() //CALL ON ALARM
    {
        isActivated = false;
        col.enabled = false;
    }


    public void StartMegaphone() //CALL ON BUTTON PRESS ON
    {
        AudioManager.instance.PlaySound("lockerButton");
        isActivated = true;

        StartCoroutine(MegaMessage());
        StartCoroutine(ClickCooldown());

        speakerAnim.SetBool("SetOn", true);
        buttonAnim.SetBool("SetOn", true);
    }

    public void CutMegaphone() //CALL ON BUTTON PRESS OFF
    {
        StopAllCoroutines();

        isActivated = false;
        angryCounter++;

        AudioManager.instance.PlaySound("lockerButton");
        AudioManager.instance.StopMusic();

        FindObjectOfType<DialogSystem>().EndDialogue(); //BUG HERE

        StartCoroutine(ClickCooldown());
        speakerAnim.SetBool("SetOn", false);
        buttonAnim.SetBool("SetOn", false);
    }

    IEnumerator MegaMessage()
    {
        Dialogue dialogue1 = new Dialogue();

        if (angryCounter == 0)
        {
            dialogue1.sentences.Add("Tiens tu es là ? Eh bien on dirait que tu as trouvé Oscar ! Bien joué !");
            dialogue1.sentences.Add("Dis moi maintenant que tu es là tu ne voudrais pas jeter un oeil dans la pièce ?");
            dialogue1.sentences.Add("Tu nous rendrais un grand service si tu trouvais l’identifiant de Kreep, c’est un ancien collègue qui a perdu sa fiche d’identité, j’aimerais la lui signaler !");

            AudioManager.instance.PlaySound("coropoDialog01");
        }
        else if (angryCounter == 1)
        {
            dialogue1.sentences.Add("*Erm* Ces vieux mégaphones ne sont pas fiables, faites vite Wilson, trouvez l’identifiant de mon ami Kreep, l’usine vous en sera reconnaissante.");
            AudioManager.instance.PlaySound("coropoDialog02");
        }
        else if (angryCounter == 2)
        {
            dialogue1.sentences.Add("Ca n’arrête pas de couper, je vais commencer à croire que vous le faites exprès ! Transmettez-nous l’identifiant de Kreep ou nous viendrons le faire à votre place.");
            AudioManager.instance.PlaySound("coropoDialog03");
        }
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