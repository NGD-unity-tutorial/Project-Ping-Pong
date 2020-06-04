using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBasicControl
{
    void DoAttack(Vector2 str);
    void DoMove(Vector2 kinetic);
    void DoSkill(int mode);
} 