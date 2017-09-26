using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameDataMasterTable : MasterTableBase<GameDataMaster>
{
    //private static readonly string FilePath = "GameData";
    private static readonly string URL = 
        "https://docs.google.com/spreadsheets/d/11owPBwoc1Pbpr0AP1crpBQ3qPW9Qrc1Nh_um2sj8Xn0/export?format=csv";

    public void Load() { CoroutineHandler.StartStaticCoroutine(LoadCourutine(URL)); }
}

public class GameDataMaster : MasterBase
{
    public override void Load(string[] elements)
    {
        UniqueID = int.Parse(elements[0]);
        Name = elements[1];
        Message = elements[2];
        EventID = int.Parse(elements[3]);
    }
    
    public int     UniqueID { get; private set; }   // ユニークなID
    public string  Name     { get; private set; }   // 話すキャラの名前 
    public string  Message  { get; private set; }   // 話すテキスト
    public int     EventID  { get; private set; }   // 生成するイベントID 
}
