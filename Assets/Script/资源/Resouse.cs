using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resouse : MonoBehaviour
{
    [Header("四种基础资源")]
    public int wood;
    public int food;
    public int gold;
    public int weapon;
    [Header("四个对应文本框（不可更改）")]
    public Text woodText;
    public Text foodText;
    public Text goldText;
    public Text weaponText;

    [Header("已有建筑物列表（不可更改）")]
    public GameObject buildingManage;
    [Header("时间管理器（不可更改）")]
    public GameObject TimeManage;
    [Header("收货时间（每天几点）（可更改）")]
    public int hour;
    [Header("控制今天是否已收获资源（不可更改）")]
    public bool ifHarvest;
    [Header("重置上方ifHarvest的时间点（最好跟上面收货时间hour相差一个小时）（可更改）")]
    public int controlHarvestHour;

    public void OnEnable()
    {
        buildingManage = GameObject.Find("BuildingManage");
        TimeManage = GameObject.Find("Time");
        ifHarvest = false;
    }
    public void Update()
    {
        if(hour == TimeManage.GetComponent<TimeManage>().hour)
        {
            if(!ifHarvest)
            {
                wood += buildingManage.GetComponent<BuildingManage>().wood;
                food += buildingManage.GetComponent<BuildingManage>().food;
                gold += buildingManage.GetComponent<BuildingManage>().gold;
                weapon += buildingManage.GetComponent<BuildingManage>().weapon;
                ifHarvest = true;
            }
        }
        if(TimeManage.GetComponent<TimeManage>().hour == controlHarvestHour)
        {
            ifHarvest = false;
        }
        woodText.text = "木材：" + wood.ToString();
        foodText.text = "食物：" + food.ToString();
        goldText.text = "金币：" + gold.ToString();
        weaponText.text = "武器：" + weapon.ToString();
    }
    
    
}
