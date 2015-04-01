public class Enemy {
    public string Name;
    public int MaxHP;
    public int CurrentHP;
    public string SpriteName;
    public float AttackSpeed;

    public Enemy(string name, int maxHP, string spriteName) {
        Name = name;
        MaxHP = maxHP;
        CurrentHP = MaxHP;
        SpriteName = spriteName;
        AttackSpeed = 5;
    }

    public void Attack() {
        Managers.Player.ReduceHealth(5);
    }
}