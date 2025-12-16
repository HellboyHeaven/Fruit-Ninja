using UnityEngine;

[CreateAssetMenu(fileName = "AttackSpeed", menuName = "ScriptableObjects/AttackSpeedSO", order = 1)]
public sealed class AttackSpeedSO : StatSO
{
    [SerializeField] private int _value;
    public override IStat Create()
    {
        return new AttackSpeed(_value);
    }
}