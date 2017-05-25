using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class Card {

    [XmlAttribute("name")]
    public string name;

    [XmlElement("Level")]
    public int level;

    [XmlElement("Power")]
    public float power;

    [XmlElement("LifePoints")]
    public float lifePoints;
}
