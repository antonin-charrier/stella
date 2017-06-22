using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class DeckCard
{
    [XmlAttribute("name")]
    public string name;

}
