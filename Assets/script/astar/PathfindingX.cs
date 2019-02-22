using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingX : MonoBehaviour {

	public Transform seeker, target;
	GridX grid;



	void Awake() {
		grid = GetComponent<GridX> ();
	}

	void Update() {
		FindPath (seeker.position, target.position);
		
	}

	void FindPath(Vector3 startPos, Vector3 targetPos) {
		NodeX startNode = grid.NodeFromWorldPoint(startPos);
		NodeX targetNode = grid.NodeFromWorldPoint(targetPos);
		//Debug.Log (startPos); 
		//Debug.Log (targetPos);

		List<NodeX> openSet = new List<NodeX>();
		HashSet<NodeX> closedSet = new HashSet<NodeX>();
		openSet.Add(startNode);


		while (openSet.Count > 0) {
			NodeX node = openSet[0];
			for (int i = 1; i < openSet.Count; i ++) {
				if (openSet[i].fCost < node.fCost || openSet[i].fCost == node.fCost) {
					if (openSet[i].hCost < node.hCost)
						node = openSet[i];

					//Debug.Log (openSet.Count);
				}
			}

			openSet.Remove(node);
			closedSet.Add(node);

			// show data closedSet
			foreach (NodeX nod in closedSet) {
				//Debug.Log (nod.fCost);
			}

			if (node == targetNode) {
				RetracePath(startNode,targetNode);
				return;
			}

			foreach (NodeX neighbour in grid.GetNeighbours(node)) {
				if (!neighbour.walkable || closedSet.Contains(neighbour)) {
					continue;
				}

				int newCostToNeighbour = node.gCost + GetDistance(node, neighbour);
				if (newCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour)) {
					neighbour.gCost = newCostToNeighbour;
					neighbour.hCost = GetDistance(neighbour, targetNode);
					neighbour.parent = node;	

					//Debug.Log (neighbour.hCost + neighbour.gCost);

					if (!openSet.Contains(neighbour))
						openSet.Add(neighbour);
				}
			}
		}
	}

	void RetracePath(NodeX startNode, NodeX endNode) {
		List<NodeX> path = new List<NodeX>();
		NodeX currentNode = endNode;



		while (currentNode != startNode) {
			path.Add(currentNode);
			currentNode = currentNode.parent;

		}


		path.Reverse();


		grid.path = path;

	}

	int GetDistance(NodeX nodeA, NodeX nodeB) {
		int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
		int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

		if (dstX > dstY)
			return 14*dstY + 10* (dstX-dstY);
		return 14*dstX + 10 * (dstY-dstX);
	}
}

