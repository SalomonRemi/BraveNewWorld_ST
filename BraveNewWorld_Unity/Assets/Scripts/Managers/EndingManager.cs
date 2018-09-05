using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SoundManagerNamespace;

public class EndingManager : MonoBehaviour {

    public static EndingManager instance = null;

    public Animator hiddenRoomDoorAnim;

    private bool goToNextStep;
    [HideInInspector] public bool endDialogTrigger;

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
    }

    public void StartCorporateEnding()
    {
        StartCoroutine(CorpoEnding());
    }


    IEnumerator KreepEnding()
    {
        hiddenRoomDoorAnim.SetBool("kreep", true);
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
        dialogue1.sentences.Add("This is the end, the society will collapse because YOU CHOOSE KREEP HAHA!");
        FindObjectOfType<DialogSystem>().StartDialogue(dialogue1);

        //AudioManager.instance.PlayMusic("outroKreepDialog01");

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
        dialogue1.sentences.Add("Thanks you mate we killed Kreep, he was in 'the sink'. The center thanks you very much.");
        FindObjectOfType<DialogSystem>().StartDialogue(dialogue1);

        //AudioManager.instance.PlayMusic("outroCorpoDialog01");

        yield return null;
    }
}
