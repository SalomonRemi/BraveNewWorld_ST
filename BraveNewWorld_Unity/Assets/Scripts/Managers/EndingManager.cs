using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SoundManagerNamespace;

public class EndingManager : MonoBehaviour {

    public static EndingManager instance = null;
    public Animator hiddenRoomDoorAnim;
    public Animator finalLiftDoors;
    public Radio radio;
    public Megaphone mega;

    public GameObject redLightHolder;
    public GameObject whiteLightHolder;

    private bool goToNextStep;
    [HideInInspector] public bool endDialogTrigger;
    [HideInInspector] public bool liftDialogTrigger;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    public void StartKreepEnding()
    {
        StartCoroutine(KreepEnding());

        radio.CutRadio();
        radio.TurnOffRadio();
        mega.CutMegaphone();
        mega.TurnOffMegaphone();

        TurnLightRed();
    }

    public void StartCorporateEnding()
    {
        StartCoroutine(CorpoEnding());

        radio.CutRadio();
        radio.TurnOffRadio();
        mega.CutMegaphone();
        mega.TurnOffMegaphone();

        TurnLightWhite();
    }


    IEnumerator KreepEnding()
    {
        hiddenRoomDoorAnim.SetBool("kreep", true);
        AudioManager.instance.PlaySound("finalDoorOpen");

        yield return new WaitForSeconds(3f);

        Dialogue dialogue1 = new Dialogue();
        dialogue1.sentences.Add("À tous les employés du CICL, je vous prie de garder votre calme. Vous avez sûrement déjà tous entendu mon nom, Kreep.");
        dialogue1.sentences.Add("Aujourd’hui je vous offre la liberté, vous n’avez qu’à aller la saisir !");
        dialogue1.sentences.Add("Plus personne ne vous fermera les portes, dirigez-vous comme un seul homme jusqu’aux bureaux des Alphas et prenez le !");
        dialogue1.sentences.Add("De ces mêmes bureaux nous déclencherons les renversements dans tous les centres du monde.");
        dialogue1.sentences.Add(" Soyez les acteurs du crépuscule de ce monde, nous allons en bâtir un nouveau, ensemble.");

        FindObjectOfType<DialogSystem>().StartDialogue(dialogue1);

        //AudioManager.instance.PlayMusic("outroKreepDialog01");

        while (!goToNextStep)
        {
            if (liftDialogTrigger)
            {
                goToNextStep = true;
            }
            yield return null;
        }

        Dialogue dialogue2 = new Dialogue();
        dialogue2.sentences.Add("Bonjour Wilson. J’espère que vous allez bien. Nous ne nous connaissons pas mais c’est aujourd’hui grâce à vous que le rêve se réalise.");
        dialogue2.sentences.Add("Vous avez fait le bon choix.Vous n’aimiez pas votre responsable n’est-ce pas ? ");
        dialogue2.sentences.Add("Sachez qu’il n’est déjà plus de ce monde. Vous êtes libre Wilson, félicitations.");

        FindObjectOfType<DialogSystem>().StartDialogue(dialogue2);

        yield return new WaitForSeconds(1f);

        finalLiftDoors.SetBool("doClose", true);

        //AudioManager.instance.PlayMusic("outroKreepDialog02");

        yield return null;
    }

    IEnumerator CorpoEnding()
    {
        hiddenRoomDoorAnim.SetBool("corpo", true);
        AudioManager.instance.PlaySound("finalDoorOpen");

        while (!goToNextStep)
        {
            if (endDialogTrigger)
            {
                goToNextStep = true;
            }
            yield return null;
        }

        Dialogue dialogue1 = new Dialogue();
        dialogue1.sentences.Add("Un peu d’air ça fait du bien n’est-ce pas ? C’est que ça devait commencer à sentir là-dedans !");
        dialogue1.sentences.Add("Kreep et moi-même vous remercions pour votre service, vous n’avez pas idée de l’aide précieuse que vous nous avez fourni !");
        dialogue1.sentences.Add("Avancez jusqu’au bout du couloir et prenez l’ascenceur, je vous attendrai au 5ème étage nous avons à discuter.");
        dialogue1.sentences.Add("Je vous laisse je dois régler 'quelque chose', à tout à l’heure !");

        while (goToNextStep)
        {
            if (liftDialogTrigger)
            {
                goToNextStep = false;
            }
            yield return null;
        }

        finalLiftDoors.SetBool("doClose", true);
        FindObjectOfType<DialogSystem>().StartDialogue(dialogue1);

        //AudioManager.instance.PlayMusic("outroCorpoDialog01");

        yield return null;
    }

    public void TurnLightRed()
    {
        redLightHolder.SetActive(true);
    }

    public void TurnLightWhite()
    {
        whiteLightHolder.SetActive(true);
    }
}
