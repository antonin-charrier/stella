using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class Instantiation : MonoBehaviour {

	// Use this for initialization
	void Start () {
        InstantiateCard ("card name", 3, 2, 11, "description");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private GameObject InstantiateCard(string name, int level, int power, int lifePoints, string description)
    {
        Card card = new Card(name, level, power, lifePoints, description);

        GameObject cardGameObject = (GameObject)Instantiate(Resources.Load("Card/Card"));
        cardGameObject.transform.parent = GameObject.Find("HAND").transform;

        Transform titleTransform = cardGameObject.transform.Find("CardTitleLabel");
        Text nameText = titleTransform.GetComponent<Text>();
        nameText.text = name;

        Transform powerTransform = cardGameObject.transform.Find("CardPowerLabel");
        Text powerText = powerTransform.GetComponent<Text>();
        powerText.text = power.ToString();

        Transform lifePointsTransform = cardGameObject.transform.Find("CardLifePointsLabel");
        Text lifePointsText = lifePointsTransform.GetComponent<Text>();
        lifePointsText.text = lifePoints.ToString();

        Transform descriptionTransform = cardGameObject.transform.Find("CardDescriptionLabel");
        Text descriptionText = descriptionTransform.GetComponent<Text>();
        descriptionText.text = description;

        DisplayLevelStars(cardGameObject, 7);

        return cardGameObject;
    }


    private void DisplayLevelStars(GameObject cardGameObject)
    {
        GameObject levelSprites = cardGameObject.transform.Find("CardLevelSprites").gameObject;
        GameObject levelSprite = (GameObject)Instantiate(Resources.Load("Card/CardLevelSprite"));
        levelSprite.transform.SetParent(levelSprites.transform);
    }

    private void DisplayLevelStars(GameObject cardGameObject, int level)
    {
        GameObject levelSprites = cardGameObject.transform.Find("CardLevelSprites").gameObject;
        for (int i = 0; i < level; i++)
        {
            GameObject levelSprite = (GameObject)Instantiate(Resources.Load("Card/CardLevelSprite"));
            levelSprite.transform.SetParent(levelSprites.transform);
        }
    }
}
