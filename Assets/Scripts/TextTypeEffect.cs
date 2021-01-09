using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextTypeEffect : MonoBehaviour
{
    public GameObject EndCursor;
    public int CharPerSeconds;
    public bool isAnim;
    public bool isStart;
    public bool isEnd;
    public TextMeshProUGUI msgText;
    AudioSource audioSource;
    int charPerSound;
    string targetMsg;
    int index;
    float interval;

    private void Awake() {
        msgText = GetComponent<TextMeshProUGUI>();
        audioSource = GetComponent<AudioSource>();

        //#.Sound volume setting
        // audioSource.volume = GlobalVar.soundVolume;
    }
    private void Start() {
        charPerSound = 2;
    } 
    
    public void SetMsg(string msg){
        if(msg == null){
            isEnd = true;
            return;
        }

        if(isAnim){
            msgText.text = targetMsg;
            CancelInvoke();
            EffectEnd();
        }else{
            targetMsg = msg;
            EffectStart();
        }
    }

    void EffectStart(){
        msgText.text = "";
        index = 0;
        EndCursor.SetActive(false);

        //#.Start Anim
        interval = 1.0f/CharPerSeconds;

        isEnd = false;
        isAnim = true;
        InvokeRepeating("Effecting", isStart? 0.8f : 0f, interval);
    }
    void Effecting(){
        //End Anim
        if(msgText.text == targetMsg){
            EffectEnd();
            return;
        }

        msgText.text += targetMsg[index];
        //Text Sound
        if(targetMsg[index] != ' ' || targetMsg[index] != '.')
            charPerSound--;
            if(charPerSound <= 0){
                audioSource.Play();
                charPerSound = 2;
            }
        
        index++;
    }

    void EffectEnd(){
        isStart = false;
        isAnim = false;
        EndCursor.SetActive(true);
        CancelInvoke();
    }
}
