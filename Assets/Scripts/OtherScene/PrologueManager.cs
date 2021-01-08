using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PrologueManager : MonoBehaviour
{
    public Transform[] cartoons;
    public int page;
    public Button leftBtn;
    public Button rightBtn;
    public Button inGameBtn;
    public Image fadeImg;
    public AudioSource clickSound;
    public AudioSource BGM;
    
    private void Start() {
        //#0. Setting Global Sound Volume
        clickSound.volume = GlobalVar.soundVolume /10f;
        BGM.volume = GlobalVar.soundVolume / 10f;
        BGM.time = 0;
        BGM.loop = true;
        BGM.Play();
    }

    public void LeftBtnClick(){
        clickSound.Play();
        if(page ==0) return ;
        page--;
        cartoons[page].DOLocalMoveY(0, 0.5f).SetEase(Ease.OutBack);

        if(page == 5){
            rightBtn.gameObject.SetActive(true);
            inGameBtn.gameObject.SetActive(false);
        }

    }
    public void RightBtnClick(){
        clickSound.Play();
        cartoons[page].DOLocalMoveY(1500, 0.5f).SetEase(Ease.InBack);
        page++;
        if(page==6){
            //EndBtnVisible
            rightBtn.gameObject.SetActive(false);
            inGameBtn.gameObject.SetActive(true);
        }
    }

    public void InGameBtnClick(){
        clickSound.Play();
        fadeImg.gameObject.SetActive(true);
        fadeImg.DOFade(1, 1).SetEase(Ease.InQuad);
        Invoke("NextScene", 3f);
    }

    public void NextScene(){
        SceneManager.LoadScene(3);
    }
}
