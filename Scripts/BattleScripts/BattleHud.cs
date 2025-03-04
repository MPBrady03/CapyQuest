using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BattleHud : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public Slider hpSlider;

    public void setHUD(Unit unit){
        nameText.text = unit.unitName;
        levelText.text= "Lvl " + unit.unitLevel;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;

    }

    public void setHP(int hp){
        hpSlider.value = hp;
    }
}
