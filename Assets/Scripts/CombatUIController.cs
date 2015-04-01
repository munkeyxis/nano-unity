using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatUIController : MonoBehaviour {
    public TextMesh EnemyName;
    public TextMesh EnemyMaxHP;
    public TextMesh EnemyCurrentHP;
    public SpriteRenderer EnemySprite;
    public TextMesh CombatTextMesh;
    public GameObject HandGroup;
    public GameObject CardPrefab;
    public GameObject EnemyAttackTimerBar;
    private float _maxTimerBarScaleX = 10;
    private List<GameObject> _cardPrefabList = new List<GameObject>();

    public void DisplayEnemyInformation(Enemy enemy) {
        EnemyName.text = enemy.Name;
        EnemyMaxHP.text = "/" + enemy.MaxHP.ToString();
        EnemyCurrentHP.text = enemy.CurrentHP.ToString();
        EnemySprite.sprite = Resources.Load<Sprite>("Enemies/testDummy");
    }

    public void DisplayCombatText(string combatText) {
        CombatTextMesh.text = combatText;
    }

    public void DisplayHand() {
        foreach (GameObject cardPrefab in _cardPrefabList) {
            Destroy(cardPrefab);
        }

        float cardXPosition = -5f;
        float cardYPosition = -2f;
        float cardZPosition = -1f;
        float xOffset = 1.6f;

        foreach (Card card in Managers.CombatManager.GetHandList()) {
            cardXPosition += xOffset;
            GameObject cardPrefab = Instantiate<GameObject>(CardPrefab);
            cardPrefab.transform.parent = HandGroup.transform;
            cardPrefab.transform.localPosition = new Vector3(cardXPosition, cardYPosition, cardZPosition);
            cardPrefab.GetComponent<CardUIController>().AssignCard(card);
            _cardPrefabList.Add(cardPrefab);
        }
    }

    public void UpdateAttackTimerBar(float timer, float enemySpeed) {
        float percent = timer / enemySpeed;
        EnemyAttackTimerBar.transform.localScale = new Vector3(percent * 10, 1, 1);
    }
}
