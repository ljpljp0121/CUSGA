using System.Collections;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    private EntityFX fx;//�ܻ�����

    [Header("Offensive stats")]//��������
    public Stat damage;


    [Header("Defensive stats")]//��������
    public Stat maxHealth;//�������ֵ
    public Stat armor;//����


    [Header("Current stats")]//ʵʱ����
    public int currentHealth;//��ǰ����ֵ
    public int currentArmor;//��ǰ����ֵ
    public int currentDamage;//��ǰ������



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
    public virtual void DoDamage(CharacterStats _targetStats)//��Ŀ������˺�
    {
        int totalDamage = currentDamage;

        totalDamage = GetFinalDamage(_targetStats, totalDamage);
        _targetStats.TakeDamage(totalDamage);

    }


    public virtual void TakeDamage(int _damage)//���ܹ���
    {
        DecreaseHealthBy(_damage);

        fx.StartCoroutine("FlashFX");//�ܻ�����


        if (currentHealth <= 0 && !isDead)
            Die();
    }

    public virtual void IncreaseHealthBy(int _amount)//��ѪЧ��
    {
        currentHealth += _amount;

        if (currentHealth > GetMaxHealthValue())
            currentHealth = GetMaxHealthValue();

    }
    protected virtual void DecreaseHealthBy(int _damage)//�������ܹ����ĺ����У�ֱ���õĻ��൱����ʵ�˺������ӻ���ֱ�ӿ�Ѫ
    {
        currentHealth -= _damage;
    }
    public virtual void IncreaseArmorBy(int _amount)//�ӻ���ֵ
    {
        currentArmor += _amount;//����������

    }

    public virtual void IncreaseDamageBy(int _amount)//�ӹ�����
    {
        currentDamage += _amount;//����������
    }

    public virtual void DecreaseDamageBy(int _amount)//��������
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
    private int GetFinalDamage(CharacterStats _targetStats, int totalDamage)//���㹥��Ŀ��Ļ��ף����ؼ�ȥ�Է����׺���ɵ��˺�
    {
        int armorBeforeDamage = _targetStats.currentArmor;//���ܹ���ǰĿ��ĵ�ǰ����


        _targetStats.currentArmor -= totalDamage;//ˢ�»���ֵ
        if (_targetStats.currentArmor <= 0)
            _targetStats.currentArmor = 0;

        totalDamage -= armorBeforeDamage;


        totalDamage = Mathf.Clamp(totalDamage, 0, int.MaxValue);
        return totalDamage;
    }





    public int GetMaxHealthValue()//����������ֵ
    {
        return maxHealth.GetValue();
    }
    public int GetArmorValue()//��ó�ʼ����ֵ
    {
        return armor.GetValue();
    }
    public int GetDamageValue()//��ó�ʼ����ֵ
    {
        return damage.GetValue();
    }
    #endregion
}

