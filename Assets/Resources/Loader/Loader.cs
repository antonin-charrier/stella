using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Loader : MonoBehaviour
{

    public const string cardLoaderPath = "Loader/cards";
    public const string deckLoaderPath = "Loader/decks";
    public const string deckCardLoaderPath = "Loader/deck_cards";

    void Start() 
    {
        CardContainer cc = CardContainer.Load(cardLoaderPath);
        DeckContainer dc = DeckContainer.Load(deckLoaderPath);
        DeckCardContainer dcc = DeckCardContainer.Load(deckCardLoaderPath);

        Deck deck = dc.decks[0];
        DeckCreator.CreateXmlDeckCards(deck, cc.cards);

        foreach (DeckCard deckCard in dcc.deckCards)
        {
            Card card = cc.cards.Find(x => x.name == deckCard.name);
            if (card != null)
                InstantiateCard(card.name, card.level, card.power, card.lifePoints, card.description);
        }
	}

    private GameObject InstantiateCard(string name, int level, int power, int lifePoints, string description)
    {

        GameObject cardGameObject = (GameObject)Instantiate(Resources.Load("Card/Card"));
        cardGameObject.transform.SetParent(GameObject.Find("HAND").transform);
        cardGameObject.GetComponent<CardUI>().setLabels(name, level, power, lifePoints, description);

        return cardGameObject;
    }

}
