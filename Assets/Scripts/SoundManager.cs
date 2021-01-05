using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource musicPlayer;
    public AudioClip backGroundMusic;

    private void Start() {
        musicPlayer = GetComponent<AudioSource>();
        backGround(backGroundMusic, musicPlayer);
    }
    public static void backGround(AudioClip clip, AudioSource audioPlayer){
        audioPlayer.Stop();
        audioPlayer.clip = clip;
        audioPlayer.loop = true;
        audioPlayer.time = 0;
        audioPlayer.volume = 0.1f;
        audioPlayer.Play();
    }
}
