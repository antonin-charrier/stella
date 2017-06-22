using UnityEngine;
using System.Collections;

public class DeckLoader : MonoBehaviour
{

    public const string deckLoaderPath = "Loader/decks";

	void Start() 
    {
        DeckContainer dc = DeckContainer.Load(deckLoaderPath);

        foreach (Deck deck in dc.decks)
        {
            Debug.Log(deck.name);
        }
	}

}
