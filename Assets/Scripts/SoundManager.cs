using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public GameObject sfx;
    public AudioClip[] audioClips;


    public void PlaySound(int soundNum)
    {
        GameObject instGO = Instantiate(sfx, Vector2.zero, Quaternion.identity) as GameObject;
        AudioSource soundSource = instGO.GetComponent<AudioSource>();

        soundSource.clip = audioClips[soundNum];
        soundSource.Play();
        Destroy(instGO, audioClips[soundNum].length);
    }
}
