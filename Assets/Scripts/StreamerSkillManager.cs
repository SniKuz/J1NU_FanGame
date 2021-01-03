using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamerSkillManager : MonoBehaviour
{
    public Sprite[] skillIcons; //Skill Icons. 여기다 넣어서 아이콘 바꿈.
    StreamerSkillVo[] skillList;

    
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
        new string[6] {"시청자 수 증가량 + 10%", "", "", "", "", ""},  "치명적인 귀여움을 뽑냅니다");
        StreamerSkillVo GoldSaHyang1 = new StreamerSkillVo(1,skillIcons[1], "질러팅", 0, new int[5] {1000, 3000, 50000, 10000, 20000}, 
        new string[6] {"시청자 수 증가량 + 10%", "", "", "", "",""},  "질러팅을 진행할 확률이 증가합니다");
        StreamerSkillVo GoldSaHyang2 = new StreamerSkillVo(2,skillIcons[2], "숏과 까미", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
        new string[6] {"시청자 수 증가량 + 10%", "", "", "", "",""},  "숏과 까미가 귀엽습니다."); // 막라 난이도 낮추는 용으로 괜찮은듯
        StreamerSkillVo GoldSaHyang3 = new StreamerSkillVo(3,skillIcons[3], "굿즈생산", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
        new string[6] {"시청자 수 증가량 + 10%", "", "", "", "",""},  "새로운 굿즈를 만듭니다.");
        StreamerSkillVo GoldSaHyang4 = new StreamerSkillVo(4,skillIcons[4], "지모노", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
        new string[6] {"시청자 수 증가량 + 10%", "", "", "", "",""},  "지모노");

        StreamerSkillVo Collet0 = new StreamerSkillVo(5,skillIcons[5], "C++ 개발자", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
        new string[6] {"터치 효율 증가 0->10%", "터치 효율 증가 10->20%", "터치 효율 증가 20->30%", "터치 효율 증가 30->40%", "터치 효율 증가 40->50%","터치 효율 증가 50%"},  
        "C++ 개발을 착수합니다\n 굿즈 개발 기기의 효율이 올라갑니다.");
        StreamerSkillVo Collet1 = new StreamerSkillVo(6,skillIcons[6], "코정치", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
        new string[6] {"모든 일반스킬 효율 0->1%", "모든 일반스킬 효율 1->2%", "모든 일반스킬 효율 2->3%", "모든 일반스킬 효율 3->4%", "모든 일반스킬 효율 4->5%","모든 일반스킬 효율 5%"},  
        "훌륭한 정치력을 가지고있습니다.\n이를 올바른데 사용하기 시작합니다.");
        StreamerSkillVo Collet2 = new StreamerSkillVo(7,skillIcons[7], "샤샤님과 합방", 0, new int[5] {1000, 3000, 0000, 10000, 20000}, 
        new string[6] {"격주마다 시청자 수 + 0->100", "격주마다 시청자 수 + 100->200", "격주마다 시청자 수 + 200->300", "격주마다 시청자 수 + 300->400", "격주마다 시청자 수 + 400->500","격주마다 시청자 수 + 500"},  
        "2주의 한 번씩 머기업 샤샤님과 합방을 진행합니다.");
        StreamerSkillVo Collet3 = new StreamerSkillVo(8,skillIcons[8], "뱅", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
        new string[6] {"3% 확률로 0->1뱅 획득", "3% 확률로 1->2뱅 획득", "3% 확률로 2->3뱅 획득", "3% 확률로 3->4뱅 획득", "3% 확률로 4->5뱅 획득","3% 확률로 5뱅 획득"},  
        "극악의 확률로 하루가 지날 때 레벨에 따른 뱅을 얻습니다.\n*1뱅은 3천5백만입니다.");//1뱅 = 35000000
        StreamerSkillVo Collet4 = new StreamerSkillVo(9,skillIcons[9], "수숭과 줴자", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
       new string[6] {"시청자 수 증가량 + 10%", "", "", "", "",""},  "줴자는 수숭에게 가르침을 받습니다.");

        StreamerSkillVo Tamx20 = new StreamerSkillVo(10,skillIcons[10], "나도 알아 내가 귀여운거", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
        new string[6] {"시청자 수 증가량 + 10%", "", "", "", "",""},  
        "자신의 귀여움을 인정합니다. 미션을 성공합니다.");
        StreamerSkillVo Tamx21 = new StreamerSkillVo(11,skillIcons[11], "밀감이", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
       new string[6] {"시청자 수 증가량 + 10%", "", "", "", "",""},  "밀감이를 보신적이 있으십니까?\n 그 촉감, 움직임, 당신은 헤어나오지 못할겁니다.");
        StreamerSkillVo Tamx22 = new StreamerSkillVo(12,skillIcons[12], "JMT", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
        new string[6] {"모든 주식 하락률 0->1% 감소", "모든 주식 하락률 1->2% 감소", "모든 주식 하락률 2->3% 감소", "모든 주식 하락률 3->4% 감소", "모든 주식 하락률 4->5% 감소","모든 주식 하락률 5% 감소"},  
        "DO you know JMT?\n그녀의 실력은 주식시장이 배려할 정도입니다.");
        StreamerSkillVo Tamx23 = new StreamerSkillVo(13,skillIcons[13], "감사링~ 감사띠~", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
       new string[6] {"수금율 + 0->10%", "수금율 + 10->20%", "수금율 + 20->30%", "수금율 + 30->40%", "수금율 + 40->50%","수금율 + 50%"},  
       "아이콘에 당황하셨죠?\n리액션을 열심히 합니다.");
        StreamerSkillVo Tamx24 = new StreamerSkillVo(14,skillIcons[14], "너무 커~버린 손녀", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
        new string[6] {"시청자 수 증가량 + 10%", "", "", "", "",""},  "그녀는 계속 커집니다.\n 아, 신장을 말하는게 아닙니다.");

        StreamerSkillVo Nanayang0 = new StreamerSkillVo(15,skillIcons[15], "나테이커 효과", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
       new string[6] {"시청자 수 증가량 + 10%", "", "", "", "",""},  "놀라지 마세요.\n 그녀의 게임실력 또한 현실입니다.");
        StreamerSkillVo Nanayang1 = new StreamerSkillVo(16,skillIcons[16], "사장님", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
       new string[6] {"모든 주식 상승률 0->1%", "모든 주식 상승률 1->2%", "모든 주식 상승률 2->3%", "모든 주식 상승률 3->4%", "모든 주식 상승률 4->5%","모든 주식 상승률 5%"},  
       "사장님을 부릅니다.\n기업인의 힘을 보여주죠.");
        StreamerSkillVo Nanayang2 = new StreamerSkillVo(17,skillIcons[17], "Coke디렉터", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
       new string[6] {"시청자 수 증가량 + 10%", "", "", "", "",""},  "Coke 디렉터입니다.\n 응원과 존경을 보냅니다.");
        StreamerSkillVo Nanayang3 = new StreamerSkillVo(18,skillIcons[18], "머찐나", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
        new string[6] {"시청자 수 증가량 + 10%", "", "", "", "",""},  "그녀는 머찝니다.\n카리스마로 굿즈 디자인 효율이 증가합니다.");
        StreamerSkillVo Nanayang4 = new StreamerSkillVo(19,skillIcons[19], "우주대스타", 0, new int[5] {1000, 3000, 5000, 10000, 20000}, 
        new string[6] {"시청자 수 증가량 + 0->30%", "시청자 수 증가량 + 30->50%", "시청자 수 증가량 + 50->70%", "시청자 수 증가량 + 70->90%", "시청자 수 증가량 + 90->120%","시청자 수 증가량 + 120%"},  
        "우주에서 가장 빛나는 별입니다.\n 그녀를 모르는 우주인은 없을겁니다.");

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