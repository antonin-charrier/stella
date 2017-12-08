using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class Card
{
    [XmlAttribute("name")]
    public string Name;

    [XmlElement("Level")]
    public int Level;

    [XmlElement("Power")]
    public int Power;

    [XmlElement("LifePoints")]
    public int LifePoints;

    [XmlElement("Description")]
    public string Description;

    public GameObject Instantiate()
    {
        GameObject cardGameObject = (GameObject)Object.Instantiate(Resources.Load("Card/Card"));
        cardGameObject.transform.SetParent(GameObject.Find("HAND").transform);
        cardGameObject.GetComponent<CardUI>().SetLabels(Name, Level, Power, LifePoints, Description);

        return cardGameObject;
    }
}
