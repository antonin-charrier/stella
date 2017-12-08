using Assets.Utils;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

public class Deck
{
    [XmlAttribute("name")]
    public string name;

    public void CreateCards()
    {
        DeckCreator.CreateXmlDeckCards(this, XmlAccessor.CardContainer.Cards);
    }
}
