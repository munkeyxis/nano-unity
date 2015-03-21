using UnityEngine;
using System.Collections;

public class CombatManager : MonoBehaviour, IGameManager {
    public ManagerStatus status { get; private set; }
    public GameObject CombatUIGroup;
    private Enemy _enemy;

    public void Startup() {
        Debug.Log("Combat manager starting...");

        CombatUIGroup.SetActive(false);

        status = ManagerStatus.Started;
    }

    public void StartCombat() {
        _enemy = new Enemy("Test Dummy", 10, "testDummy");

        CombatUIGroup.GetComponent<CombatUIController>().DisplayEnemyInformation(_enemy);
        CombatUIGroup.SetActive(true);
    }
}
