using System;
using UnityEngine;
using System.Collections.Generic;

public class UIManger
{
    private static UIManger _instance;
    public static UIManger Instance
    {
        get
        {
            if (_instance==null)
            {
                _instance=new UIManger();
            }
            return _instance;
        }
    }

    private Transform canvas;
    private Transform Canvas
    {
        get
        {
            if (canvas==null)
            {
                canvas = GameObject.Find("Canvas").transform;               
            }
            return canvas;
        }
    }
    private Dictionary<UIPanelType, string> panelPathDict;//存储所有的面板prefab的路径
    private Dictionary<UIPanelType, BasePanel> panelDict;//保存所有实例化面板的游戏物体身上的BasePanel组件
    private Stack<BasePanel> panelStack;

    //私有构造
    private UIManger()
    {
        ParseUIPanelTypeJosn();
    }

    //入栈，显示页面
    public void PushPanel(UIPanelType type)
    {
        if (panelStack==null)
        {
            panelStack=new Stack<BasePanel>();
        }

        if (panelStack.Count>0)
        {
            BasePanel topPanel = panelStack.Peek();
            topPanel.OnPause();
        }

        BasePanel panel = GetPanel(type);
        panel.OnEnter();
        panelStack.Push(panel);
    }

    //出栈，关闭页面
    public void PopPanel()
    {
        if (panelStack == null)
        {
            panelStack = new Stack<BasePanel>();
        }

        if (panelStack.Count <= 0) return;

        //关闭栈顶页面
        BasePanel topPanel1 = panelStack.Pop();
        topPanel1.OnExit();

        if (panelStack.Count <= 0) return;

        BasePanel topPanel2 = panelStack.Peek();
        topPanel2.OnResume();
    }

    //根据类型，获得面板
    private BasePanel GetPanel(UIPanelType type)
    {
        if (panelDict==null)
        {
            panelDict=new Dictionary<UIPanelType, BasePanel>();
        }

//        BasePanel panel;
//        panelDict.TryGetValue(type, out panel);//todo  

        BasePanel panel = panelDict.TryGet(type);

        if (panel==null)//如果找不到，实例一个并保存到字典
        {
//            string path;
//            panelPathDict.TryGetValue(type, out path);//todo

            string path = panelPathDict.TryGet(type);
            GameObject go = GameObject.Instantiate(Resources.Load(path)) as GameObject;
            go.transform.SetParent(Canvas, false);//todo
            panel = go.GetComponent<BasePanel>();
            panelDict.Add(type, panel);
        }

        return panel;
    }

    //Object类，用来解析Json数据
    [Serializable]
    class UIPanelTypeJson
    {
        public List<UIPanelInfo> infoList;
    }

    //得到面板路径
    private void ParseUIPanelTypeJosn()
    {
        panelPathDict = new Dictionary<UIPanelType, string>();

        TextAsset ta = Resources.Load<TextAsset>("UIPanelType");

        UIPanelTypeJson jsonObject = JsonUtility.FromJson<UIPanelTypeJson>(ta.text);

        foreach (UIPanelInfo info in jsonObject.infoList)
        {
            panelPathDict.Add(info.panelType,info.path);
        }
    }

    //测试
    public void Test()
    {
        string path;
        panelPathDict.TryGetValue(UIPanelType.MainMenu, out path);
        Debug.Log(path);
    }

}
