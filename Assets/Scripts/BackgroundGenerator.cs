using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    public GameObject chunkPrefab; // Prefab of the background chunk
    public int chunkSize = 5; // Size of each chunk
    public int initialChunkCount = 3; // Number of initial chunks to spawn in each direction

    private Transform player; // Reference to the player's transform
    private Vector2Int currentChunkCoordinate; // Coordinate of the current chunk

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentChunkCoordinate = GetChunkCoordinate(player.position);

        // Spawn initial chunks
        for (int x = -initialChunkCount; x <= initialChunkCount; x++)
        {
            for (int y = -initialChunkCount; y <= initialChunkCount; y++)
            {
                Vector2Int chunkCoordinate = new Vector2Int(currentChunkCoordinate.x + x, currentChunkCoordinate.y + y);
                SpawnChunk(chunkCoordinate);
            }
        }
    }

    private void Update()
    {
        // Check if player transform is null
        if (player == null)
        {
            // Handle the case when player object is destroyed
            GameObject newPlayer = GameObject.FindGameObjectWithTag("Player");

            if (newPlayer != null)
            {
                player = newPlayer.transform;
            }
            else
            {
                // Player object is still not found, do nothing
                return;
            }
        }

        Vector2Int newChunkCoordinate = GetChunkCoordinate(player.position);

        // Check if the player has moved to a new chunk
        if (newChunkCoordinate != currentChunkCoordinate)
        {
            currentChunkCoordinate = newChunkCoordinate;
            UpdateChunks();
        }
    }

    private Vector2Int GetChunkCoordinate(Vector3 position)
    {
        int x = Mathf.FloorToInt(position.x / chunkSize);
        int y = Mathf.FloorToInt(position.y / chunkSize);
        return new Vector2Int(x, y);
    }

    private void SpawnChunk(Vector2Int chunkCoordinate)
    {
        Vector3 spawnPosition = new Vector3(chunkCoordinate.x * chunkSize, chunkCoordinate.y * chunkSize, 0f);
        Instantiate(chunkPrefab, spawnPosition, Quaternion.identity);
    }

    private void DespawnChunk(Vector2Int chunkCoordinate)
    {
        GameObject[] chunks = GameObject.FindGameObjectsWithTag("Chunk");
        foreach (GameObject chunk in chunks)
        {
            ChunkData chunkData = chunk.GetComponent<ChunkData>();
            if (chunkData.Coordinate == chunkCoordinate)
            {
                Destroy(chunk);
                break;
            }
        }
    }

    private void UpdateChunks()
    {
        GameObject[] chunks = GameObject.FindGameObjectsWithTag("Chunk");
        foreach (GameObject chunk in chunks)
        {
            ChunkData chunkData = chunk.GetComponent<ChunkData>();
            Vector2Int chunkCoordinate = chunkData.Coordinate;
            Vector3 chunkPosition = new Vector3(chunkCoordinate.x * chunkSize, chunkCoordinate.y * chunkSize, 0f);

            float distance = Vector3.Distance(player.position, chunkPosition);
            if (distance > chunkSize * (initialChunkCount + 1))
            {
                Destroy(chunk);
            }
        }

        // Spawn new chunks around the player
        for (int x = -initialChunkCount; x <= initialChunkCount; x++)
        {
            for (int y = -initialChunkCount; y <= initialChunkCount; y++)
            {
                Vector2Int chunkCoordinate = new Vector2Int(currentChunkCoordinate.x + x, currentChunkCoordinate.y + y);
                SpawnChunk(chunkCoordinate);
            }
        }
    }
}
