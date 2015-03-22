using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour, IGameManager {
    public ManagerStatus status { get; private set; }

    public int Health { get; private set; }
    public int MaxHealth { get; private set; }
    public TextMesh CurrentHealthTextMesh;

    public void Startup() {
        Debug.Log("Player manger starting...");

        Health = 50;
        MaxHealth = 100;

        CurrentHealthTextMesh.text = Health.ToString();
        status = ManagerStatus.Started;
    }

    public void ChangeHealth(int value) {
        Health += value;
        if (Health > MaxHealth) {
            Health = MaxHealth;
        }
        else if (Health < 0) {
            Health = 0;
        }
        CurrentHealthTextMesh.text = Health.ToString();
        Debug.Log("Health: " + Health + "/" + MaxHealth);
    }
}
