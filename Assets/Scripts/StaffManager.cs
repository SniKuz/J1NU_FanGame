using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffManager : MonoBehaviour
{
    public int[] waitStaffCnt;
    public float[,] staffMPS; // Staff가 초당 만드는 생산량 Make Per Sec
    public int[,] staffCnt;

    private void Awake() {
        staffCnt = new int[3, 4]{ {1, 0, 2, 1}
                                ,{0, 0, 0, 0}
                                ,{1, 0, 0, 5} }; //Goods make room, 
        staffMPS = new float[3, 4]{ {10, 5, 3, 1}
                                ,{0, 0, 0, 0}
                                ,{10f, 4f, 1.5f, 0.5f} }; //Goods make room, 

        waitStaffCnt = new int[4] {0, 0, 0, 0};
        
    }
}
//#10. MilkStaffMake 1:32:43
//진행상황 - 스태프 UI 및 초당 시청자, 굿즈 수 증가 정도만 진행.