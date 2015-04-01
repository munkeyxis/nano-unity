public class Enemy {
    public string Name;
    public int MaxHP;
    public int CurrentHP;
    public string SpriteName;

    public Enemy(string name, int maxHP, string spriteName) {
        Name = name;
        MaxHP = maxHP;
        CurrentHP = MaxHP;
        SpriteName = spriteName;
    }

    public void Attack() {
        Managers.Player.ReduceHealth(5);
    }
}