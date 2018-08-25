using DigitalRuby.SoundManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class digiCode : MonoBehaviour {

    public bool isLastDigicode;

    public GameObject[] keyButtons;
    public int enabledAmmount;
    public float keycode;

    public Material redMat;
    public Material greenMat;
    public Material originMat;

    bool code1Used = false;

    public ExePuzzle ep;

	private Animator levierAnim;


    void Start()
    {
		levierAnim = MissionManager.instance.levier;

        enabledAmmount = 0;

		keycode = 0;
    }


    void Update()
    {
        if (!isLastDigicode)
        {
            MissionManager.instance.digiTxt.text = "" + keycode;

            if (keycode == 0)
            {
                enabledAmmount = 0;
                MissionManager.instance.digiTxt.text = "";
            }
            else MissionManager.instance.digiTxt.text = "" + keycode;
        }
    }

    public void validateInput()
    {
        if (MissionManager.instance.inExePuzzle)
        {
            if (keycode == 95 && ep.stepID == 1)
            {
                ep.nextStep = true;
                StartCoroutine(lightFlashKeys(greenMat, true));
            }
            else if (keycode == 18 && ep.stepID == 2)
            {
                ep.nextStep = true;
                StartCoroutine(lightFlashKeys(greenMat, true));
            }
            else if (keycode == 19 && ep.stepID == 3)
            {
                ep.nextStep = true;
                StartCoroutine(lightFlashKeys(greenMat, true));
            }
            else if (keycode == 260 && ep.stepID == 4)
            {
                ep.nextStep = true;
                StartCoroutine(lightFlashKeys(greenMat, true));
            }
            else if (keycode == 270 && ep.stepID == 5)
            {
                ep.nextStep = true;
                StartCoroutine(lightFlashKeys(greenMat, true));
            }
            else if (keycode == 280 && ep.stepID == 6)
            {
                ep.nextStep = true;
                StartCoroutine(lightFlashKeys(greenMat, true));
            }
            else if (keycode == 450 && ep.stepID == 7)
            {
                ep.nextStep = true;
                StartCoroutine(lightFlashKeys(greenMat, true));
            }
            else if (keycode == 860 && ep.stepID == 8)
            {
                ep.nextStep = true;
                StartCoroutine(lightFlashKeys(greenMat, true));
            }
            else if (keycode == 870 && ep.stepID == 9)
            {
                ep.nextStep = true;
                StartCoroutine(lightFlashKeys(greenMat, true));
            }
            else if (keycode == 850 && ep.stepID == 10)
            {
                ep.nextStep = true;
                StartCoroutine(lightFlashKeys(greenMat, true));
            }
            else if (keycode == 461 && ep.stepID == 11)
            {
                ep.nextStep = true;
                StartCoroutine(lightFlashKeys(greenMat, true));
            }

            else
            {
                ep.StopPuzzle();
            }
        }
        else
        {
            if (keyPadValidation(keycode))
            {
                foreach (GameObject btn in keyButtons)
                {
                    btn.GetComponent<digicodeBtn>().clicked = false;
                }
            }
            else
            {
                foreach (GameObject btn in keyButtons)
                {
                    btn.GetComponent<digicodeBtn>().clicked = false;
                }
                StartCoroutine(flashKeys(redMat, true));
            }
        }
    }

    public bool keyPadValidation(float keyCode)
    { 
        if (keycode == 5213 && MissionManager.instance.inLastPuzzle)
        {
            MissionManager.instance.digiFinishPuzzle = true;

            MissionManager.instance.inLastPuzzle = false;

			foreach (GameObject btn in keyButtons)
			{
				btn.GetComponent<Renderer>().material = greenMat;
			}

            return true;
        }
		else if (keycode == 1211 && MissionManager.instance.hideDigicode && MissionManager.instance.searchJack)
		{
			MissionManager.instance.digiFinishPuzzle = true;
			MissionManager.instance.searchJack = false;

			foreach (GameObject btn in keyButtons)
			{
                btn.GetComponent<Renderer>().material = greenMat;
			}

			return true;
		}
        else if (isLastDigicode && keycode == 6444)
        {
            GameManager.instance.flashKeypad = true;

            foreach (GameObject btn in keyButtons)
            {
                btn.GetComponent<Renderer>().material = greenMat;
            }
            AudioManager.instance.PlaySound("digiOkSound");
            return true;
        }
        else 
		{
            AudioManager.instance.PlaySound("digiError");
            return false;
        }
    }

    public void resetKeypad()
    {
        foreach (GameObject btn in keyButtons)
        {
            if (btn.GetComponent<digicodeBtn>().clicked)
            {
                btn.GetComponent<digicodeBtn>().clicked = false;
                btn.GetComponent<Renderer>().material = originMat;
            }
        }
        enabledAmmount = 0;
        keycode = 0;
    }

    public IEnumerator flashKeys(Material col, bool flash)
    {
        resetKeypad();
        if (flash)
        {
            foreach (GameObject btn in keyButtons)
            {
                btn.GetComponent<Renderer>().material = col;
            }
            yield return new WaitForSeconds(0.2f);
            foreach (GameObject btn in keyButtons)
            {
                btn.GetComponent<Renderer>().material = originMat;
            }
            yield return new WaitForSeconds(0.2f);
            foreach (GameObject btn in keyButtons)
            {
                btn.GetComponent<Renderer>().material = col;
            }
            yield return new WaitForSeconds(0.2f);
            foreach (GameObject btn in keyButtons)
            {
                btn.GetComponent<Renderer>().material = originMat;
            }
            yield return new WaitForSeconds(0.2f);
            foreach (GameObject btn in keyButtons)
            {
                btn.GetComponent<Renderer>().material = col;
            }
            yield return new WaitForSeconds(0.2f);
            foreach (GameObject btn in keyButtons)
            {
                btn.GetComponent<Renderer>().material = originMat;
            }
        }
        foreach (GameObject btn in keyButtons)
        {
            btn.GetComponent<Renderer>().material = originMat;
        }
        
        yield return null;
    }

    public IEnumerator lightFlashKeys(Material col, bool flash)
    {
        resetKeypad();
        if (flash)
        {
            foreach (GameObject btn in keyButtons)
            {
                btn.GetComponent<Renderer>().material = col;
            }
            yield return new WaitForSeconds(0.2f);
            foreach (GameObject btn in keyButtons)
            {
                btn.GetComponent<Renderer>().material = originMat;
            }
        }
        foreach (GameObject btn in keyButtons)
        {
            btn.GetComponent<Renderer>().material = originMat;
        }

        yield return null;
    }
}
