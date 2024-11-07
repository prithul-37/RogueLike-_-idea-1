using UnityEngine;
using UnityEngine.Playables;

[CreateAssetMenu(fileName = "New Bullet", menuName = "Bullet/Create New Bullet")]
public class Bullet : ScriptableObject
{   
    public float Damage;
    public Color Color;
}
