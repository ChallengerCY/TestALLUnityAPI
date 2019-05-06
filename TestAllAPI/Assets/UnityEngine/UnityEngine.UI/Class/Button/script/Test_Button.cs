using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_Button : MonoBehaviour
{
    /// <summary>
    /// 这个就是按钮在Inspector中的 OnClick部分
    /// </summary>
    public Button.ButtonClickedEvent onClik;

    public Button TestBtn;



    // Start is called before the first frame update
    void Start()
    {
        TestBtn.onClick.AddListener(()=> { ButtonClicked(42); } );
        TestBtn.onClick.AddListener(TaskOnClick);
        TestBtn.onClick.AddListener( delegate { TaskWithParameters("Hello"); });
        onClik.Invoke();
    }

   public void TaskOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the button!");
    }

    void ButtonClicked(int buttonNo)
    {
        //Output this to console when the Button3 is clicked
        Debug.Log("Button clicked = " + buttonNo);
    }

    public void TaskWithParameters(string message)
    {
        //Output this to console when the Button2 is clicked
        Debug.Log(message);
    }

    public void TaskWithParameters22(string message)
    {
        //Output this to console when the Button2 is clicked
        Debug.Log(message);
    }

}
