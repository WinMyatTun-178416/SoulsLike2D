using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newMeleeAttackStateData", menuName = "Data/State Data/MeleeAttack State Data")]

public class D_MeleeAttackState : ScriptableObject
{
    public float attackRadius = 1f;
    public LayerMask whatisPlayer;
    public float attackDamage;
}
