using UnityEngine;
using System.Collections;

public class DeckCardLoader : MonoBehaviour
{

    public const string deckCardLoaderPath = "Loader/deck_cards";

	void Start() 
    {
        DeckCardContainer dcc = DeckCardContainer.Load(deckCardLoaderPath);

        foreach (DeckCard deckCard in dcc.deckCards)
        {
            Debug.Log(deckCard.name);
        }
	}

}
