using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class Card : MonoBehaviour
{
    [XmlAttribute("name")]
    public string name;

    [XmlElement("Level")]
    public int level;

    [XmlElement("Power")]
    public int power;

    [XmlElement("LifePoints")]
    public int lifePoints;

    [XmlElement("Description")]
    public string description;


    public Card(string name, int level, int power, int lifePoints, string description)
    {
        this.name = name;
        this.level = level;
        this.power = power;
        this.lifePoints = lifePoints;
        this.description = description;
    }

}
