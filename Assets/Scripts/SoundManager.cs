using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource backGroundMusic;
    public AudioSource panelAudioSource;
    public AudioSource staffABCOpen;
    public AudioSource staffSOepn;
    public AudioSource skillLevelUp;
    public AudioSource electricDrill;

    public bool drillBool;

    private void Start() {
        //#0.Global soundVolume Setting
        // backGroundMusic.volume = GlobalVar.soundVolume /10f;
        // panelAudioSource.volume = GlobalVar.soundVolume /10f;
        // staffABCOpen.volume = GlobalVar.soundVolume /10f;
        // staffSOepn.volume = GlobalVar.soundVolume /10f;
        // skillLevelUp.volume =GlobalVar.soundVolume /10f;

        backGroundMusic = GetComponent<AudioSource>();
        backGround(backGroundMusic);
    }
    public static void backGround(AudioSource audioPlayer){
        audioPlayer.Stop();
        audioPlayer.loop = true;
        audioPlayer.time = 0;
        audioPlayer.Play();
    }

    public void PanelClick(){
        panelAudioSource.loop = false;
        panelAudioSource.time = 0;
        panelAudioSource.Play();
    }
    public void SkillUp(){
        skillLevelUp.time = 0;
        skillLevelUp.Play();
    }

    public void DrillSound(){
        if(drillBool == false){
            drillBool = true;
            electricDrill.time = 0;
            electricDrill.Play();
            Invoke("DrillBoolChange", 1f);
        }
    }
    public void DrillBoolChange(){
        drillBool = false;
    }

    public void StaffOpen(int staff){
        if(staff <= 0){
            staffABCOpen.loop = false;
            staffABCOpen.time = 0;
            staffABCOpen.Play();
        }else if(staff > 0){
            staffSOepn.loop = false;
            staffSOepn.time = 0;
            staffSOepn.Play();
        }
    }
}

