using UnityEngine;
using System.Collections;

public class UIRoot : MonoBehaviour 
{

	void Start () 
	{
	    UIManger.Instance.PushPanel(UIPanelType.MainMenu);
	}
}
