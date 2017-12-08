using System.Xml;
using System.Xml.Serialization;
using Assets.Utils;

public class DeckCard
{
    [XmlAttribute("name")]
    public string Name;

    public Card AsCard()
    {
        return XmlAccessor.CardContainer.Cards.Find(x => x.Name == Name);
    }
}
