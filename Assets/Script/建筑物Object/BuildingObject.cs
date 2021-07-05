using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;




public class BuildingObject : MonoBehaviour
{
   //[Header("建筑物种类(不可更改)")]
   //public BuildingData buildingData;
   //[Header("建筑物名称(不选，根据第一选项变换)")]
   //public string buildingName;
   [Header("建筑物实物图片(不选)")]
   public SpriteRenderer buildingObjectPicture;
   //[Header("建筑物种类(不选，根据第一选项变换)")]
   //public string buildingClass;
   //public Camera camera;
   
   [Header("资源性建筑资源(可选)")]
   [Header("木材每天生产数量")]
   public int wood;
   [Header("食物每天生产数量")]
   public int food;
   [Header("金币每天生产数量")]
   public int gold;
   [Header("武器每天生产数量")]
   public int weapon;

   [Header("防御建筑属性(可选)")]
   [Header("血量")]
   public int hp;
   [Header("攻击力")]
   public int attack;
   [Header("防御力")]
   public int defence;

[Header("物品跟随鼠标（不可更改）")]
public bool isBuilding;
public Vector3 screenPosition;//将物体从世界坐标转换为屏幕坐标
public Vector3 mousePositionOnScreen;//获取到点击屏幕的屏幕坐标
public Vector3 mousePositionInWorld;//将点击屏幕的屏幕坐标转换为世界坐标
[Header("建造区域判断（不可更改）")]
public bool canBuild;

   public void OnEnable()
   {
       MouseFollow();
       isBuilding = true;
       canBuild = true;
       
       /*buildingName = buildingData.buildingName;
       buildingObjectPicture.sprite = buildingData.buildingObjectPicture;
       buildingClass = buildingData.buildingClass;

       wood = buildingData.wood;
       food = buildingData.food;
       gold = buildingData.gold;
       weapon = buildingData.weapon;

       hp = buildingData.hp;
       attack = buildingData.attack;
       defence = buildingData.defence;*/
       //以上皆为属性传值

   }
    public void Update()
    {
        
        MouseFollow();
        SetBuilding();
        
        
    } 
    public void MouseFollow()
   {
    if(isBuilding)
    {
    //获取鼠标在场景中坐标
    mousePositionOnScreen = Input.mousePosition;
    mousePositionOnScreen.z = Mathf.Abs(Camera.main.transform.position.z);
    //获取鼠标在相机中（世界中）的位置，转换为屏幕坐标；
    //screenPosition = Camera.main.WorldToScreenPoint(mousePositionOnScreen);
    //transform.position = 
    //将相机中的坐标转化为世界坐标
    mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);
    //物体跟随鼠标移动
    transform.position = mousePositionInWorld;
    

      if(Input.GetMouseButtonDown(1))//鼠标右击取消建造、后续可添加资源返回
      {
        Destroy(gameObject);
      }
    }
    
   }
   public void SetBuilding()
   {
       if(Input.GetMouseButtonDown(0))//鼠标左击
       {
           if(canBuild)//处于可建造区域
           {
               //transform.position = mousePositionInWorld;
               isBuilding = false;
           }

       }
   }
   public void OnTriggerEnter2D(Collider2D other) 
   {
       canBuild = false;
   }
   public void OnTriggerStay2D(Collider2D other)
   {
       canBuild = false;
   }
   public void OnTriggerExit2D(Collider2D other) 
   {
       canBuild = true;
   }
}
