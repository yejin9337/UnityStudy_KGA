using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVTable : MonoBehaviour
{
    private static CSVTable _instance = null;
    public static CSVTable Instance
    {
        get
        {
            if( _instance == null )
            {
                GameObject obj = new GameObject();
                _instance = obj.AddComponent<CSVTable>();
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _table["NormalDamage"] = 10;
        _table["FireDamage"] = 5;
        _table["PoisonDamage"] = 3;
    }

    Dictionary<string, int> _table;

    public int Get(string key)
    {
        if (_table.TryGetValue(key, out int result))
        {
            return result;
        }
        Debug.LogError($"해당 key({key}) 없음");
        return -1;
    }
}
