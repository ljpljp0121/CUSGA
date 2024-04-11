using System.Collections;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    private EntityFX fx;//受击反馈

    [Header("Offensive stats")]//攻击数据
    public Stat damage;


    [Header("Defensive stats")]//防御数据
    public Stat maxHealth;//最大生命值
    public Stat armor;//护甲


    [Header("Current stats")]//实时数据
    public int currentHealth;//当前生命值
    public int currentArmor;//当前护甲值
    public int currentDamage;//当前攻击力



    public bool isDead { get; private set; }

    protected virtual void Start()
    {
        currentHealth = GetMaxHealthValue();
        currentArmor = GetArmorValue();
        currentDamage = GetDamageValue();

        fx = GetComponent<EntityFX>();
    }

    protected virtual void Update()
    {

    }
    public virtual void DoDamage(CharacterStats _targetStats)//对目标造成伤害
    {
        int totalDamage = currentDamage;

        totalDamage = GetFinalDamage(_targetStats, totalDamage);
        _targetStats.TakeDamage(totalDamage);

    }


    public virtual void TakeDamage(int _damage)//遭受攻击
    {
        DecreaseHealthBy(_damage);

        fx.StartCoroutine("FlashFX");//受击闪白


        if (currentHealth <= 0 && !isDead)
            Die();
    }

    public virtual void IncreaseHealthBy(int _amount)//回血效果
    {
        currentHealth += _amount;

        if (currentHealth > GetMaxHealthValue())
            currentHealth = GetMaxHealthValue();

    }
    protected virtual void DecreaseHealthBy(int _damage)//用在遭受攻击的函数中，直接用的话相当于真实伤害，无视护甲直接扣血
    {
        currentHealth -= _damage;
    }
    public virtual void IncreaseArmorBy(int _amount)//加护盾值
    {
        currentArmor += _amount;//可无限增加

    }

    public virtual void IncreaseDamageBy(int _amount)//加攻击力
    {
        currentDamage += _amount;//可无限增加
    }

    public virtual void DecreaseDamageBy(int _amount)//减攻击力
    {
        currentDamage -= _amount;
        if (currentDamage < 0)
            currentDamage = 0;
    }

    protected virtual void Die()
    {
        isDead = true;
    }
    #region Stat calculations
    private int GetFinalDamage(CharacterStats _targetStats, int totalDamage)//计算攻击目标的护甲，返回减去对方护甲后造成的伤害
    {
        int armorBeforeDamage = _targetStats.currentArmor;//遭受攻击前目标的当前护甲


        _targetStats.currentArmor -= totalDamage;//刷新护甲值
        if (_targetStats.currentArmor <= 0)
            _targetStats.currentArmor = 0;

        totalDamage -= armorBeforeDamage;


        totalDamage = Mathf.Clamp(totalDamage, 0, int.MaxValue);
        return totalDamage;
    }





    public int GetMaxHealthValue()//获得最大生命值
    {
        return maxHealth.GetValue();
    }
    public int GetArmorValue()//获得初始护甲值
    {
        return armor.GetValue();
    }
    public int GetDamageValue()//获得初始攻击值
    {
        return damage.GetValue();
    }
    #endregion
}

