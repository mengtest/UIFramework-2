using UnityEngine;
using System.Collections;
using DG.Tweening;

public class KnapsackPanel : BasePanel 
{
    public void OnClosePanel()
    {
        UIManger.Instance.PopPanel();
    }

    public override void OnEnter()
    {
        cvsGrp.alpha = 1;
        cvsGrp.blocksRaycasts = true;

        Vector3 temp = transform.localPosition;
        temp.x = 600;
        transform.localPosition = temp;

        transform.DOLocalMoveX(0, 0.5f);
    }

    public override void OnPause()
    {
        cvsGrp.blocksRaycasts = false;//屏蔽点击事件
    }

    public override void OnResume()
    {
        cvsGrp.blocksRaycasts = true;
    }

    public override void OnExit()
    {
//        cvsGrp.alpha = 0;
        cvsGrp.blocksRaycasts = false;

        transform.DOLocalMoveX(-600, 0.5f).OnComplete(() => cvsGrp.alpha = 0);
    }

    public void OnItemBtnClick()
    {
        UIManger.Instance.PushPanel(UIPanelType.ItemMessage);
    }

}
