using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventVo 
{
    public int _id;
    public int _day;
    public string _title;
    public string _content;
    public int _btnIndex;
    public string[] _btnText;
    public EventVo(int id, int day, string title, string content,int btnindex, string[] btnText){
        _id = id;
        _day = day;
        _title = title;
        _content = content;
        _btnIndex = btnindex;
        _btnText = btnText;
    }
}
