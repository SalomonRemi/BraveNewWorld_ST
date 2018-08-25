using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SoundManagerNamespace;

public class PuzzleSlider : MonoBehaviour {

    public int sliderValue;
    public bool isActivated;

    public bool isValidate;

    [HideInInspector] public int realSliderValue;

    private MeshRenderer mr;

    public Material greenMat;
    public Material originMat;

    [HideInInspector] public Material currentMatColor;

    private Animator anim;

	void Start ()
    {
        realSliderValue = 1;
        mr = GetComponent<MeshRenderer>();
        anim = GetComponent<Animator>();

        currentMatColor = originMat;
	}

    public void SliderInteraction()
    {
        if (isActivated) isActivated = false;
        else isActivated = true;

        if(isActivated)
        {
            mr.material = greenMat;
            currentMatColor = greenMat;
            anim.SetBool("Activated", true);
            realSliderValue = sliderValue;
            AudioManager.instance.PlaySound("openDesks");
        }
        else
        {
            mr.material = originMat;
            currentMatColor = originMat;
            anim.SetBool("Activated", false);
            realSliderValue = 1;
            AudioManager.instance.PlaySound("closeDesks");
        }
    }

    public void ValidateNumber()
    {
        ElectricPuzzle.instance.Validate();
        AudioManager.instance.PlaySound("lockerButton");
    }
}
