using UnityEngine;
using System.Collections;
using DG.Tweening;

public class ItemMessagePanel : BasePanel 
{

    public void OnClosePanel()
    {
        UIManger.Instance.PopPanel();
    }

    public override void OnEnter()
    {
        cvsGrp.alpha = 1;
        cvsGrp.blocksRaycasts = true;

        transform.localScale = Vector3.zero;
        transform.DOScale(1, 0.5f);
    }

    public override void OnExit()
    {
//        cvsGrp.alpha = 0;
        cvsGrp.blocksRaycasts = false;

        transform.DOScale(0, 0.5f).OnComplete((() => cvsGrp.alpha = 0));
    }

}
