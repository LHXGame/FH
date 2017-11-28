using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class iconDrop : MonoBehaviour {

    public List<Texture2D> iconList = new List<Texture2D>();//图标列表
    //图标实例列表,长度需要足够用，取决于下落时间和间隔
    private List<GameObject> iconDropInstanceList = new List<GameObject>();
    private List<bool> isIconDropingList = new List<bool>();//图标是否正在下落的列表
    private int curIndex = 0;//图标实例列表当前使用的下标
    private GameObject iconDropPrefab;//图标prefab
    private int dropspeed = 100;//下落速度
    private int interTime = 1;//下落间隔
    private int minY = -800;//图标下落的下界
    private int rotateSpeed = 250;//旋转速度

    void Start()
    {
        iconDropPrefab = Resources.Load<GameObject>("Prefabs/start/iconDrop");
        foreach(var icon in iconList)
        {
            GameObject go = GameObject.Instantiate(iconDropPrefab, Vector3.zero, Quaternion.identity);
            go.transform.SetParent(transform, false);
            iconDropInstanceList.Add(go);
            isIconDropingList.Add(false);
        }
        InvokeRepeating("onIconDrop",0,interTime);
    }

	void Update () {
        for(int i = 0; i < isIconDropingList.Count ; i++)
        {
            if(isIconDropingList[i])
            {
                float dropY = dropspeed * Time.deltaTime;
                Vector3 pos = iconDropInstanceList[i].transform.localPosition;
                pos.y -= dropY;
                iconDropInstanceList[i].transform.localPosition = pos;
                //旋转
                iconDropInstanceList[i].transform.Rotate(transform.forward * rotateSpeed * Time.deltaTime);

                //低于下界，设置降落状态为false
                if (pos.y <= minY)
                    isIconDropingList[i] = false;
            }      
        }
	}

    /// <summary>
    /// 随机选择图标
    /// </summary>
    /// <returns>返回iconList下标</returns>
    private int rangeIcon()
    {
        return Random.Range(0, iconList.Count);
    }

    /// <summary>
    /// 图标开始下落
    /// </summary>
    private void onIconDrop()
    {
        int iconIndex = rangeIcon();
        if(curIndex < iconDropInstanceList.Count)
        {
            //动态加载图标显示
            iconDropInstanceList[curIndex].GetComponent<Image>().sprite = Resources.Load<Sprite>("Texture2D/" + iconList[iconIndex].name);
            //重置位置
            iconDropInstanceList[curIndex].transform.localPosition = Vector3.zero;
            //设置下落标记
            isIconDropingList[curIndex] = true;
        }
        curIndex = (curIndex + 1) % iconDropInstanceList.Count;
    }
}
