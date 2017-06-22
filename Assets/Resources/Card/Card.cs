using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class Card
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

}
