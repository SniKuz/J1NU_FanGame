using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This code for change Animation
now there are only default and sleep animation so code is only change isSleep parameter
**/
public class HighCharacterAnim : MonoBehaviour
{

    private Animator anim;
    private float animChangeTime;
    private bool isDefault;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        animChangeTime = 0f;
        isDefault = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.isStopUI){
            anim.SetBool("Default",false);
            anim.SetBool("Sleep", false);
            return ;
        }

        animChangeTime += Time.deltaTime;
        if(animChangeTime>120f){
            animChangeTime = 0;
            isDefault = !isDefault;
        }
        if(isDefault){
            anim.SetBool("Default",true);
            anim.SetBool("Sleep", false);
        }else{
            anim.SetBool("Default",false);
            anim.SetBool("Sleep", true);
        }
    }
}