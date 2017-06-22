using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
        
[XmlRoot("DeckCardsCollection")]
public class DeckCardContainer {

    [XmlArray("DeckCards")]
    [XmlArrayItem("DeckCard")]
    public List<DeckCard> deckCards = new List<DeckCard>();

    public static DeckCardContainer Load(string path)
    {
        TextAsset _xml = Resources.Load<TextAsset>(path);

        XmlSerializer serializer = new XmlSerializer(typeof(DeckCardContainer));

        StringReader reader = new StringReader(_xml.text);

        DeckCardContainer deckCards = serializer.Deserialize(reader) as DeckCardContainer;

        reader.Close();

        return deckCards;
    }
}
