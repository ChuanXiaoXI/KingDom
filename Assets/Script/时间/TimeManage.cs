using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManage : MonoBehaviour
{
   [Header("文本Object（不可更改）")]
   public Text timeUI;
   [Header("小时，（不可更改）")]
   public int hour;
   [Header("天数，（不可更改）")]
   public int day;
   [Header("时间流逝变量，（不可更改）")]
   public float second;
   [Header("小时时间系数，默认为2.5（每2.5s游戏变动1小时），系数越大，1个小时越长，（可更改）")]
   public float hourFactor;
   [Header("总体时间流逝系数，默认为1，越大时间流逝越快，（可更改）")]
   public float timeFactor;

   public void TimeDelta()
   {
       second += (Time.deltaTime * timeFactor);
        if(second >= hourFactor)//现实时间每2.5s算一个小时。可更改。
        {
            second= 0;
            hour += 1;
        }
        if(hour >= 24)
        {
            hour = 0;
            day += 1;
        }
        timeUI.text = "第" + day.ToString() + "天" + hour.ToString() + ":00";
        
   }
   public void Update()
   {
       TimeDelta();
   }

}
