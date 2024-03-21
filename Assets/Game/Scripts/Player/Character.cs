using UnityEngine;

public class Character
{
    private float moveSpeed;
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
 
    private float dmg;
    public float Dmg { get => dmg; set => dmg = value; }
    
    private float hp;
    public float Hp { get => hp; set => hp = value; }

    private float maxHp;
    public float MaxHp { get => maxHp; set => maxHp = value; }
}