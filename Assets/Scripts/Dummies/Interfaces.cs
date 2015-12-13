using UnityEngine;
using System.Collections;

public interface IMovable
{
    void Move(float move);
    void Jump();
}
public interface IDamageable
{
	bool isAlive();
	void getHit();
}
