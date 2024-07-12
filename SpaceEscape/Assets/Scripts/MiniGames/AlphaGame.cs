using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaGame : MonoBehaviour
{
    public Button[] alphaButtons;
    Color clickedColor = new Color(100 / 255f, 100 / 255f, 100 / 255f, 1);

    void Start()
    {
        foreach (Button btn in alphaButtons)
        {
            btn.onClick.AddListener(() =>OnClickAlpha(btn.name));
        }
        
    }

    void OnClickAlpha(string alpha)
    {
        foreach (Button btn in alphaButtons)
        {
            if (btn.name.Equals(alpha))
            {
                if (btn.image.color == clickedColor)
                {
                    btn.image.color = Color.white;
                }
                else btn.image.color = clickedColor;
            }
        }
    }
}
