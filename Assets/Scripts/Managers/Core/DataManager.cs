using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class DataManager
{
    public Dictionary<string, Data.Unit> UnitDict { get; private set; } = new Dictionary<string, Data.Unit>();

    public void Init()
    {
        UnitDict = LoadJson<Data.UnitData, string, Data.Unit>("UnitData").MakeDict();
    }
    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/{path}");
        Loader data = JsonConvert.DeserializeObject<Loader>(textAsset.text);
        return data;
    }
}
