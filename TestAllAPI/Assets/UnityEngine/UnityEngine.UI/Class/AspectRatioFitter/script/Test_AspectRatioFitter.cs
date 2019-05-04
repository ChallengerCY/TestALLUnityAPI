using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_AspectRatioFitter : MonoBehaviour
{
    /// <summary>
    /// 长宽比例裁剪
    /// </summary>
    public AspectRatioFitter aspectRatioFitter;

    /// <summary>
    /// 用于显示当前的长宽比例
    /// </summary>
    public Text aspectRatioText;

    /// <summary>
    /// 说明性文字
    /// </summary>
    private const string cs = "AspectRatio: ";

    /// <summary>
    /// 速度比率
    /// </summary>
    private const float speedRatio = 0.5f;

    /// <summary>
    /// 用于控制状态的反转
    /// </summary>
    private bool increase;

    // Update is called once per frame
    void Update()
    {
        if (aspectRatioFitter.aspectRatio >= 2)
        {
            increase = false;

        }
        else if (aspectRatioFitter.aspectRatio <= 0)
        {
            increase = true;

        }

        if (increase)
        {
            aspectRatioFitter.aspectRatio += Time.deltaTime * speedRatio;

        }
        else
        {
            aspectRatioFitter.aspectRatio -= Time.deltaTime * speedRatio;
        }

        ///这里仅用于显示说明，实际项目慎用
        aspectRatioText.text = cs + aspectRatioFitter.aspectRatio.ToString();
    }
}
