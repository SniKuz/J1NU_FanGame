using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamerSkillVo 
{
    public int _id;
    public Sprite _icon;
    public string _skillName;
    public int _level;
    public int[] _nextLevelGold; 
    public string _function;
    public string _skillIntroduce;

    public StreamerSkillVo(int id, Sprite icon, string skillName, int level, int[] nextLevelGold, string function, string skillIntroduce){
        _id = id;
        _icon = icon;
        _skillName = skillName;
        _level = level;
        _nextLevelGold = nextLevelGold;
        _function = function;
        _skillIntroduce = skillIntroduce;
    }
}
