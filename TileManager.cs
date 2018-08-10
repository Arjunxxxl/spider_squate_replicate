using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

	public GameObject[] tilePrefab;
	
	public Transform player;

	float spawnx = 50.0f;
	float tileLength = 100f;
	public int tileAmt = 2;

	float safeZone = 60f;

	List<GameObject> activeTile;

	int lastIndex = 0;

	// Use this for initialization
	void Start () {
		activeTile = new List<GameObject>();
		for(int i = 0; i< tileAmt; i++)
		{
			spawn();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.x + safeZone < spawnx + tileAmt * tileLength)
		{
			spawn();
			RemoveTile();
		}
	}

	void spawn(int prefabIndex = -1)
	{
		GameObject go;
		go = Instantiate(tilePrefab[RandomIndex()]) as GameObject;
		go.transform.SetParent(transform);
		go.transform.position =new Vector3(spawnx, 0, 0);
		spawnx -= tileLength;
		
			activeTile.Add(go);
	}

	void RemoveTile()
	{
		Destroy(activeTile[0]);
		activeTile.RemoveAt(0);
	}

	int RandomIndex()
	{
		if(tilePrefab.Length == 1)
		{
			return 0;
		}

		int randonI = lastIndex;
		while(randonI == lastIndex)
		{
			randonI = Random.Range(0, tilePrefab.Length);
		}

		lastIndex = randonI;
		return randonI;
	}

}
