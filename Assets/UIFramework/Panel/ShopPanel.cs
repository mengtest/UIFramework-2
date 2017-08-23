using UnityEngine;
using System.Collections;

public class ShopPanel : BasePanel 
{
    public void OnClosePanel()
    {
        UIManger.Instance.PopPanel();
    }

    public override void OnEnter()
    {
        cvsGrp.alpha = 1;
        cvsGrp.blocksRaycasts = true;
    }

    public override void OnExit()
    {
        cvsGrp.alpha = 0;
        cvsGrp.blocksRaycasts = false;
    }
}
