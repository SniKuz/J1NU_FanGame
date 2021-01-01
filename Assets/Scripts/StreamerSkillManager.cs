using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamerSkillManager : MonoBehaviour
{
    public Sprite[] skillIcons; //Skill Icons. 여기다 넣어서 아이콘 바꿈.
    public StreamerSkillVo selecetedSkill;
    StreamerSkillVo[] skillGrid;

    
    private void Awake() {
        skillGrid = new StreamerSkillVo[20];
        GenerateStreamerSkill();
    }

    public StreamerSkillVo GetSkill(int skillId){
        return skillGrid[skillId];
    }

    void GenerateStreamerSkill(){
        StreamerSkillVo GoldSaHyang0 = new StreamerSkillVo(0,skillIcons[0], "치명적인 귀여움", 0, new int[5] {1000, 3000, 50000, 10000, 20000}, 
        "시청자 수 증가량 + 10%",  "치명적인 귀여움을 뽑냅니다");
        StreamerSkillVo GoldSaHyang1 = new StreamerSkillVo(1,skillIcons[1], "질러팅", 0, new int[5] {1000, 3000, 50000, 10000, 20000}, 
        "시청자 수, 도네 증가량 + 5%",  "질러팅을 진행할 확률이 증가합니다");
        StreamerSkillVo GoldSaHyang2 = new StreamerSkillVo(2,skillIcons[2], "숏과 까미", 0, new int[5] {1000, 3000, 50000, 10000, 20000}, 
        "아직 무슨 효과인지 밝혀지지 않았습니다",  "숏과 까미가 귀엽습니다."); // 막라 난이도 낮추는 용으로 괜찮은듯
        StreamerSkillVo GoldSaHyang3 = new StreamerSkillVo(3,skillIcons[3], "굿즈생산", 0, new int[5] {1000, 3000, 50000, 10000, 20000}, 
        "굿즈 생산 터치 수 감소",  "새로운 굿즈를 만듭니다.");
        StreamerSkillVo GoldSaHyang4 = new StreamerSkillVo(4,skillIcons[4], "지모노X찍찍단", 0, new int[5] {1000, 3000, 50000, 10000, 20000}, 
        "일정확률로 돈, 시청자 수가 증가합니다",  "지모노와 찍찍단이 단결합니다. 매 게이지마다 일정확률로 돈, 시청자 수가 증가합니다");

        StreamerSkillVo Collet0 = new StreamerSkillVo(5,skillIcons[5], "C++ 개발자", 0, new int[5] {1000, 3000, 50000, 10000, 20000}, 
        "시청자 수 증가량 + 10%",  "C++ 개발을 착수합니다");
        StreamerSkillVo Collet1 = new StreamerSkillVo(6,skillIcons[6], "코정치", 0, new int[5] {1000, 3000, 50000, 10000, 20000}, 
        "시청자 수 증가량 + 10%",  "훌륭한 정치력을 가지고있습니다. 이를 올바른데 사용하기 시작합니다.");
        StreamerSkillVo Collet2 = new StreamerSkillVo(7,skillIcons[7], "샤샤", 0, new int[5] {1000, 3000, 50000, 10000, 20000}, 
        "시청자 수 증가량 + 10%",  "샤샤를 모십니다.");
        StreamerSkillVo Collet3 = new StreamerSkillVo(8,skillIcons[8], "애교", 0, new int[5] {1000, 3000, 50000, 10000, 20000}, 
        "시청자 수 증가량 + 10%",  "방송에서 애교를 할 확률이 증가합니다");
        StreamerSkillVo Collet4 = new StreamerSkillVo(9,skillIcons[9], "애교", 0, new int[5] {1000, 3000, 50000, 10000, 20000}, 
        "시청자 수 증가량 + 10%",  "방송에서 애교를 할 확률이 증가합니다");

        StreamerSkillVo Tamx20 = new StreamerSkillVo(10,skillIcons[10], "나도 알고있어~ 내가.. 귀여운거..", 0, new int[5] {1000, 3000, 50000, 10000, 20000}, 
        "매 게이지마다 골드 + 500",  "자신의 귀여움을 인정합니다. 미션을 성공합니다.");
        StreamerSkillVo Tamx21 = new StreamerSkillVo(11,skillIcons[11], "하늘이 버린 게임실력", 0, new int[5] {1000, 3000, 50000, 10000, 20000}, 
        "시청자 수 증가량 + 10%",  "놀라지 마세요. 그녀의 게임실력은 현실입니다.");
        StreamerSkillVo Tamx22 = new StreamerSkillVo(12,skillIcons[12], "JMT", 0, new int[5] {1000, 3000, 50000, 10000, 20000}, 
        "시청자 수 증가량 + 10%",  "비슷한 스킬이 있는것 같지만 신경쓰지 맙시다. 하나의 스킬로 표현하기 힘듭니다.");
        StreamerSkillVo Tamx23 = new StreamerSkillVo(13,skillIcons[13], "탬동부 출동", 0, new int[5] {1000, 3000, 50000, 10000, 20000}, 
        "시청자 수 증가량 + 10%",  "탬동부가 야근을 합니다.");
        StreamerSkillVo Tamx24 = new StreamerSkillVo(14,skillIcons[14], "너무 커~버린 손녀", 0, new int[5] {1000, 3000, 50000, 10000, 20000}, 
        "시청자 수 증가량 + 10%",  "그녀는 계속 커집니다. 아, 신장을 말하는게 아닙니다.");

        StreamerSkillVo Nanayang0 = new StreamerSkillVo(15,skillIcons[15], "나테이커 효과", 0, new int[5] {1000, 3000, 50000, 10000, 20000}, 
        "시청자 수 증가량 + 10%",  "놀라지 마세요. 그녀의 게임실력 또한 현실입니다.");
        StreamerSkillVo Nanayang1 = new StreamerSkillVo(16,skillIcons[16], "사장님", 0, new int[5] {1000, 3000, 50000, 10000, 20000}, 
        "시청자 수 증가량 + 10%",  "사장님을 부릅니다.");
        StreamerSkillVo Nanayang2 = new StreamerSkillVo(17,skillIcons[17], "Coke디렉터", 0, new int[5] {1000, 3000, 50000, 10000, 20000}, 
        "시청자 수 증가량 + 10%",  "Coke 디렉터입니다. 응원과 존경을 보냅니다.");
        StreamerSkillVo Nanayang3 = new StreamerSkillVo(18,skillIcons[18], "머찐나", 0, new int[5] {1000, 3000, 50000, 10000, 20000}, 
        "시청자 수 증가량 + 10%",  "그녀는 머찝니다.");
        StreamerSkillVo Nanayang4 = new StreamerSkillVo(19,skillIcons[19], "우주대스타", 0, new int[5] {1000, 3000, 50000, 10000, 20000}, 
        "시청자 수 증가량 + 10%",  "우주에서 가장 빛나는 별입니다. 그녀를 모르는 우주인은 없을겁니다.");

        skillGrid[0] = GoldSaHyang0;
        skillGrid[1] = GoldSaHyang1;
        skillGrid[2] = GoldSaHyang2;
        skillGrid[3] = GoldSaHyang3;
        skillGrid[4] = GoldSaHyang4;
        skillGrid[5] = Collet0;
        skillGrid[6] = Collet1;
        skillGrid[7] = Collet2;
        skillGrid[8] = Collet3;
        skillGrid[9] = Collet4;
        skillGrid[10] = Tamx20;
        skillGrid[11] = Tamx21;
        skillGrid[12] = Tamx22;
        skillGrid[13] = Tamx23;
        skillGrid[14] = Tamx24;
        skillGrid[15] = Nanayang0;
        skillGrid[16] = Nanayang1;
        skillGrid[17] = Nanayang2;
        skillGrid[18] = Nanayang3;
        skillGrid[19] = Nanayang4;
    }
}