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

   [Header("木材每天生产数量")]
   public int wood;
   [Header("食物每天生产数量")]
   public int food;
   [Header("金币每天生产数量")]
   public int gold;
   [Header("武器每天生产数量")]
   public int weapon;

   [Header("血量")]
   public int hp;
   [Header("攻击力")]
   public int attack;
   [Header("防御力")]
   public int defence;

   [Header("资源仓库（不可更改）")]
   public GameObject resouse;
   [Header("金币所需数量")]
   public int needGold;


[Header("物品跟随鼠标（不可更改）")]
public bool isBuilding;
public Vector3 screenPosition;//将物体从世界坐标转换为屏幕坐标
public Vector3 mousePositionOnScreen;//获取到点击屏幕的屏幕坐标
public Vector3 mousePositionInWorld;//将点击屏幕的屏幕坐标转换为世界坐标
[Header("建造区域判断（不可更改）")]
public bool canBuild;
[Header("不可建造时颜色（可更改）")]
public Color disableColor;
[Header("初始颜色（可更改）")]
public Color originalColor;
[Header("碰撞体线条（不可更改）")]
public GameObject buildingMesh;
public GameObject buildingManage;
public bool buildingMeshActive;


   public void OnEnable()
   {
      
       MouseFollow();
       resouse = GameObject.Find("Resouse");
       buildingManage = GameObject.Find("BuildingManage");
       isBuilding = true;
       canBuild = true;
       

   }
    public void Update()
    {
        
        MouseFollow();
        SetBuilding();
        buildingMeshActive = buildingManage.GetComponent<BuildingManage>().buildingMeshActive;
        if(buildingMeshActive)
        {
            buildingMesh.SetActive(true);
        }
        if(!buildingMeshActive)
        {
            buildingMesh.SetActive(false);
        }
      
        
        
    } 
    public void MouseFollow()
   {
    if(isBuilding)
    {  
    mousePositionOnScreen = Input.mousePosition;
    mousePositionOnScreen.z = Mathf.Abs(Camera.main.transform.position.z);
    mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);  
    transform.position = mousePositionInWorld;
    buildingManage.GetComponent<BuildingManage>().buildingMeshActive = true;

       
        if(resouse.GetComponent<Resouse>().gold < needGold)
        {
             canBuild = false;
        }
        if(!canBuild)
        {
            gameObject.GetComponent<SpriteRenderer>().color = disableColor;
        }
        if(canBuild)
        {
            gameObject.GetComponent<SpriteRenderer>().color = originalColor;
        }
        

      if(Input.GetMouseButtonDown(1))//鼠标右击取消建造、后续可添加资源返回
      {
       
        buildingManage.GetComponent<BuildingManage>().buildingMeshActive = false;
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
               resouse.GetComponent<Resouse>().gold -= needGold;
               canBuild = false;
               isBuilding = false;
               buildingManage.GetComponent<BuildingManage>().buildingMeshActive = false;
              
               //gameObject.GetComponent<Image>().color = originalColor;
           }
           

       }
   }
   public void OnTriggerEnter2D(Collider2D other) 
   {
       if(isBuilding)
       {
       canBuild = false;
       }
   }
   public void OnTriggerStay2D(Collider2D other)
   {
       if(isBuilding)
       {
       canBuild = false;
       }
   }
   public void OnTriggerExit2D(Collider2D other) 
   {
       if(isBuilding)
       {
       canBuild = true;
       }
   }
}
