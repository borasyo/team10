using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataMasterTable : MasterTableBase<GameDataMaster>
{
    private static readonly string FilePath = "GameData";
    public void Load() { Load(FilePath); }
}

public class GameDataMaster : MasterBase
{
    public override void Load(string[] elements)
    {
        Name = elements[0];
        Message = elements[1];

        int eventId = 0;
        int.TryParse(elements[2], out eventId);
        EventID = eventId;
    }
    
    public string  Name    { get; private set; }    // 話すキャラの名前 
    public string  Message { get; private set; }    // 話すテキスト
    public int     EventID { get; private set; }    // 生成するイベントID 
}
