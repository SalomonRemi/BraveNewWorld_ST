using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SoundManagerNamespace;

public class PuzzleSlider : MonoBehaviour {

    public int sliderValue;
    public bool isActivated;

    public GameObject nodeLight;

    [HideInInspector] public int realSliderValue;

    private MeshRenderer mr;
    private Animator anim;

	void Start ()
    {
        realSliderValue = 1;
        mr = nodeLight.GetComponent<MeshRenderer>();
        anim = GetComponent<Animator>();
	}

    public void SliderInteraction()
    {
        //AudioManager.instance.PlaySound("lockerButton");

        if (isActivated) isActivated = false;
        else isActivated = true;

        if(isActivated)
        {
            mr.material.color = Color.green;
            anim.SetBool("Activated", true);
            realSliderValue = sliderValue;
        }
        else
        {
            mr.material.color = Color.red;
            anim.SetBool("Activated", false);
            realSliderValue = 1;
        }
    }
}
