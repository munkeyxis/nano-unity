using UnityEngine;
using System.Collections;

public class CombatUIController : MonoBehaviour {
    public TextMesh _enemyName;
    public TextMesh _enemyMaxHP;
    public TextMesh _enemyCurrentHP;
    public SpriteRenderer _enemySprite;

    public void DisplayEnemyInformation(Enemy enemy) {
        _enemyName.text = enemy.Name;
        _enemyMaxHP.text = "/" + enemy.MaxHP.ToString();
        _enemyCurrentHP.text = enemy.CurrentHP.ToString();
        _enemySprite.sprite = Resources.Load<Sprite>("Enemies/testDummy");
    }
}
