using UnityEngine;
using System.Collections;
using DG.Tweening;

public class TaskPanel : BasePanel 
{

    public void OnClosePanel ()
    {
        UIManger.Instance.PopPanel();
    }

    public override void OnEnter()
    {
//        cvsGrp.alpha = 1;
        cvsGrp.blocksRaycasts = true;

        cvsGrp.DOFade(1, 0.5f);
    }

    public override void OnExit()
    {
//        cvsGrp.alpha = 0;
        cvsGrp.blocksRaycasts = false;

        cvsGrp.DOFade(0, 0.5f);
    }
}
