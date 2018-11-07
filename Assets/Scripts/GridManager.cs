using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridManager : MonoBehaviour {

    //待渲染的位置和对应缩放
    public Dictionary<Vector3, float> cubesDic;
    public float size=0.1f;

    public List<Matrix4x4> matrixs;
    public Mesh meshToInstance;
    public Material materialToInstance;

    LoaclTestPoints loaclTestPoints;

    private void Awake()
    {
        cubesDic = new Dictionary<Vector3, float>();
        matrixs = new List<Matrix4x4>();
        loaclTestPoints=FindObjectOfType<LoaclTestPoints>();
    }
    //获取量化网格位置
    public Vector3 GetNearestPointOnGrid(Vector3 pos)
    {
        int nearPoxX = Mathf.RoundToInt(pos.x / size);
        int nearPoxY = Mathf.RoundToInt(pos.y / size);
        int nearPoxZ = Mathf.RoundToInt(pos.z / size);

        return new Vector3((float)nearPoxX * size, (float)nearPoxY * size, (float)nearPoxZ * size);
    }
    private void Update()
    {
        cubesDic.Clear();
        loaclTestPoints.GetTestPoints();
        matrixs.Clear();
        foreach (var cube in cubesDic)
        {
            var mat = Matrix4x4.TRS(cube.Key, Quaternion.identity, Vector3.one* size);
            matrixs.Add(mat);
        }
        Graphics.DrawMeshInstanced(meshToInstance, 0, materialToInstance, matrixs);
    }
    public void AddCube(Vector3 pos)
    {
        var gridPoint = GetNearestPointOnGrid(pos);
        cubesDic.Add(gridPoint, size);      
    }
}
