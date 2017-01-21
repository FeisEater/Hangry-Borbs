using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner {
    public static void SpawnItems(float left, float right, float top, float bottom, Dictionary<string, int> items)
    {
        foreach (string type in items.Keys)
        {
            for (int i = 0; i < items[type]; i++)
            {
                for (int tries = 0; tries < 10; tries++)
                {
                    float x = Random.Range(left, right);
                    float y = Random.Range(bottom, top);
                    bool validPosition = true;
                    foreach (Item other in Object.FindObjectsOfType<Item>())
                    {
                        Bounds placedItemsBounds = new Bounds(new Vector3(x, y, 1), new Vector3(64, 64, 0.1f));
                        if (other.GetComponent<SpriteRenderer>().bounds.Intersects(placedItemsBounds))
                        {
                            validPosition = false;
                            break;
                        }
                    }
                    if (validPosition)
                    {
                        Object.Instantiate(Resources.Load(type), new Vector3(x, y, 1), Quaternion.identity);
                        break;
                    }
                }
            }
        }
    }
}
