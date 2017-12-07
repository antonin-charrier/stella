using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

public class DeckCreator
{
    public static void CreateXmlDeckCards(Deck deck, List<Card> cardsToAdd)
    {
        XmlDocument doc = new XmlDocument();

        using (XmlWriter xmlWriter = doc.CreateNavigator().AppendChild())
        {
            xmlWriter.WriteStartElement("DeckCardsCollection");
            xmlWriter.WriteStartElement("DeckCards");

            foreach (Card card in cardsToAdd)
            {
                xmlWriter.WriteStartElement("DeckCard");
                xmlWriter.WriteElementString("name", card.Name);
                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
        }

        doc.Save(deck.name + ".xml");
    }
}
