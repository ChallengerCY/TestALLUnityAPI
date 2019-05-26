using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMathf : MonoBehaviour
{
    public float deg = 30.0F;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        float rad = deg * Mathf.Deg2Rad;
        Debug.Log(deg + " degrees are equal to " + rad + " radians.");

        Debug.Log("Mathf.Epsilon is" + Mathf.Epsilon);

        Debug.Log("Mathf.Infinity is" + Mathf.Infinity);

        Debug.Log("Mathf.NegativeInfinity is" + Mathf.NegativeInfinity);

        Debug.Log("Mathf.PI is" + Mathf.PI);

        rad = 10.0f;
        float deg1 = rad * Mathf.Rad2Deg;
        Debug.Log(rad + " radians are equal to " + deg1 + " degrees.");

        Debug.Log("-1 的 绝对值是:" + Mathf.Abs(-1));

        Debug.Log("0.5f的反余弦值是:" + Mathf.Acos(0.5f));

        Debug.Log("1f = 1f ？" + Mathf.Approximately(1F, 1F));

        Debug.Log("0.5f的反正弦值是:" + Mathf.Asin(0.5f));

        Debug.Log("0.5f的反正切值是:" + Mathf.Atan(0.5f));

        Example();
    }


    /// <summary>
    /// 判断两个浮点数是否相等
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    bool isEqual(float a, float b)
    {
        if (a >= b - Mathf.Epsilon && a <= b + Mathf.Epsilon)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Update()
    {
        // shows the line that follows the ray.
        Debug.DrawLine(Vector3.zero, Vector3.forward * 100);
        if (Physics.Raycast(Vector3.zero, Vector3.forward, Mathf.Infinity))
        {
            print("There is something in front of the object!");
        }

        Vector3 relative = transform.InverseTransformPoint(target.position);
        float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
        transform.Rotate(0, angle, 0);

      //Debug.Log(Mathf.Clamp(Time.time, 0, 1))  ;
    }

    void Example()
    {
        // Prints 10
        Debug.Log(Mathf.Ceil(10.0F));
        // Prints 11
        Debug.Log(Mathf.Ceil(10.2F));
        // Prints 11
        Debug.Log(Mathf.Ceil(10.7F));
        // Prints -10
        Debug.Log(Mathf.Ceil(-10.0F));
        // Prints -10
        Debug.Log(Mathf.Ceil(-10.2F));
        // Prints -10
        Debug.Log(Mathf.Ceil(-10.7F));
    }
}
