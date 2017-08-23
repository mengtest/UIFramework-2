using System;
using UnityEngine;
using System.Collections;

public class MainMenuPanel : BasePanel
{
    void Start()
    {
        cvsGrp = GetComponent<CanvasGroup>();
    }

    public override void OnEnter()
    {
        cvsGrp.alpha = 1;
        cvsGrp.blocksRaycasts = true;
    }

    public override void OnPause()
    {
        cvsGrp.blocksRaycasts = false;//屏蔽点击事件
    }

    public override void OnResume()
    {
        cvsGrp.blocksRaycasts = true;
    }

    public void OnPushPanel(string typeString)
    {
        UIPanelType type = (UIPanelType)Enum.Parse(typeof(UIPanelType), typeString);
        UIManger.Instance.PushPanel(type);
    }
}
