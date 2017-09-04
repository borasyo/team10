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
        int id = 0;
        int.TryParse(elements[0], out id);
        ID = id;

        int eventId = 0;
        int.TryParse(elements[1], out eventId);
        EventID = eventId;

        Name = elements[2];
        Text = elements[3];
    }

    public int ID { get; private set; }         // 連番で割り振られるユニークな番号
    public int EventID { get; private set; }    // 生成するイベントID 
    public string Name { get; private set; }    // 話すキャラの名前 
    public string Text { get; private set; }    // 話すテキスト
}
