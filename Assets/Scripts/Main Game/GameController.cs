using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    public Sprite[] cardImages;
    public List<Button> cards = new List<Button>();
    public List<Sprite> gameCardImages = new List<Sprite>();

    private void Awake()
    {
        cardImages = Resources.LoadAll<Sprite>("Sprites");
    }

    void Start()
    {
        GetCards();
        AddButtonListener();
        AddGameImages();
    }

    void GetCards()
    {
        GameObject[] cardList = GameObject.FindGameObjectsWithTag("Card");

        for(int i = 0; i < cardList.Length; i++)
        {
            cards.Add(cardList[i].GetComponent<Button>());
        }
    }

    private void AddButtonListener()
    {
        foreach(Button card in cards)
        {
            card.onClick.AddListener(() => pickCard());
        }
    }


    private bool firstGuess, secondGuess;
    private int firstGuessIndex, secondGuessIndex;
    private string firstGuessCard, secondGuessCard;
    private void pickCard()
    {
        var name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstGuessCard = cardImages[firstGuessIndex].name;
            cards[firstGuessIndex].image.sprite = gameCardImages[firstGuessIndex];
        } else if (!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondGuessCard = cardImages[secondGuessIndex].name;
            cards[secondGuessIndex].image.sprite = gameCardImages[secondGuessIndex];
        }
    }


    private void AddGameImages()
    {
        var loopPoint = cards.Count;
        var index = 0;

        for (int i = 0; i < loopPoint; i++)
        {
            if (index == loopPoint/2)
            {
                index = 0;
            }
            gameCardImages.Add(cardImages[index]);
            index++;
        }
    }
    //is it ok now?
}
