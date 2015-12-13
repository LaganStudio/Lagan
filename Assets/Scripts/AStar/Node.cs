using UnityEngine;
using System.Collections;

public class Node {
	public Vector3 worldPosition;
	public bool walkable;
	public bool jumpable;
	public int gridX;
	public int gridY;

	public int gCost;
	public int hCost;
	public int fCost{
		get{return gCost + fCost;}
	}
	public Node(bool walkable, bool jumpable, Vector3 worldPosition, int gridX, int gridY){
		this.worldPosition = worldPosition;
		this.walkable = walkable;
		this.jumpable = jumpable;
		this.gridX = gridX;
		this.gridY = gridY;
	}
}
