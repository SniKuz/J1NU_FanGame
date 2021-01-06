using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public UIManager uiManager;
    public EventVo[] eventList;
    public EventVo curEvent;
    public EventVo nextEvent;
    public int eventIndex;
    public GameObject eventBtn;
    public GameObject[] eventBtnPocket;//이벤트 버튼들 잠시 넣어두는 곳
    public GameObject Contents;//내용 content가 아니라 evenBtn 생성 위치
    private void Awake() {
        eventList = new EventVo[20];
        eventBtnPocket = new GameObject[3];
        Generate();
    }

    private void Start() {
        nextEvent = eventList[eventIndex];
    }

    void Generate(){
        EventVo event00 = new EventVo(0, 1, "사채", 
        "사채업자가 나타났다\n빨리 여기서 도망쳐야 한다!\n3rdLine",1,  new string[] {"String배열"});
        EventVo event01 = new EventVo(1, 2, "게임", 
        "게임방송\n켠왕실시!\n3rdLine", 2,  new string[] {"String배열", "초기화가 되나?"});
        EventVo event02 = new EventVo(2, 3, "사채", 
        "사채업자가 나타났다\n빨리 여기서 도망쳐야 한다!\n3rdLine", 3,  new string[] {"String배열", "3개버튼 초기화", "와우"});

        eventList[0] = event00;
        eventList[1] = event01;
        eventList[2] = event02;
    }

    public bool CheckEvent(int curDay){
        int eventDay = nextEvent._day;
        bool isEvent = eventDay == curDay;

        //#.이벤트 실행, 다음 이벤트 장전
        if(isEvent){
            curEvent = nextEvent;
            eventIndex++;
            nextEvent = eventList[eventIndex];
        }
        return isEvent;
    }

    public void MakeEventBtn(int id){
        int btnIndex = eventList[id]._btnIndex;
        for(int i=0; i<btnIndex; i++){
            eventBtnPocket[i] = newEvent(eventList[id]._btnText[i], i);
        }
    }

    public GameObject newEvent(string btnText, int i){
        GameObject newEventBtn = Instantiate(eventBtn, new Vector3(0,0,0), Quaternion.identity);
        newEventBtn.transform.SetParent(Contents.transform);
        newEventBtn.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        newEventBtn.GetComponentInChildren<TextMeshProUGUI>().text = btnText;

        newEventBtn.GetComponent<Button>().onClick.AddListener(delegate{uiManager.EventBtn(i);});//각 버튼 AddListner 배치
        return newEventBtn;
    }
}
