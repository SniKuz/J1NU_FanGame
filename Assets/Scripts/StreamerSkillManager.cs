using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamerSkillManager : MonoBehaviour
{
    public Sprite[] skillIcons; //Skill Icons. 여기다 넣어서 아이콘 바꿈.
    public StreamerSkillVo[] skillList;

    
    private void Awake() {
        skillList = new StreamerSkillVo[20];
        GenerateStreamerSkill();
    }

    public StreamerSkillVo GetSkill(int skillId){
        return skillList[skillId];
    }

    public void SkillLevelUp(int id){
        if(skillList[id]._level >=5) return;
        skillList[id]._level++;
    }

    void GenerateStreamerSkill(){
        StreamerSkillVo GoldSaHyang0 = new StreamerSkillVo(0,skillIcons[0], "치명적인 귀여움", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
                                                new string[] {"스태프 월급 축소 0%",
                                                                 "스태프 월급 축소 4%", 
                                                                 "스태프 월급 축소 8%", 
                                                                 "스태프 월급 축소 12%", 
                                                                 "스태프 월급 축소 16%",
                                                                 "스태프 월급 축소 20%"},
                                                new float[] {1f, 0.96f, 0.92f, 0.88f, 0.84f, 0.8f} ,  "그녀의 귀여움은 스태프들이 월급을 반환할 정도입니다...");
        StreamerSkillVo GoldSaHyang1 = new StreamerSkillVo(1,skillIcons[1], "질러팅", 0, new int[5] {1000, 3000, 50000, 10000, 20000}, 
                                                new string[] {  "굿즈 판매 속도 가속 X 1", 
                                                                "굿즈 판매 속도 가속 X 1.2", 
                                                                "굿즈 판매 속도 가속 X 1.4", 
                                                                "굿즈 판매 속도 가속 X 1.6", 
                                                                "굿즈 판매 속도 가속 X 1.8",
                                                                "굿즈 판매 속도 가속 X 2"},
                                                new float[] {1, 0.9f, 0.8f, 0.7f, 0.6f, 0.5f},  "그녀의 흥은 기계조차 흥얼거리게 합니다.");
        StreamerSkillVo GoldSaHyang2 = new StreamerSkillVo(2,skillIcons[2], "숏과 까미", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
                                                new string[] {  "굿즈 판매 개수 + 0", 
                                                                "굿즈 판매 개수 + 5", 
                                                                "굿즈 판매 개수 + 10", 
                                                                "굿즈 판매 개수 + 15", 
                                                                "굿즈 판매 개수 + 20",
                                                                "굿즈 판매 개수 + 30"},
                                                new float[] {0, 5, 10, 15, 20, 30},  "숏과 까미가 판매를 돕습니다."); // 막라 난이도 낮추는 용으로 괜찮은듯
        StreamerSkillVo GoldSaHyang3 = new StreamerSkillVo(3,skillIcons[3], "???", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
                                                new string[] {  "아직 효과를 알 수 없습니다.", 
                                                                "아직 효과를 알 수 없습니다", 
                                                                "아직 효과를 알 수 없습니다", 
                                                                "아직 효과를 알 수 없습니다", 
                                                                "아직 효과를 알 수 없습니다",
                                                                "아직 효과를 알 수 없습니다"}, // 마지막 금사향 Turn에 효과용
                                                new float[] {1, 2, 3, 4, 5},  "?는 게임의 로망입니다.\n왜냐고요?\n???");
        StreamerSkillVo GoldSaHyang4 = new StreamerSkillVo(4,skillIcons[4], "지모노", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
                                                new string[] {  "굿즈 판매가 보너스 + 0%", 
                                                                "굿즈 판매가 보너스 + 10%", 
                                                                "굿즈 판매가 보너스 + 15%", 
                                                                "굿즈 판매가 보너스 + 20%", 
                                                                "굿즈 판매가 보너스 + 25%",
                                                                "굿즈 판매가 보너스 + 40%"},
                                                new float[] {1f, 1.1f, 1.15f, 1.2f, 1.25f, 1.4f},  "굿즈에 대한 이해도가 뛰어납니다.\n어째서일까요...?");


        StreamerSkillVo Collet0 = new StreamerSkillVo(5,skillIcons[5], "C++ 개발자", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
                                                new string[] {  "굿즈 제작 클릭당 작업량 + 0", 
                                                                "굿즈 제작 클릭당 작업량 + 1", 
                                                                "굿즈 제작 클릭당 작업량 + 2", 
                                                                "굿즈 제작 클릭당 작업량 + 3", 
                                                                "굿즈 제작 클릭당 작업량 + 4",
                                                                "굿즈 제작 클릭당 작업량 + 5"},  
                                                new float[] {0f, 1f, 2f, 3f, 4f, 5f}, "C++ 개발을 착수합니다\n 굿즈 개발 기기의 효율이 올라갑니다.");
        StreamerSkillVo Collet1 = new StreamerSkillVo(6,skillIcons[6], "코정치", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
                                                new string[] {  "스태프 생산 보너스 0%", 
                                                                "스태프 생산 보너스 10%", 
                                                                "스태프 생산 보너스 15%", 
                                                                "스태프 생산 보너스 20%", 
                                                                "스태프 생산 보너스 25%",
                                                                "스태프 생산 보너스 40%"},  
                                                new float[] {1, 1.1f, 1.15f, 1.2f, 1.25f, 1.4f}, "훌륭한 정치력을 가지고있습니다.\n이를 올바른데 사용하기 시작합니다.");
        StreamerSkillVo Collet2 = new StreamerSkillVo(7,skillIcons[7], "샤샤님과 합방", 0, new int[5] {1000, 3000, 0000, 10000, 20000}, 
                                                new string[] {  "게이지마다 시청자 수 + 0", 
                                                                "게이지마다 시청자 수 + 1", 
                                                                "게이지마다 시청자 수 + 2", 
                                                                "게이지마다 시청자 수 + 3", 
                                                                "게이지마다 시청자 수 + 4",
                                                                "게이지마다 시청자 수 + 5"},  
                                                new float[] {0, 1, 2, 3, 4, 5}, "머기업 샤샤님과 합방을 진행합니다.");
        StreamerSkillVo Collet3 = new StreamerSkillVo(8,skillIcons[8], "뱅", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
                                                new string[] {  "0.3% 확률로 0뱅 획득", 
                                                                "0.3% 확률로 1뱅 획득", 
                                                                "0.3% 확률로 2뱅 획득", 
                                                                "0.3% 확률로 3뱅 획득", 
                                                                "0.3% 확률로 4뱅 획득",
                                                                "0.3% 확률로 5뱅 획득"},  
                                                new float[] {0, 1, 2, 3, 4, 5}, "극악의 확률로 하루가 지날 때 레벨에 맞는 뱅을 얻습니다.\n*1뱅은 3천5백만입니다.");//1뱅 = 35000000
        StreamerSkillVo Collet4 = new StreamerSkillVo(9,skillIcons[9], "수숭과 줴자", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
                                                new string[] {  "굿즈 디자인, 용량 클릭당 작업량 + 0", 
                                                                "굿즈 디자인, 용량 클릭당 작업량 + 1", 
                                                                "굿즈 디자인, 용량 클릭당 작업량 + 2",
                                                                "굿즈 디자인, 용량 클릭당 작업량 + 3", 
                                                                "굿즈 디자인, 용량 클릭당 작업량 + 4",
                                                                "굿즈 디자인, 용량 클릭당 작업량 + 5"},  
                                                new float[] {0, 1, 2, 3, 4, 5},"수숭과 줴자는 위대한 발명을 합니다.\n 기계의 효율이 올라갑니다.");

        StreamerSkillVo Tamx20 = new StreamerSkillVo(10,skillIcons[10], "나도 알아 내가 귀여운거", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
                                                new string[] {  "하루마다 돈 + 0", 
                                                                "하루마다 돈 + 10000", 
                                                                "하루마다 돈 + 50000", 
                                                                "하루마다 돈 + 100000", 
                                                                "하루마다 돈 + 300000",
                                                                "하루마다 돈 + 1000000"},  
                                                 new float[] {0, 10000, 50000, 100000, 300000, 1000000}, "자신의 귀여움을 인정합니다. 미션을 성공합니다.");
        StreamerSkillVo Tamx21 = new StreamerSkillVo(11,skillIcons[11], "밀감이", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
                                                new string[] {  "도네 최저가 0", 
                                                                "도네 최저가 500", 
                                                                "도네 최저가 1000", 
                                                                "도네 최저가 1500", 
                                                                "도네 최저가 2000",
                                                                "도네 최저가 3000"}, 
                                                new float[] {0, 500, 1000, 1500, 2000, 3000}, "밀감이는 매우 귀엽습니다.\n굿즈, 도네가격이 어떤일이 있어도 떨어지지 않는 최저가를 만들 정도로요.");
        StreamerSkillVo Tamx22 = new StreamerSkillVo(12,skillIcons[12], "JMT", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
                                                new string[] {  "주식 하락율 0% 감소", 
                                                                "주식 하락율 1% 감소", 
                                                                "주식 하락율 2% 감소", 
                                                                "주식 하락율 3% 감소", 
                                                                "주식 하락율 4% 감소",
                                                                "주식 하락율 5% 감소"},  
                                                new float[] {0, 1, 2, 3, 4, 5}, "DO you know JMT?\n그녀의 실력은 주식시장이 배려할 정도입니다.");
        StreamerSkillVo Tamx23 = new StreamerSkillVo(13,skillIcons[13], "감사링~ 감사띠~", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
                                                new string[] {  "수금율 + 0%", 
                                                                "수금율 + 10%", 
                                                                "수금율 + 20%", 
                                                                "수금율 + 30%", 
                                                                "수금율 + 40%",
                                                                "수금율 + 77%"},  
                                                new float[] {1f, 1.1f, 1.2f, 1.3f, 1.4f, 1.77f}, "아이콘에 당황하셨죠?\n리액션을 열심히 합니다.");
        StreamerSkillVo Tamx24 = new StreamerSkillVo(14,skillIcons[14], "너무 커~버린 손녀", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
                                                new string[] {  "시청자 수 증가량 + 0%", 
                                                                "시청자 수 증가량 + 10%", 
                                                                "시청자 수 증가량 + 20%", 
                                                                "시청자 수 증가량 + 30%", 
                                                                "시청자 수 증가량 + 40%",
                                                                "시청자 수 증가량 + 77%"},  
                                                new float[] {1, 1.1f, 1.2f, 1.3f, 1.4f, 1.77f},"그녀는 계속 커집니다.\n 아, 신장을 말하는게 아닙니다.");

        StreamerSkillVo Nanayang0 = new StreamerSkillVo(15,skillIcons[15], "나테이커 효과", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
                                                new string[] {  "주식 하락율 0% 감소", 
                                                                "주식 하락율 1% 감소", 
                                                                "주식 하락율 2% 감소", 
                                                                "주식 하락율 3% 감소", 
                                                                "주식 하락율 4% 감소",
                                                                "주식 하락율 5% 감소"},  
                                                new float[] {0, 1, 2, 3, 4, 5}, "놀라지 마세요.\n 그녀의 게임실력 또한 현실입니다.");
        StreamerSkillVo Nanayang1 = new StreamerSkillVo(16,skillIcons[16], "사장님", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
                                                new string[] {  "주식 상승률 0% 증가", 
                                                                "주식 상승률 1% 증가", 
                                                                "주식 상승률 2% 증가", 
                                                                "주식 상승률 3% 증가", 
                                                                "주식 상승률 4% 증가",
                                                                "주식 상승률 5% 증가"},  
                                                new float[] {0, 1, 2f, 3f, 4, 5}, "사장님을 부릅니다.\n기업인의 힘을 보여주죠.");
        StreamerSkillVo Nanayang2 = new StreamerSkillVo(17,skillIcons[17], "Coke디렉터", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
                                                new string[] {  "주식 구매가격 0% 감소",
                                                                "주식 구매가격 2% 감소", 
                                                                "주식 구매가격 4% 감소", 
                                                                "주식 구매가격 6% 감소", 
                                                                "주식 구매가격 8% 감소",
                                                                "주식 구매가격 10% 감소"},  
                                                new float[] {1, 0.98f, 0.96f, 0.94f, 0.92f, 0.9f}, "Coke 디렉터입니다.\n 응원과 존경을 보냅니다.");
        StreamerSkillVo Nanayang3 = new StreamerSkillVo(18,skillIcons[18], "머찐나", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
                                                new string[] {  "주식 판매가격 0% 증가", 
                                                                "주식 판매가격 2% 증가", 
                                                                "주식 판매가격 4% 증가", 
                                                                "주식 판매가격 6% 증가", 
                                                                "주식 판매가격 8% 증가",
                                                                "주식 판매가격 10% 증가"},  
                                                new float[] {1, 1.02f, 1.04f, 1.06f, 1.08f, 1.1f}, "그녀는 머찝니다.\n카리스마가 거래를 성공으로 이끕니다.");
        StreamerSkillVo Nanayang4 = new StreamerSkillVo(19,skillIcons[19], "우주대스타", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
                                                new string[] {  "시청자 수 증가량 + 0%", 
                                                                "시청자 수 증가량 + 10%", 
                                                                "시청자 수 증가량 + 20%", 
                                                                "시청자 수 증가량 + 30%", 
                                                                "시청자 수 증가량 + 40%",
                                                                "시청자 수 증가량 + 77%"},  
                                                new float[] {1, 1.1f, 1.2f, 1.3f, 1.4f, 1.77f}, "우주에서 가장 빛나는 별입니다.\n 그녀를 모르는 우주인은 아마 없을겁니다.");

        skillList[0] = GoldSaHyang0;
        skillList[1] = GoldSaHyang1;
        skillList[2] = GoldSaHyang2;
        skillList[3] = GoldSaHyang3;
        skillList[4] = GoldSaHyang4;
        skillList[5] = Collet0;
        skillList[6] = Collet1;
        skillList[7] = Collet2;
        skillList[8] = Collet3;
        skillList[9] = Collet4;
        skillList[10] = Tamx20;
        skillList[11] = Tamx21;
        skillList[12] = Tamx22;
        skillList[13] = Tamx23;
        skillList[14] = Tamx24;
        skillList[15] = Nanayang0;
        skillList[16] = Nanayang1;
        skillList[17] = Nanayang2;
        skillList[18] = Nanayang3;
        skillList[19] = Nanayang4;
    }
}