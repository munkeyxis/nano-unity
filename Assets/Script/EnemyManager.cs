using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour, IGameManager {
    public ManagerStatus status { get; private set; }

    // TODO: Remove if not used
    public void Startup() {
        Debug.Log("Enemy manager starting...");

        status = ManagerStatus.Started;
    }
}
