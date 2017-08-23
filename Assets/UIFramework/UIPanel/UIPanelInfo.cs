using System;
using UnityEngine;
using System.Collections;

[Serializable]
public class UIPanelInfo:ISerializationCallbackReceiver
{
    [NonSerialized]
    public UIPanelType panelType;

    public string panelTypeString;
//    {    
//        get { return panelType.ToString(); }
//        set { panelType=(UIPanelType) Enum.Parse(typeof(UIPanelType), value); }
//    }
    public string path;

    //序列化，从对象到文本信息
    public void OnBeforeSerialize()
    {
        
    }

    //反序列化，从文本信息到对象
    public void OnAfterDeserialize()
    {
        panelType = (UIPanelType)Enum.Parse(typeof(UIPanelType), panelTypeString);
    }
}
