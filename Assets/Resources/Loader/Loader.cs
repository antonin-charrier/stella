using UnityEngine;

public class Loader : MonoBehaviour
{

    public const string cardLoaderPath = "Loader/Loaders/cards";
    public const string deckLoaderPath = "Loader/Loaders/decks";
    public const string deckCardLoaderPath = "Loader/Loaders/deck_cards";

    void Start() 
    {
        CardContainer cc = CardContainer.Load(cardLoaderPath);
        DeckContainer dc = DeckContainer.Load(deckLoaderPath);
        DeckCardContainer dcc = DeckCardContainer.Load(deckCardLoaderPath);

        Deck deck = dc.decks[0];
        DeckCreator.CreateXmlDeckCards(deck, cc.Cards);

        foreach (DeckCard deckCard in dcc.Deck)
        {
            Card card = cc.Cards.Find(x => x.Name == deckCard.name);
            if (card != null)
                Instantiate(card);
        }

        DeckCard randomDeckCard = DeckCardContainer.RandomDeckCard(dcc.Deck);
        Card randomCard = cc.Cards.Find(x => x.Name == randomDeckCard.name);
        if (randomCard != null)
            Instantiate(randomCard);

    }

    private GameObject Instantiate(Card card)
    {
        GameObject cardGameObject = (GameObject)Instantiate(Resources.Load("Card/Card"));
        cardGameObject.transform.SetParent(GameObject.Find("HAND").transform);
        cardGameObject.GetComponent<CardUI>().SetLabels(card.Name, card.Level, card.Power, card.LifePoints, card.Description);

        return cardGameObject;
    }
}
