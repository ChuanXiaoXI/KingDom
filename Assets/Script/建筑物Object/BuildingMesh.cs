using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class BuildingMesh : MonoBehaviour 
{
     public PolygonCollider2D collider;
     public Vector3[] ptsArr1 = new Vector3[10];
     public Vector2[] colliderPath;

     //public Vector3[] ptsArr2 = new Vector3[6];

    //public GameObject obj = new GameObject("cube");
    //public MeshFilter mf = obj.AddComponent<MeshFilter>();
    //public MeshRenderer mr = obj.AddComponent<MeshRenderer>();

   void Start()
{
    //ptsArr1 = new Vector3[colliderPath.Length];
   // ptsArr1 = collider.Points;
   //List<Vector2> colliderPath = GetColliderPath(pointList);
   // collider.SetPath(0, ptsArr1.ToArray());
   colliderPath = collider.GetPath(0);
   ptsArr1 = new Vector3[colliderPath.Length];
   //ptsArr1.Length = 5;
   for(int i = 0; i < colliderPath.Length; i++)
   {
      ptsArr1[i] = new Vector3(colliderPath[i].x , colliderPath[i].y , 0);
      //ptsArr1.Add();

   }
        

}
	void Update () 
    {
        //GameObject obj = new GameObject("cube");
        MeshFilter mf = gameObject.AddComponent<MeshFilter>();
        MeshRenderer mr = gameObject.AddComponent<MeshRenderer>();
        //mr.sharedMaterial = Resources.Load<Material>("Mat1");
 
       /* Vector3[] ptsArr1 = new Vector3[5];
        ptsArr1[0].Set(0.0f, 0.0f, 0.0f);
        ptsArr1[1].Set(0.0f, 1.0f, 0.0f);
        ptsArr1[2].Set(3.0f, 1.0f, 0.0f);
        ptsArr1[3].Set(3.0f, 0.0f, 0.0f);
        ptsArr1[4].Set(0.0f, 0.0f, 0.0f);
 
        Vector3[] ptsArr2 = new Vector3[6];
        ptsArr2[0].Set(4.0f, 0.0f, 0.0f);
        ptsArr2[1].Set(4.0f, 2.0f, 0.0f);
        ptsArr2[2].Set(6.0f, 2.0f, 0.0f);
        ptsArr2[3].Set(10.0f, -1.0f, 0.0f);
        ptsArr2[4].Set(8.0f, -0.5f, 0.0f);
        ptsArr2[5].Set(4.0f, 0.0f, 0.0f);*/
 
        List<int> indices1 = new List<int>();
        CalIndices(ptsArr1, 0, indices1);
        //Debug.Log(indices1);
 
        //List<int> indices2 = new List<int>();
        //CalIndices(ptsArr2, ptsArr1.Length, indices2);
        //Debug.Log(indices2);
 
        List<int> indicesTotal = new List<int>();
        indicesTotal.AddRange(indices1);
        //indicesTotal.AddRange(indices2);
 
        List<Vector3> ptsTotal = new List<Vector3>();
        ptsTotal.AddRange(ptsArr1);
        //ptsTotal.AddRange(ptsArr2);
 
        mf.mesh.vertices = ptsTotal.ToArray();
        mf.mesh.SetIndices(indicesTotal.ToArray(), MeshTopology.Lines, 0);
    }
 
    void CalIndices(Vector3[] ptsArr, int startIndex, List<int> indiceArr)
    {
        //int[] indiceArr1 = new int[2 * ptsArr.Length];
        int k = 0;
        for (int i = startIndex; i < startIndex + ptsArr.Length - 1; i++)
        {
            indiceArr.Add(i);
            indiceArr.Add(i+1);
        }
 
        indiceArr.Add(startIndex + ptsArr.Length - 1);
        indiceArr.Add(startIndex);
    }

}

