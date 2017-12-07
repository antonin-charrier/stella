using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

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

}
