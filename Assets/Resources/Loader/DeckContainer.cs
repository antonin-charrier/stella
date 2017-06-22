using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
        
[XmlRoot("DeckCollection")]
public class DeckContainer {

    [XmlArray("Decks")]
    [XmlArrayItem("Deck")]
    public List<Deck> decks = new List<Deck>();

    public static DeckContainer Load(string path)
    {
        TextAsset _xml = Resources.Load<TextAsset>(path);

        XmlSerializer serializer = new XmlSerializer(typeof(DeckContainer));

        StringReader reader = new StringReader(_xml.text);

        DeckContainer decks = serializer.Deserialize(reader) as DeckContainer;

        reader.Close();

        return decks;
    }
}
