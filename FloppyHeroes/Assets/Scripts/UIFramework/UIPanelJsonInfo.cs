using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class UIPanelJsonInfo :ISerializationCallbackReceiver{
   [NonSerialized]
    public UIPanelType panelEnumType; //枚举类型不能直接从json文件转过来,要使用接口
    public string panelType;
    public string path;

    //反序列化，将json文件信息转到对象
    public void OnAfterDeserialize()
    {
        panelEnumType = (UIPanelType)System.Enum.Parse(typeof(UIPanelType), panelType);
    }

    public void OnBeforeSerialize()
    {
        
    }
}
