using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_disabledTrigger : MonoBehaviour
{
    /// <summary>
    /// 动画状态机
    /// </summary>
    public Animator buttonAnimator;
    /// <summary>
    /// 按钮
    /// </summary>
    public Button button;
    /// <summary>
    /// 动画类型
    /// </summary>
    public ButtonAnimationType buttonAnimationType;
    /// <summary>
    /// 是否开起轮播
    /// </summary>
    private bool startCarousel;
    /// <summary>
    /// 计时器
    /// </summary>
    private float timer;
    /// <summary>
    /// 动画状态索引
    /// </summary>
    private int stateIndex;

    /// <summary>
    /// 计时器终点时间
    /// </summary>
    private const float timeDestination = 0.5f;
    /// <summary>
    /// 动画类型枚举值的最大值
    /// </summary>
    private const int buttonAnimationTypeMaxValue = 4;


    void Start()
    {
        JudgeButtonAnimState(buttonAnimationType);
    }

    void Update()
    {
        if (startCarousel)
        {
            timer += Time.deltaTime;
            if (timer >= timeDestination)
            {
                stateIndex++;
                if (stateIndex > buttonAnimationTypeMaxValue)
                {
                    stateIndex = 0;
                }
                JudgeButtonAnimState((ButtonAnimationType)stateIndex);
                timer = 0;
            }
        }
    }

    /// <summary>
    /// 设置button的动画状态
    /// </summary>
    /// <param name="name">动画名称</param>
    private void SetButtonAnimState(string name)
    {
        //Sets the button state (Useful when making tutorials).
        buttonAnimator.SetTrigger(name);
    }


    /// <summary>
    /// 判断按钮的动画类型
    /// </summary>
    /// <param name="buttonAnimationType">动画类型</param>
    private void JudgeButtonAnimState(ButtonAnimationType buttonAnimationType)
    {
        switch (buttonAnimationType)
        {
            case ButtonAnimationType.All:
                startCarousel = true;
                break;
            case ButtonAnimationType.Normal:
                buttonAnimator.SetTrigger(button.animationTriggers.normalTrigger);
                break;
            case ButtonAnimationType.Highlighted:
                buttonAnimator.SetTrigger(button.animationTriggers.highlightedTrigger);
                break;
            case ButtonAnimationType.Pressed:
                buttonAnimator.SetTrigger(button.animationTriggers.pressedTrigger);
                break;
            case ButtonAnimationType.Disabled:
                buttonAnimator.SetTrigger(button.animationTriggers.disabledTrigger);
                break;
            default:
                break;
        }
    }
}


/// <summary>
/// 按钮动画状态类型枚举
/// </summary>
public enum ButtonAnimationType
{
    All,
    Normal,
    Highlighted,
    Pressed,
    Disabled,
}
