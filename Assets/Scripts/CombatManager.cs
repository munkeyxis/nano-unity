﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatManager : MonoBehaviour, IGameManager {
    public ManagerStatus status { get; private set; }
    public GameObject CombatUIGroup;
    private CombatUIController _combatUIController;
    private Enemy _enemy;
    private List<Card> _deckList;
    private List<Card> _handList;
    private List<Card> _discardList;
    private int _startingHandSize = 4;

    private bool combatActive;
    private float enemyAttackTimer;

    private Card _previousCard;
    private int _comboCounter;

    private Card _comboResetCard = new Card("default", 0, Color.gray, Color.gray, Color.gray);

    public void Startup() {
        Debug.Log("Combat manager starting...");
        CombatUIGroup = Instantiate(CombatUIGroup);
        CombatUIGroup.SetActive(false);
        combatActive = false;

        status = ManagerStatus.Started;
    }

    public void StartCombat() {
        _combatUIController = CombatUIGroup.GetComponent<CombatUIController>();
        _enemy = new Enemy("Test Dummy", 30, "testDummy");
        _combatUIController.DisplayEnemyInformation(_enemy);

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

        _combatUIController.DisplayCombatText("You encounter a " + _enemy.Name + "!");
        CombatUIGroup.SetActive(true);

        combatActive = true;
        enemyAttackTimer = 0;

        _comboCounter = 0;
        _previousCard = _comboResetCard;
        _combatUIController.UpdateComboDisplay(_comboCounter);
    }

    void Update() {
        if (combatActive) {
            if (enemyAttackTimer >= _enemy.AttackSpeed) {
                enemyAttackTimer = 0;
                _enemy.Attack();
                _comboCounter = 0;
                _combatUIController.UpdateComboDisplay(_comboCounter);
            }
            enemyAttackTimer += 1 * Time.deltaTime;
            _combatUIController.UpdateAttackTimerBar(enemyAttackTimer, _enemy.AttackSpeed);
        }
    }

    public List<Card> GetHandList() {
        return _handList;
    }

    public void UseCard(Card card) {
        if (_handList.Contains(card)) {
            _handList.Remove(card);
            _discardList.Add(card);
            DrawCard();
        }
        else {
            Debug.Log("Cannot use card " + card.Name + "! It is not in your hand!");
        }

        HandleCombo(card);
        _combatUIController.UpdateComboDisplay(_comboCounter);

        string combatText = "You use " + card.Name + ". \n" +
            _enemy.Name + " takes " + card.getPowerValue() + " damage!";

        _combatUIController.DisplayCombatText(combatText);

        _enemy.CurrentHP -= card.getPowerValue();
        _combatUIController.DisplayEnemyInformation(_enemy);
        CheckForDeath();
        _previousCard = card;
    }

    private void HandleCombo(Card card) {
        if (_previousCard.ComboColor == card.CardColor) {
            _comboCounter++;
        }
        else {
            if (_previousCard.FinisherColor == card.CardColor) {
                HandleFinisher();
            }
            _comboCounter = 0;
            _previousCard = _comboResetCard;
        }
    }

    private void HandleFinisher() {
        _enemy.CurrentHP -= _comboCounter;
    }

    private void DrawCard() {
        if (_deckList.Count == 0) {
            RefillDeck();
        }

        int randomNumber = Random.Range(0, _deckList.Count);
        _handList.Add(_deckList[randomNumber]);
        _deckList.RemoveAt(randomNumber);
        _combatUIController.DisplayHand();
    }

    private void RefillDeck() {
        foreach (Card card in _discardList) {
            _deckList.Add(card);
        }
        _discardList.Clear();
    }

    private void CheckForDeath() {
        if (_enemy.CurrentHP <= 0) {
            CombatUIGroup.SetActive(false);
            combatActive = false;
            Managers.Inventory.AddRandomItemToInventory();
        }
    }
}
