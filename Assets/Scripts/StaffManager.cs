using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StaffManager : MonoBehaviour
{
    public SoundManager soundManager;
    public int[] waitStaffCnt;
    public int[,] staffCnt; //배치한 스태프 수
    public float[,] staffMPS; // Staff가 초당 만드는 생산량 Make Per Sec
    public int[] staffCost;
    public GameObject hideStaffOne; // Hide Staff one (Capsule One)
    public GameObject hideStaffTen; //
    public GameObject[] staffPrefabsOne; //Staff S, A, B, C
    public GameObject[] staffPrefabsTen;
    public GameObject capsuleOpenEffect;
    public GameObject tenOpenEffect;
    public int drawStaffGrade;
    public int[] drawTenStaffGrade;

    public bool drawingTime; // while drawing don't talk tutorail or etc

    private void Awake() {
        waitStaffCnt = new int[4] {0, 0, 0, 0};
        staffCnt = new int[3, 4]{ {0, 0, 0, 0}
                                ,{0, 0, 0, 0}
                                ,{0, 0, 0, 0} }; //Goods make room, 
        staffMPS = new float[3, 4]{ {10, 3f, 1f, 0.5f}
                                ,{1, 0.4f, 0.2f, 0.1f}
                                ,{10f, 3f, 1f, 0.5f} }; //Goods make room, 

        staffCost = new int[4] {10, 7, 5, 3};
    }

    public void StartDrawStaff(int num){
        drawingTime = true;
        if(num == 1){

            hideStaffOne.SetActive(true);
            hideStaffOne.transform.DOPunchScale(new Vector3(1, 1, 1), 2, 2, 0.5f);
            Invoke("TouchAfterOneAnimEnd", 2.3f);
        }
        else if (num == 10){
            hideStaffTen.SetActive(true);
            hideStaffTen.transform.DOPunchScale(new Vector3(1, 1, 1),2, 2, 0.5f);
            Invoke("TouchAfterTenAnimEnd", 2.3f);
        }
    }

        public void OpenDrawStaff(int num){
            int bgm = 0;//For most high grade staff
            if(num ==1){
                hideStaffOne.GetComponent<Button>().enabled = false;//여러번 안눌리게 On Off
                int randomStaff = Random.Range(0, 100);
                if(randomStaff <50){
                    drawStaffGrade = 3;// Rank C 50%
                } else if(50 <= randomStaff && randomStaff < 80){
                    drawStaffGrade = 2;// Rank B 30%
                }else if(80 <= randomStaff && randomStaff < 97){
                    drawStaffGrade = 1;// Rank A 17%
                }else{
                    drawStaffGrade = 0;// Rank S 3%
                    bgm++;
                }
                soundManager.StaffOpen(bgm);//if bgm <= 0 ->ABC, bgm >0 ->S
                StartCoroutine("DrawOpenOneStaffDelay");
            }else if(num == 10){
                hideStaffTen.GetComponent<Button>().enabled = false;//여러번 안눌리게 On Off
                for(int i = 0; i<10; i++){
                    int randomStaff = Random.Range(0, 100);
                    if(randomStaff <50){
                        drawTenStaffGrade[i] = 3;// Rank C 50%
                    } else if(50 <= randomStaff && randomStaff < 80){
                        drawTenStaffGrade[i] = 2;// Rank B 30%
                    }else if(80 <= randomStaff && randomStaff < 97){
                        drawTenStaffGrade[i] = 1;// Rank A 17%
                    }else{
                        drawTenStaffGrade[i] = 0;// Rank S 3%
                        bgm++;
                    }
                }
                soundManager.StaffOpen(bgm);//if bgm <= 0 ->ABC, bgm >0 ->S
                StartCoroutine("DrawOpenTenStaffDelay");
            }
    }

    IEnumerator DrawOpenOneStaffDelay(){
        hideStaffOne.GetComponent<Animator>().Play("StaffGatCha", -1, 0f);
        capsuleOpenEffect.GetComponent<Animator>().SetTrigger("explosion");
        yield return new WaitForSeconds(0.3f);
        staffPrefabsOne[drawStaffGrade].transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 1);
    }

    IEnumerator DrawOpenTenStaffDelay(){
        tenOpenEffect.GetComponent<Animator>().SetTrigger("explosion");
        yield return new WaitForSeconds(0.3f);
        for(int i = 0; i< 10; i++){
            staffPrefabsTen[i * 4 + drawTenStaffGrade[i]].transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 1);
        }
        hideStaffTen.SetActive(false);
    }

    public void Recruit(int num){
        if(num == 1){
            staffPrefabsOne[drawStaffGrade].transform.localScale = new Vector3(0, 0, 0);
            hideStaffOne.GetComponent<Animator>().Rebind(); //Animation 초기화
            hideStaffOne.SetActive(false);
            waitStaffCnt[drawStaffGrade]++;
        }else{
            for(int i=0; i<10; i++){
                staffPrefabsTen[i * 4 + drawTenStaffGrade[i]].transform.localScale = new Vector3(0, 0, 0);
                waitStaffCnt[drawTenStaffGrade[i]]++;
            }
        }
        drawingTime = false;
    }
    public void TouchAfterOneAnimEnd(){
        hideStaffOne.GetComponent<Button>().enabled = true;//CapsuleOne 여러번 안눌리게 On Off
    }
    public void TouchAfterTenAnimEnd(){
        hideStaffTen.GetComponent<Button>().enabled = true;
    }
}