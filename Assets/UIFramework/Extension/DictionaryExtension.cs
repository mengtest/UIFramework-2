using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//对Dictionary的扩展
public static class DictionaryExtension
{
    /// <summary>
    /// 尝试根据key得到value
    /// </summary>
    public static Tvalue TryGet<Tkey, Tvalue>(this Dictionary<Tkey, Tvalue> dict, Tkey key)
    {
        Tvalue value;
        dict.TryGetValue(key, out value);
        return value;
    }
}
