using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class EndingManager : MonoBehaviour
{
    public Image fadeImg;
    public string[] endingStory;
    public int index;
    public TextMeshProUGUI storyText;
    public Animator creditAnim;
    public Image EndingPicture;

    private void Start() {
        fadeImg.DOFade(1, 1.5f).SetEase(Ease.InQuad);

        endingStory = new string[] {"원두컴퍼니와의 전쟁에서 이긴 지누는...", 
                                    "뿔뿔이 흩어진 동료들을 찾아...",
                                    "다시 픽셀을\n세계 최고의 기업으로 성장시킨다.",
                                    "김진우!김진우!김진우!김진우!김진우!김진우!김진우!김진우!김진우!김진우!김진우!김진우!김진우!김진우!김진우!",
                                    "The End",
                                    "(쿠키 이야기 있어요)"};

        Invoke("EndStoryTalikg", 2f);
    }

    public void EndStoryTalikg(){
        storyText.text = endingStory[index < 6 ? index++ : 5];
        storyText.DOFade(1, 1f);

        Invoke("DoFadeText", 3f);
        if(index >= 6){
            creditAnim.SetBool("CreditOn", true);
            Invoke("DoEndingPicutreFadeOn", 63f);
        }

        if(index<6)
            Invoke("EndStoryTalikg", 4f);
    }

    public void DoFadeText(){
        storyText.DOFade(0, 1f);
    }
    public void DoEndingPicutreFadeOn(){
        creditAnim.Rebind();//애니메이션 초기화
        EndingPicture.DOFade(1, 1.5f);
        Invoke("DoEndingPicutreFadeOff", 5f);
    }
    public void DoEndingPicutreFadeOff(){
        EndingPicture.DOFade(0, 1f);
    }
}
