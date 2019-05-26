using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMathClamp : MonoBehaviour
{
    private float xMin = -1.0f, xMax = 1.0f;
    private float timeValue = 0.0f;

    public int health = 17;
    private int[] healthUp = new int[] { 25, 10, 5, 1 };
    private int[] healthDown = new int[] { -10, -5, -2, -1 };

    // Width and height for the buttons.
    private int xButton = 75;
    private int yButton = 50;

    // Place of the top left button.
    private int xPos1 = 50, yPos1 = 100;
    private int xPos2 = 125, yPos2 = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        // Compute the sin position.
        float xValue = Mathf.Sin(timeValue * 5.0f);

        // Now compute the Clamp value.
        float xPos = Mathf.Clamp(xValue, xMin, xMax);

        // Update the position of the cube.
        transform.position = new Vector3(xPos, 0.0f, 0.0f);

        // Increase animation time.
        timeValue = timeValue + Time.deltaTime;

        // Reset the animation time if it is greater than the planned time.
        if (xValue > Mathf.PI * 2.0f)
        {
            timeValue = 0.0f;
        }
    }

    void OnGUI()
    {
        // Let the minimum and maximum values be changed
        xMin = GUI.HorizontalSlider(new Rect(25, 25, 100, 30), xMin, -1.0f, +1.0f);
        xMax = GUI.HorizontalSlider(new Rect(25, 60, 100, 30), xMax, -1.0f, +1.0f);

        // xMin is kept less-than or equal to xMax.
        if (xMin > xMax)
        {
            xMin = xMax;
        }

        // Display the xMin and xMax value with better size labels.
        GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("label"));
        fontSize.fontSize = 24;

        GUI.Label(new Rect(135, 10, 150, 30), "xMin: " + xMin.ToString("f2"), fontSize);
        GUI.Label(new Rect(135, 45, 150, 30), "xMax: " + xMax.ToString("f2"), fontSize);



        GUI.skin.button.fontSize = 20;

        // Generate and show positive buttons.
        for (int i = 0; i < healthUp.Length; i++)
        {
            if (GUI.Button(new Rect(xPos1, yPos1 + i * yButton, xButton, yButton), healthUp[i].ToString()))
            {
                health += healthUp[i];
            }
        }

        // Generate and show negative buttons.
        for (int i = 0; i < healthDown.Length; i++)
        {
            if (GUI.Button(new Rect(xPos2, yPos2 + i * yButton, xButton, yButton), healthDown[i].ToString()))
            {
                health += healthDown[i];
            }
        }

        // Show health between 1 and 100.
        health = Mathf.Clamp(health, 1, 100);
        GUI.Label(new Rect(xPos1, xPos1, 2 * xButton, yButton), "Health: " + health.ToString("D3"));
    }
}
