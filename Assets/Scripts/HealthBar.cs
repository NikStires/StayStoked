using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static Image img1;
    public static Image img2;
    public static Image img3;
    public static Image img4;
    public static Image img5;

    public Image[] healthBar = {img1, img2, img3, img4, img5};

    public void SetHealth(int maxHP,int curHP)
    {
        for (int i = 0; i < curHP; i++)
            healthBar[i].enabled = true;
        for (int i = maxHP-1; i > curHP - 1;i--)
            healthBar[i].enabled = false;
    }
    
}
