using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

public class Deck
{
    [XmlAttribute("name")]
    public string name;
}
