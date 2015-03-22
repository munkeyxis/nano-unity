using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(InventoryManager))]
[RequireComponent(typeof(DeckManager))]
[RequireComponent(typeof(ItemsManager))]
[RequireComponent(typeof(EnemyManager))]
[RequireComponent(typeof(CombatManager))]

public class Managers : MonoBehaviour {
    public static PlayerManager Player { get; private set; }
    public static ItemsManager Items { get; private set; }
    public static InventoryManager Inventory { get; private set; }
    public static DeckManager Deck { get; private set; }
    public static EnemyManager EnemyManager { get; private set; }
    public static CombatManager CombatManager { get; private set; }

    private List<IGameManager> _startSquence;

    void Awake() {
        Player = GetComponent<PlayerManager>();
        Items = GetComponent<ItemsManager>();
        Inventory = GetComponent<InventoryManager>();
        Deck = GetComponent<DeckManager>();
        EnemyManager = GetComponent<EnemyManager>();
        CombatManager = GetComponent<CombatManager>();
        
        _startSquence = new List<IGameManager>();
        _startSquence.Add(Player);
        _startSquence.Add(Items);
        _startSquence.Add(Inventory);
        _startSquence.Add(Deck);
        _startSquence.Add(EnemyManager);
        _startSquence.Add(CombatManager);

        StartCoroutine(StartupManagers());
    }

    private IEnumerator StartupManagers() {
        foreach (IGameManager manager in _startSquence) {
            manager.Startup();
        }

        int numModules = _startSquence.Count;
        int numReady = 0;

        while (numReady < numModules) {
            int lastReady = numReady;
            numReady = 0;

            foreach (IGameManager manager in _startSquence) {
                if (manager.status == ManagerStatus.Started) {
                    numReady++;
                }
            }

            if (numReady > lastReady) {
                Debug.Log("Progress: " + numReady + "/" + numModules);
            }

            yield return null;
        }

        Debug.Log("All managers started up.");
    }
}
