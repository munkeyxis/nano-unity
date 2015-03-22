using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatManager : MonoBehaviour, IGameManager {
    public ManagerStatus status { get; private set; }
    public GameObject CombatUIGroup;
    private Enemy _enemy;
    private List<Card> _deckList;
    private List<Card> _handList;
    private List<Card> _discardList;
    private int _startingHandSize = 4;

    public void Startup() {
        Debug.Log("Combat manager starting...");

        CombatUIGroup.SetActive(false);

        status = ManagerStatus.Started;
    }

    public void StartCombat() {
        _enemy = new Enemy("Test Dummy", 10, "testDummy");
        CombatUIGroup.GetComponent<CombatUIController>().DisplayEnemyInformation(_enemy);

        _deckList = Managers.Deck.GetDeckCardList();
        _handList = new List<Card>();
        _discardList = new List<Card>();

        while (_handList.Count < _startingHandSize) {
            DrawCard();
        }

        Debug.Log("combatDeck is:");
        foreach (Card deckCard in _deckList) {
            Debug.Log(deckCard.Name);
        }

        Debug.Log("hand is: ");
        foreach (Card handCard in _handList) {
            Debug.Log(handCard.Name);
        }

        CombatUIGroup.SetActive(true);
    }

    public List<Card> GetHandList() {
        return _handList;
    }

    private void DrawCard() {
        int randomNumber = Random.Range(0, _deckList.Count);
        _handList.Add(_deckList[randomNumber]);
        _deckList.RemoveAt(randomNumber);
        CombatUIGroup.GetComponent<CombatUIController>().DisplayHand();
    }
}
