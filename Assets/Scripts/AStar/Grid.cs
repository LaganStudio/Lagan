using UnityEngine;
using System.Collections.Generic;

public class Grid : MonoBehaviour
{
    public Transform target;
    public GameObject[] gos;
    public float nodeRadius;
    public Vector2 gridWorldSize;
    public LayerMask whatIsWalkable;

    private float nodeDiameter;
    private Node[,] nodeGrid;
    private int gridSizeX, gridSizeY;
    private Vector3 worldBottomLeft;

    void Start() {
        worldBottomLeft = transform.position;
        nodeDiameter = nodeRadius * 2;
        //whatIsPlatform = LayerMask.NameToLayer("Platform");
        gridSizeX = Mathf.RoundToInt((float)gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt((float)gridWorldSize.y / nodeDiameter);
        print(gridSizeX + " " + gridSizeY + " " + gridSizeX * gridSizeY);
        CreateGrid();
    }

    void CreateGrid() {
        nodeGrid = new Node[gridSizeX, gridSizeY];
        for (int i = 0; i < gridSizeX; i++)
        {
            for (int j = 0; j < gridSizeY; j++) {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (i * nodeDiameter + nodeRadius) + Vector3.up * (j * nodeDiameter + nodeRadius);
                bool walkable = Physics2D.Raycast(worldPoint, Vector2.down, nodeRadius, whatIsWalkable);
                bool jumpable;

                if (walkable)
                    jumpable = true;
                else
                    jumpable = Physics2D.Raycast(worldPoint, Vector2.down, 4.5f, whatIsWalkable);

                if (Physics2D.OverlapCircle(worldPoint, nodeRadius - 0.1f, whatIsWalkable))
                {
                    walkable = false;
                    jumpable = false;
                }
                nodeGrid[i, j] = new Node(walkable, jumpable, worldPoint, i, j);
            }
        }
    }
    void RefreshGrid()
    {
        foreach (GameObject go in gos)
        {
            Collider2D[] collider = go.GetComponents<Collider2D>();
        }
    }
    void FixedUpdate()
    {
        RefreshGrid();
    }
    public List<Node> GetNeighbours(Node node)
    {
        List<Node> neighbours = new List<Node>();
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                    continue;
                int checkX = node.gridX + x;
                int checkY = node.gridY + y;
                if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                {
                    neighbours.Add(nodeGrid[checkX, checkY]);
                }
            }
        }
        return neighbours;
    }
    public Node NodeFromWorldPoint(Vector3 worldPosition)
    {
        float percentX = (worldPosition.x - transform.position.x) / (gridWorldSize.x); //
        float percentY = (worldPosition.y - transform.position.y) / (gridWorldSize.y); //
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);
        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
        return nodeGrid[x, y];
    }
    /**
	 *
	 *
	 * */
    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + new Vector3(gridWorldSize.x / 2, gridWorldSize.y / 2, 0), new Vector3(gridWorldSize.x, gridWorldSize.y, 0));

        if (nodeGrid != null)
        {
            foreach (Node n in nodeGrid)
            {
                Node targetNode = NodeFromWorldPoint(target.position);

                Gizmos.color = n == targetNode ? Color.cyan :
                    n.walkable ? Color.red :
                        n.jumpable ? Color.blue : Color.white;
                Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter - nodeRadius * 0.5f));
            }
        }
    }
}
