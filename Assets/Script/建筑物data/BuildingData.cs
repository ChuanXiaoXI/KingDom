using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "New Building", menuName =  "Building/New Building")]//创造新的选项
public class BuildingData : ScriptableObject
{
   [Header("建筑物名称（必选）")]
   public string buildingName;
   [Header("建筑物UI图片（必选）")]
   public Sprite buildingPicture;
   [Header("建筑物实物图片（必选）")]
   public Sprite buildingObjectPicture;
   [Header("建筑物种类（resousesBuilding/defensiveBuilding）(二选一)")]
   public string buildingClass;
   [Header("建筑物建造消耗的资源（可选）")] 
   [Header("木材消耗数量")]
   public int woodConsumption;
   [Header("食物消耗数量")]
   public int foodConsumption;
   [Header("金币消耗数量")]
   public int goldConsumption;
   [Header("武器消耗数量")]
   public int weaponConsumption;
   
   [Header("资源性建筑资源（resousesBuilding选项）")]
   [Header("木材每天生产数量")]
   public int wood;
   [Header("食物每天生产数量")]
   public int food;
   [Header("金币每天生产数量")]
   public int gold;
   [Header("武器每天生产数量")]
   public int weapon;

   [Header("防御建筑属性（defensiveBuilding选项）")]
   [Header("血量")]
   public int hp;
   [Header("攻击力")]
   public int attack;
   [Header("防御力")]
   public int defence;
}
