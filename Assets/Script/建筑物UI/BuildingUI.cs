using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class BuildingUI : MonoBehaviour
{
 //[Header("建筑物种类(必选)")]
 //public BuildingData buildingData;
 [Header("建筑物名字和图片(必选)")]
 public Text buildingName;
 public Image buildingPicture;
 [Header("建筑物ObjectPrefab(必选)")]
 public GameObject buildingPrefab;
 [Header("建筑物Manage(不可更改)")]
 public GameObject buildingManage;

 
 public void OnEnable()
 {
     buildingManage = GameObject.Find("BuildingManage");
     //buildingName.text = buildingData.buildingName;
     //buildingPicture.sprite = buildingData.buildingPicture;
    
 }
 public void OnMouseDown()
 {
    // buildingPrefab.GetComponent<BuildingObject>().buildingData = buildingData;
    Instantiate(buildingPrefab).transform.parent = buildingManage.transform;
    
    
 }

}
