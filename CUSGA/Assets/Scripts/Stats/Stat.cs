using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Stat
{
    [SerializeField] private int baseValue;

    public int GetValue()
    {
        int finalValue = baseValue;
        return finalValue;
    }

    public void SetDefaultValue(int _value)
    {
        baseValue = _value;
    }



    public int DecreaseValue(int _value)//����Ĭ��ֵ/����ֵ
    {
        baseValue -= _value;

        if (baseValue < 0)
            baseValue = 0;

        return baseValue;
    }
    public int IncreaseValue(int _value)//����Ĭ��ֵ/����ֵ
    {
        baseValue += _value;


        return baseValue;
    }
}
