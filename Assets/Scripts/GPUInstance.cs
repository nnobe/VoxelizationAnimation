using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPUInstance : MonoBehaviour
{

    public static GPUInstance instance;
    private void Awake()
    {
        instance = this;
        matrices = new List<Matrix4x4>();
        positions = new List<Vector3>();
        scales = new List<float>();
    }


    //用于设置包含位置，缩放，旋转信息的矩阵
    public List<Matrix4x4> matrices ;

    public List<Vector3> positions ;
    public List<float> scales ;

    public Mesh pixCube;
    public Material pixCubeMT;
    public float scale = 0f;

    void GeneratePixCube()
    {
        matrices.Clear();
        positions.Clear();
        scales.Clear();
        if (positions.Count != scales.Count)
        {
            Debug.Log("数据不匹配");
            return;
        }
        int count = positions.Count;
        for (int i = 0; i < count; i++)
        {
            //scale = 0;
            matrices.Add(Matrix4x4.TRS(positions[i], Quaternion.identity,Vector3.one* scales[i]));
        }
        Debug.Log("正在批处理");
        Graphics.DrawMeshInstanced(pixCube, 0, pixCubeMT, matrices);
    }
    private void Update()
    {
        GeneratePixCube();
    }
}
