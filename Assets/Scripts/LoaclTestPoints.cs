using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaclTestPoints : MonoBehaviour {

    public List<Vector3> localPoints;
    public Transform pointsParent;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public float testStep;

    GridManager gm;
    Mesh mesh;
    MeshCollider meshCollider;

    public float lengthX;
    public float lengthY;
    public float lengthZ;
    private void Awake()
    {
        
        gm = FindObjectOfType<GridManager>();
        mesh = new Mesh();
        meshCollider = GetComponent<MeshCollider>();
    }

    [ContextMenu("生成本地测试点")]
    void GeneratePoints()
    {
        localPoints = new List<Vector3>();
        var size = skinnedMeshRenderer.sharedMesh.bounds.extents;
        var pos = transform.position;

        for (float i = pos .x- lengthX/2; i < pos.x+ lengthX / 2; i+= testStep)
        {
            for (float j = pos.y; j < pos.y+ 2*lengthY; j += testStep)
            {
                for (float k = pos.z - lengthZ/ 2; k < pos.z+ lengthZ / 2; k += testStep)
                {
                    localPoints.Add(new Vector3(i, j, k));
                }
            }
        }

    }
    [ContextMenu("清除本地测试点")]
    void ClearTestPoints()
    {
        localPoints.Clear();
    }
    void TestPointsIsInMeshCollider()
    {
        for (int i = 0; i < localPoints.Count; i++)
        {
            var pos = transform.TransformPoint(localPoints[i]);
            if (Physics.OverlapSphere(pos, 0.01f).Length > 0)
            {
                Debug.Log("测试点");

                gm.AddCube(pos);
                    
            }
        }
    }

    public void GetTestPoints()
    {
        skinnedMeshRenderer.BakeMesh(mesh);
        meshCollider.sharedMesh = mesh;
        TestPointsIsInMeshCollider();
    }
}
