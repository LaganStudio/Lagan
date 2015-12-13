using UnityEngine;
using System.Collections;

public interface IState
{
	void Action(AIController ai, IMovable dummy);
}

