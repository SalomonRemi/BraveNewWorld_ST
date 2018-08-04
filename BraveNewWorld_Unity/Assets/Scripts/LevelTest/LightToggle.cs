using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightToggle : MonoBehaviour {

    public List<GameObject> lightList;
    public bool isActivated;

	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isActivated)
            {
                isActivated = false;
                for (int i = 0; i < lightList.Count; i++)
                {
                    lightList[i].gameObject.SetActive(false);
                }
            }
            else
            {
                isActivated = true;
                for (int i = 0; i < lightList.Count; i++)
                {
                    lightList[i].gameObject.SetActive(true);
                }
            }
        }
	}
}
