using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour {
    public void setLabels(string name, int level, int power, int lifePoints, string description)
    {
        Transform titleTransform = gameObject.transform.Find("CardTitleLabel");
        Text nameText = titleTransform.GetComponent<Text>();
        nameText.text = name;

        Transform powerTransform = gameObject.transform.Find("CardPowerLabel");
        Text powerText = powerTransform.GetComponent<Text>();
        powerText.text = power.ToString();

        Transform lifePointsTransform = gameObject.transform.Find("CardLifePointsLabel");
        Text lifePointsText = lifePointsTransform.GetComponent<Text>();
        lifePointsText.text = lifePoints.ToString();

        Transform descriptionTransform = gameObject.transform.Find("CardDescriptionLabel");
        Text descriptionText = descriptionTransform.GetComponent<Text>();
        descriptionText.text = description;

        DisplayLevelSprites(level);
    }

    private void DisplayLevelSprites()
    {
        GameObject levelSprites = gameObject.transform.Find("CardLevelSprites").gameObject;
        GameObject levelSprite = (GameObject)Instantiate(Resources.Load("Card/CardLevelSprite"));
        levelSprite.transform.SetParent(levelSprites.transform);
    }

    private void DisplayLevelSprites(int level)
    {
        GameObject levelSprites = gameObject.transform.Find("CardLevelSprites").gameObject;
        for (int i = 0; i < level; i++)
        {
            GameObject levelSprite = (GameObject)Instantiate(Resources.Load("Card/CardLevelSprite"));
            levelSprite.transform.SetParent(levelSprites.transform);
        }
    }
}
