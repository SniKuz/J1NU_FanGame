﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomAnim : MonoBehaviour
{
    private Animator anim;
    private bool isStop;
    public bool isEvent;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    private void Update() {
        isStop = GameManager.Instance.isStopUI;
        if(!isStop){
            anim.SetBool("isStop", false);
        }else{
                anim.SetBool("isStop", true);
        }
    }

}
