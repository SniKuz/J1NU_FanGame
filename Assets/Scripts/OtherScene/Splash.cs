using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    public GameObject THE_PIXEL;
    public GameObject fanGame;
    public AudioSource pixelSound;
    

    private void Start() {
        AudioVolumeSet();
        Invoke("The_PixelScale", 1f);
    }

    public void The_PixelScale(){
        pixelSound.loop = false;
        pixelSound.time = 0;
        pixelSound.Play();
        THE_PIXEL.transform.DOScale(new Vector3(0.8f,0.8f,0.8f), 1.5f).SetEase(Ease.OutElastic);
        Invoke("FanGameScale", 0.5f);
    }

    public void FanGameScale(){
        fanGame.transform.DOScale(new Vector3(0.8f,0.8f,0.8f), 0.5f);
        Invoke("ColorAlpha", 1f);
    }

    public void ColorAlpha(){
        THE_PIXEL.GetComponentInChildren<SpriteRenderer>().material.DOColor(new Color32(255, 255, 255, 0), 1f);
        fanGame.GetComponentInChildren<SpriteRenderer>().material.DOColor(new Color32(255, 255, 255, 0), 1f);
        Invoke("NextScene", 1f);
    }
    public void NextScene(){
        SceneManager.LoadScene(1);
    }

    private void AudioVolumeSet(){
        pixelSound.volume = GlobalVar.soundVolume / 10f;
    }
}
