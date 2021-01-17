using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject pixelPan; // transform.y : 1000->-60
    public GameObject startBtn;
    public GameObject optionBtn;
    public GameObject closeBtn;
    public GameObject gameBtn;
    public GameObject OptionPanel;

    public TextMeshProUGUI soundText;

    public AudioSource pixelJump;
    public AudioSource BGM;

    public Image fadeImg;
    private void Awake() {
    }

    private void Start() {
        //#0. Setting Global Sound
        soundText.text = GlobalVar.soundVolume+"";
        AudioVloumeSet();


        //#1.PixelPan Anim
        pixelPan.transform.DOLocalMove(new Vector3(0,500,0), 2f).SetEase(Ease.OutBounce);
        Invoke("PixelPanSound", 0.6f);
        Invoke("PixelPanSound", 1.35f);
        Invoke("PixelPanSound", 1.68f);
        Invoke("MenuBtnScale", 2f);


    }
    private void PixelPanSound(){
        pixelJump.time = 0;
        pixelJump.Play();
    }
    public void MenuBtnScale(){
        startBtn.transform.DOScale(new Vector3(1,1,1), 1);
        optionBtn.transform.DOScale(new Vector3(1,1,1), 1);
        closeBtn.transform.DOScale(new Vector3(1,1,1), 1);
        BGM.Play();
    }

    public void StartBtnClick(){
        if(gameBtn.transform.localScale == Vector3.zero) 
            gameBtn.transform.DOScale(new Vector3(1.5f, 1.5f, 1), 0.5f).SetEase(Ease.OutBack);
        else
            gameBtn.transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.OutBack);
    }

    public void EasyGameBtn(){
        GlobalVar.startMoney = 100000000;
        GlobalVar.clickCnt = 10;
        GlobalVar.goodsPrice = 3000; //평균 3천원으로
        GlobalVar.donationPrice = 1000; //평균 천원으로
        GlobalVar.startFinalTime = 15f;



        fadeImg.gameObject.SetActive(true);
        fadeImg.DOFade(1, 1).SetEase(Ease.InQuad);
        Invoke("NextScene", 3f);
    }

    public void NormalGameBtn(){
        GlobalVar.startMoney = 0;
        GlobalVar.clickCnt = 15;
        GlobalVar.goodsPrice = 4000; //평균 3천원으로
        GlobalVar.donationPrice = 1500; //평균 천원으로
        GlobalVar.startFinalTime = 25f;

        fadeImg.gameObject.SetActive(true);
        fadeImg.DOFade(1, 1).SetEase(Ease.InQuad);
        Invoke("NextScene", 3f);
    }

    public void HardGameBtn(){
        GlobalVar.startMoney = 0;
        GlobalVar.clickCnt = 20;
        GlobalVar.goodsPrice = 3000; //평균 3천원으로
        GlobalVar.donationPrice = 700; //평균 천원으로
        GlobalVar.startFinalTime = 30f;

        fadeImg.gameObject.SetActive(true);
        fadeImg.DOFade(1, 1).SetEase(Ease.InQuad);
        Invoke("NextScene", 3f);
    }

    public void NextScene(){
        SceneManager.LoadScene(2);
    }

    public void OptionBtnCLick(){
        if(OptionPanel.transform.localScale == Vector3.zero) 
            OptionPanel.transform.DOScale(new Vector3(1, 1, 1), 0.5f).SetEase(Ease.OutBack);
        else
            OptionPanel.transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.OutBack);
    }

    public void SoundChangeClick(int sound){
        if(sound == 0 && GlobalVar.soundVolume<10){
            GlobalVar.soundVolume++;
        }
        else if(sound ==1 && GlobalVar.soundVolume>0){
            GlobalVar.soundVolume--;
        }
        soundText.text = GlobalVar.soundVolume+"";

        pixelJump.volume = GlobalVar.soundVolume/10f;
        BGM.volume = GlobalVar.soundVolume/10f;
    }

    private void AudioVloumeSet(){
        pixelJump.volume = GlobalVar.soundVolume / 10f;
        BGM.volume = GlobalVar.soundVolume / 10f;
    }


    public void CloseBtnClick(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying=false;
        #else
            Application.Quit();
        #endif
    }


}
