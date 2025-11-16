using UnityEngine;
using System.Collections;
using System.IO;

public class InitializeLevel : MonoBehaviour
{
    private StreamReader reader;
    void Start()
    {
        // Creates the walls and pillars
        for (int i = 0; i < 1000; i += 10)
        {
            GameObject leftPillar = (GameObject)Instantiate(Resources.Load("Pillar"));
            leftPillar.transform.position = new Vector3(-5.0f, 0, i);

            GameObject rightPillar = (GameObject)Instantiate(Resources.Load("Pillar"));
            rightPillar.transform.position = new Vector3(5.0f, 0, i);
        }

        // Loads gems from file
        LoadGems("gem_data.txt");
    }

	// Loads gem positions from a text file and instantiates them in the scene
	void LoadGems(string filename)
    {
        try
        {
            // Opens the file from the Assets folder
            reader = new StreamReader(Application.dataPath + "/" + filename);

            string dataline = reader.ReadLine();   // Reads first line

            while (dataline != null)
            {
                dataline = dataline.Trim();

                // Skips empty lines and comments that start with '#'
                if (dataline.Length == 0 || dataline.StartsWith("#"))
                {
                    dataline = reader.ReadLine();
                    continue;
                }

                // Expects gem_name, x, y, z
                string[] values = dataline.Split(',');

                if (values.Length == 4)
                {
                    string gemName = values[0].Trim();

                    float x = float.Parse(values[1]);
                    float y = float.Parse(values[2]);
                    float z = float.Parse(values[3]);

                    Vector3 pos = new Vector3(x, y, z);

                    // Loads prefab from Resources folder
                    GameObject gemPrefab = (GameObject)Resources.Load(gemName);

                    if (gemPrefab != null)
                    {
                        Instantiate(gemPrefab, pos, Quaternion.identity);
                    }
                    else
                    {
                        Debug.LogWarning("Could not load gem prefab: " + gemName);
                    }
                }
                else
                {
                    Debug.LogWarning("Invalid line in gem file: " + dataline);
                }

                // Reads the next line
                dataline = reader.ReadLine();
            }
        }
        catch (IOException e) // Handle file I/O errors
        {
            Debug.LogError("Error reading gem file: " + e.Message);
        }
        finally
        {
            if (reader != null)
                reader.Close();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
