using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManage : MonoBehaviour
{
   [Header("所有建筑物的生产总量（）")]
    public int wood;
    public int food;
    public int gold;
    public int weapon;

     [Header("碰撞体线条（不可更改）")]
     public bool buildingMeshActive;

  public void Harvest()
  {
      wood = 0;
      food = 0;
      gold = 0;
      weapon = 0;
      if(gameObject.transform.childCount != 0)
      {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            wood += gameObject.transform.GetChild(i).gameObject.GetComponent<BuildingObject>().wood;
            food += gameObject.transform.GetChild(i).gameObject.GetComponent<BuildingObject>().food;
            gold += gameObject.transform.GetChild(i).gameObject.GetComponent<BuildingObject>().gold;
            weapon += gameObject.transform.GetChild(i).gameObject.GetComponent<BuildingObject>().weapon;
        }
      }
  }
  public void Update()
  {
    Harvest();
  }    
}
