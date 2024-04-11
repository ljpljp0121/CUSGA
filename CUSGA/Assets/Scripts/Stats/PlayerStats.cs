public enum StatType
{
    damage,
    health,
    armor,
}

public class PlayerStats : CharacterStats
{
    private Player player;
    protected override void Start()
    {
        base.Start();

        player = GetComponent<Player>();
    }

    public override void TakeDamage(int _damage)
    {
        base.TakeDamage(_damage);
    }

    protected override void Die()
    {
        base.Die();
        player.Die();

    }

    protected override void DecreaseHealthBy(int _damage)
    {
        base.DecreaseHealthBy(_damage);
    }
    public Stat GetStat(StatType _statType)
    {
        if (_statType == StatType.damage) return damage;
        else if (_statType == StatType.health) return maxHealth;
        else if (_statType == StatType.armor) return armor;

        return null;
    }
}
