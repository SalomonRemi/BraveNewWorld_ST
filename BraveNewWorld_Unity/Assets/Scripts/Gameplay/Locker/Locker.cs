using DigitalRuby.SoundManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour {

	public List<GameObject> lockerNum;

    public Animator objectAnim;
    public Animator secondObjectAnim;

    [HideInInspector] public bool codeOk;

    private bool feedbackDone;

    private bool findCode1;
    private bool findCode2;


    private void Update()
    {
        if(!findCode1)
        {
            CheckIfGoodCode();
        }

        if(!findCode2)
        {
            CheckIfGoodCode2();
        }
    }


    private void CheckIfGoodCode() //vent
    {
        int validateNumber = 0;

        for (int i = 0; i < lockerNum.Count; i++)
        {
            LockerNum ln = lockerNum[i].GetComponent<LockerNum>();
            if (ln.isGoodNumber) validateNumber++;
        }

        if(validateNumber == lockerNum.Count)
        {
            codeOk = true;

            if(!feedbackDone) StartCoroutine(Feedback(objectAnim, "ventsOpen", true));

            findCode1 = true;
        }
    }

    private void CheckIfGoodCode2()
    {
        int validateNumber = 0;

        for (int i = 0; i < lockerNum.Count; i++)
        {
            LockerNum ln = lockerNum[i].GetComponent<LockerNum>();
            if (ln.isGoodNumber2) validateNumber++;
        }

        if (validateNumber == lockerNum.Count)
        {
            codeOk = true;

            if (!feedbackDone) StartCoroutine(Feedback(secondObjectAnim, "lockerGood", false));

            findCode2 = true;
        }
    }

    public IEnumerator Feedback(Animator anim, string soundName, bool doDialogs)
    {
        anim.SetBool("open", true);
        AudioManager.instance.PlaySound(soundName);

        if(!MissionManager.instance.isInLastPuzzle && doDialogs) // && isVents
        {
            AudioManager.instance.StopMusic();
            AudioManager.instance.PlayMusic("escapeWarn02");

            Dialogue dialogue1 = new Dialogue();
            dialogue1.sentences.Add("Bon sang Wilson laissez la ventilation ! Vous ne voudirez pas finir en salle de tri ?!");
            FindObjectOfType<DialogSystem>().StartDialogue(dialogue1);
        }

        //if (isOscarLocker && !MissionManager.instance.isInLastPuzzle)
        //{
        //    AudioManager.instance.StopMusic();
        //    AudioManager.instance.PlayMusic("escapeWarn01");

        //    Dialogue dialogue = new Dialogue();
        //    dialogue.sentences.Add("Qu'est ce que vous faites ?! Je vous ai dit de ne pas toucher aux affaires d'Oscar. Laissez ce casier et reprenez le travail.");
        //    FindObjectOfType<DialogSystem>().StartDialogue(dialogue);
        //}

        yield return null;

        //feedbackDone = true;
    }
}