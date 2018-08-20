using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SoundManagerNamespace;

public class PlayMusicTrigger : MonoBehaviour {

    public string music;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            MissionManager.instance.isInVents = true;

            if(music == "escapeSing")
            {
                if (MissionManager.instance.isInLastPuzzle)
                {
                    AudioManager.instance.PlayMusic(music);
                }
            }
            else AudioManager.instance.PlayMusic(music);
        }
    }
}
