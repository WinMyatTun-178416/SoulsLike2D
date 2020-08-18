using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName ="newEntityData",menuName ="Data/Entity Data/Base Data")]
public class D_Entity : ScriptableObject 
{
    public float wallCheckDistance = 0.5f;
    public float ledgeCheckDistance = 0.5f;
    public float maxAgroDistance = 6f;
    public float minAgroDistance = 3f;
    public float closeRangeActionDistance = 1f;
    public LayerMask whatisGround;
    public LayerMask whatisPlayer;
}
