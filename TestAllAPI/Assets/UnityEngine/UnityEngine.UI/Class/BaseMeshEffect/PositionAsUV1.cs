using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PositionAsUV1 : BaseMeshEffect
{


    protected PositionAsUV1()
    {

    }

    protected override void Start()
    {
        StartCoroutine(enumerator());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mesh"></param>
    public override void ModifyMesh(Mesh mesh)
    {
        if (!IsActive())
            return;

        var verts = mesh.vertices.ToList();
        List<Vector2> uvs = new List<Vector2>();

        for (int i = 0; i < verts.Count - 1; i++)
        {
            var vert = verts[i];
            uvs.Add(new Vector2(verts[i].x, verts[i].y));
            verts[i] = vert;
        }
        mesh.SetUVs(1, uvs);
        this.gameObject.GetComponent<CanvasRenderer>().SetMesh(mesh);
        uvs.Clear();
    }

    private void Update()
    {
        Debug.LogError(2);
        //ModifyMesh(new Mesh());
    }

    public override void ModifyMesh(VertexHelper vh)
    {

        //Debug.LogError("当前在缓冲区中的顶点数: "+vh.currentVertCount);
        //Debug.LogError("当前VertexHelper结构中的顶点索引数: " + vh.currentIndexCount);    
    }

    IEnumerator enumerator()
    {
        yield return new WaitForEndOfFrame();

        Debug.LogError(1);
        ModifyMesh(new Mesh());
    }
}
