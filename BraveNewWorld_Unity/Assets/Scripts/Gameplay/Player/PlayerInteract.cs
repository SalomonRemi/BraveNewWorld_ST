using DigitalRuby.SoundManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInteract : MonoBehaviour {

    [Header("Interaction Settings")]
	public Camera cam;
	public float rangetouch;
	public bool touch;
	public bool isSitting = true;
	//public GameObject chair;
	Collider rend = null;
    //public GameObject sitMessage;

    [Header("Reticle Display")]
    public TextMeshProUGUI interactionObjectText;
    public TextMeshProUGUI interactionVerbText;
    public Image interactInputImage;

    public string manualVerb;
    public string documentVerb;
    public string drawerVerb;
	public string doorVerb;
    public string doorButtonVerb;
    public string powerButtonVerb;


    private Vector3 prevSitpos;

	private FPSController fpsController;

    
	void Start()
	{
		cam = GetComponent<Camera>();

		fpsController = FindObjectOfType<FPSController> ();

        interactionObjectText.gameObject.SetActive(false);
        interactionVerbText.gameObject.SetActive(false);
        interactInputImage.gameObject.SetActive(false);
    }

	void Update ()
	{
        Ray ray = cam.ScreenPointToRay (new Vector3 (cam.pixelWidth / 2, cam.pixelHeight / 2, 0));
        Vector3 rayOrigin = new Vector3(ray.origin.x, ray.origin.y - 0.7f, ray.origin.z);
		Debug.DrawRay (ray.origin, ray.direction * rangetouch, Color.yellow);

		if (Input.GetButtonDown ("Fire1"))
        {
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, rangetouch, 1 << LayerMask.NameToLayer("Interactible")))
            {
				if (isSitting)
                {
					if (hit.transform.gameObject.CompareTag ("keyBtn")) 
					{
                        if(hit.transform.gameObject.GetComponentInParent<Keypad>().canUse)
                        {
                            hit.transform.gameObject.GetComponent<keyBtn>().enableButton();
                        }
					}
                    if (hit.transform.gameObject.CompareTag("digiBtn"))
                    {
                        hit.transform.gameObject.GetComponent<digicodeBtn>().enableButton();
                    }
                    if (hit.transform.gameObject.CompareTag("lever"))
                    {
                        hit.transform.gameObject.GetComponent<flipSwitch>().flip();
                    }
                    if (hit.transform.gameObject.CompareTag("lockUp"))
                    {
						hit.transform.gameObject.GetComponentInParent<LockerNum>().IncreaseNumber();
                        AudioManager.instance.PlaySound("lockerButton");
                    }
                    if (hit.transform.gameObject.CompareTag("lockDown"))
                    {
						hit.transform.gameObject.GetComponentInParent<LockerNum>().DecreaseNumber();
                        AudioManager.instance.PlaySound("lockerButton");
                    }
                    if (hit.transform.gameObject.CompareTag("slider"))
                    {
                        if (hit.transform.gameObject.GetComponent<PuzzleSlider>().isValidate) hit.transform.gameObject.GetComponent<PuzzleSlider>().ValidateNumber();
                        else hit.transform.gameObject.GetComponent<PuzzleSlider>().SliderInteraction();
                    }
                    if (hit.transform.gameObject.CompareTag("powerButton"))
                    {
                        hit.transform.gameObject.GetComponent<ElectricPowerButton>().EnableObjects();
                    }
                    if (hit.transform.gameObject.CompareTag("radioButton"))
                    {
                        if(!hit.transform.gameObject.GetComponent<Radio>().isActivated)
                        {
                            hit.transform.gameObject.GetComponent<Radio>().StartRadio();
                        }
                        else
                        {
                            hit.transform.gameObject.GetComponent<Radio>().CutRadio();
                        }
                    }
                    else if (hit.transform.gameObject.CompareTag("megaphoneButton"))
                    {
                        if (!hit.transform.gameObject.GetComponent<Megaphone>().isActivated)
                        {
                            hit.transform.gameObject.GetComponent<Megaphone>().StartMegaphone();
                        }
                        else
                        {
                            hit.transform.gameObject.GetComponent<Megaphone>().CutMegaphone();
                        }
                    }
                    else if (hit.transform.gameObject.CompareTag("alarmButton"))
                    {
                        hit.transform.gameObject.GetComponent<Alarm>().DoAlarm();
                    }
                }
			} 
		}

		if(Input.GetButtonDown ("Fire1") && !GameManager.instance.documentOpen)
        {
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rangetouch, 1 << LayerMask.NameToLayer("Interactible")))
            {
                if (hit.transform.gameObject.CompareTag("manual"))
                {
                    GameManager.instance.pagesSprites = hit.transform.gameObject.GetComponent<bookPages>().bookPagesSprites;
                    GameManager.instance.manualVisible = true;
                    AudioManager.instance.PlaySound("clickDoc");
                }
                if (hit.transform.gameObject.CompareTag("drawer"))
                {
                    hit.transform.gameObject.GetComponent<drawerOpen>().open();
                }
                if (hit.transform.gameObject.CompareTag("document"))
                {
                    hit.transform.gameObject.GetComponent<DocumentOpener>().CreateDoc();
                    AudioManager.instance.PlaySound("clickDoc");
                }
                if(hit.transform.gameObject.CompareTag("doorButton"))
                {
                    hit.transform.gameObject.GetComponent<DoorButton>().OpenDoor();
                }

            }
        }


		RaycastHit hitInfo;
		Collider currRend;

		if (Physics.Raycast (ray, out hitInfo, rangetouch, 1 << LayerMask.NameToLayer("Interactible")))
        {
			if (hitInfo.collider.gameObject.GetComponent<highlightSelf> ())
            {
				currRend = hitInfo.collider.gameObject.GetComponent<Collider> ();

				if (currRend == rend)
					return;

				if (currRend && currRend != rend)
                {
					if (rend)
                    {
						rend.gameObject.GetComponent<highlightSelf> ().isSelected = false;
					}
				}

				if (currRend)
					rend = currRend;
				else
					return;

				rend.gameObject.GetComponent<highlightSelf> ().isSelected = true;

                // Check what you are looking
                if (hitInfo.transform.gameObject.CompareTag("manual"))
                {
                    interactionObjectText.gameObject.SetActive(true);
                    interactionObjectText.text = hitInfo.transform.gameObject.GetComponent<bookPages>().displayName;

                    interactionVerbText.gameObject.SetActive(true);
                    interactionVerbText.text = manualVerb;

                    interactInputImage.gameObject.SetActive(true);

                }
                else if (hitInfo.transform.gameObject.CompareTag("drawer"))
                {
                    interactionObjectText.text = "Tiroir";

                    interactionObjectText.gameObject.SetActive(true);

                    interactionVerbText.gameObject.SetActive(true);
                    interactionVerbText.text = drawerVerb;

                    interactInputImage.gameObject.SetActive(true);
                }
                else if (hitInfo.transform.gameObject.CompareTag("document"))
                {
                    interactionObjectText.gameObject.SetActive(true);
                    interactionObjectText.text = hitInfo.transform.gameObject.GetComponent<DocumentOpener>().displayName;

                    interactionVerbText.gameObject.SetActive(true);
                    interactionVerbText.text = documentVerb;

                    interactInputImage.gameObject.SetActive(true);
                }
				else if (hitInfo.transform.gameObject.CompareTag("door"))
				{
					interactionObjectText.gameObject.SetActive(true);
					interactionObjectText.text = "Office door";

					interactionVerbText.gameObject.SetActive(true);
					interactionVerbText.text = doorVerb;

					interactInputImage.gameObject.SetActive(true);
				}
                else if (hitInfo.transform.gameObject.CompareTag("doorButton"))
                {
                    interactionObjectText.gameObject.SetActive(true);
                    interactionObjectText.text = hitInfo.transform.gameObject.GetComponent<DoorButton>().displayName;

                    interactionVerbText.gameObject.SetActive(true);
                    interactionVerbText.text = doorButtonVerb;

                    interactInputImage.gameObject.SetActive(true);
                }
                else if (hitInfo.transform.gameObject.CompareTag("powerButton"))
                {
                    interactionObjectText.gameObject.SetActive(true);
                    interactionObjectText.text = "Electric power";

                    interactionVerbText.gameObject.SetActive(true);
                    interactionVerbText.text = powerButtonVerb;

                    interactInputImage.gameObject.SetActive(true);
                }
                else if (hitInfo.transform.gameObject.CompareTag("radioButton"))
                {
                    interactionObjectText.gameObject.SetActive(true);
                    interactionObjectText.text = "Radio power";

                    interactionVerbText.gameObject.SetActive(true);
                    interactionVerbText.text = powerButtonVerb;

                    interactInputImage.gameObject.SetActive(true);
                }
                else if (hitInfo.transform.gameObject.CompareTag("megaphoneButton"))
                {
                    interactionObjectText.gameObject.SetActive(true);
                    interactionObjectText.text = "Megaphone power";

                    interactionVerbText.gameObject.SetActive(true);
                    interactionVerbText.text = powerButtonVerb;

                    interactInputImage.gameObject.SetActive(true);
                }
                else if (hitInfo.transform.gameObject.CompareTag("alarmButton"))
                {
                    interactionObjectText.gameObject.SetActive(true);
                    interactionObjectText.text = "Alarm";

                    interactionVerbText.gameObject.SetActive(true);
                    interactionVerbText.text = powerButtonVerb;

                    interactInputImage.gameObject.SetActive(true);
                }
                else if (hitInfo.transform.gameObject.CompareTag("lever"))
                {
                    interactionObjectText.gameObject.SetActive(true);
                    interactionObjectText.text = "Lever";

                    interactionVerbText.gameObject.SetActive(true);
                    interactionVerbText.text = "Flip";

                    interactInputImage.gameObject.SetActive(true);
                }
            }
            else
            {
                if (rend)
                {
					rend.gameObject.GetComponent<highlightSelf> ().isSelected = false;
					rend = null;
				}

                // DISPLAY SECURITY
                interactionVerbText.gameObject.SetActive(false);
                interactInputImage.gameObject.SetActive(false);
                interactionObjectText.gameObject.SetActive(false);
            }   
		}
        else
        {
			if (rend)
            {
				rend.gameObject.GetComponent<highlightSelf> ().isSelected = false;
				rend = null;
			}

            interactionVerbText.gameObject.SetActive(false);
            interactInputImage.gameObject.SetActive(false);
            interactionObjectText.gameObject.SetActive(false);
        }
    }
}