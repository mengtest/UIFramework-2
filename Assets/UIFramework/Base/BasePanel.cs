using UnityEngine;
using System.Collections;

public class BasePanel : MonoBehaviour 
{

    protected CanvasGroup cvsGrp;

    void Awake()
    {
        cvsGrp = GetComponent<CanvasGroup>();

        if (cvsGrp == null)
        {
            cvsGrp = this.gameObject.AddComponent<CanvasGroup>();
        }
    }

    /// <summary>
    /// 界面被显示出来
    /// </summary>
    public virtual void OnEnter()
    {     
    }

    /// <summary>
    /// 界面暂停
    /// </summary>
    public virtual void OnPause()
    {
    }

    /// <summary>
    /// 界面恢复
    /// </summary>
    public virtual void OnResume()
    {
    }

    /// <summary>
    /// 关闭界面
    /// </summary>
    public virtual void OnExit()
    {
    }

}
