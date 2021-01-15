using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalVar : MonoBehaviour
{
    public static int soundVolume;
    public static int clickCnt;
    public static int goodsPrice;
    public static int donationPrice;
    public static int startMoney;
    private void Awake() {
        DontDestroyOnLoad(gameObject);

        //#.Get Save Data for volume
        if(SceneManager.GetActiveScene().buildIndex == 0){
            //Access Sve Data
            soundVolume = 5;
        }
    }
}
