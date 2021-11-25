using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using Assets.Scripts.Test;
using UnityEngine;
using Random = System.Random;

public class T_LoadGround : MonoBehaviour
{

    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera3;
    public GameObject Camera4;

    private GameObject GroundPrefab;
    private GameObject LastDefatulGround;

    private GameObject _respawn;
    private int _numberOfDefaultGrounds;
    private int _gorundCounter;


	// Use this for initialization
	void Start ()
	{
        _numberOfDefaultGrounds = GlobalSettings.Settings.NumberOfStartGrounds;
        _gorundCounter = GlobalSettings.Settings.NumberOfStartGrounds;

	    GroundPrefab = GlobalSettings.Settings.GroundPrefab;

	    LoadGrounds();
	    CreateDestroyer();
	    CreateRespawn();

	    string playerId = this.gameObject.name.Substring(this.gameObject.name.Length - 1, 1);
        
        CreatePlayer(Convert.ToInt32(playerId));
	}

    private void LoadGrounds()
    {
        for (int i = 0; i < _numberOfDefaultGrounds; i++)
        {
            float x = this.gameObject.transform.position.x;
            float y = this.gameObject.transform.position.y;
            float z = (GroundPrefab.transform.position.z + GroundPrefab.GetComponent<Renderer>().bounds.size.z) * i;

            GameObject newGround = Instantiate(GroundPrefab, new Vector3(x, y, z), Quaternion.identity);

            newGround.AddComponent<T_MovingGround>();

            newGround.name = "Ground " + (i+1);

            if (i == _numberOfDefaultGrounds-1)
            {
                LastDefatulGround = newGround;
            }
        }
    }

    private void CreatePlayer(int playerId)
    {
        GameObject player = GameObject.CreatePrimitive(PrimitiveType.Cube);

        float x = this.gameObject.transform.position.x;
        float y = this.gameObject.transform.position.y+1;
        float z = this.gameObject.transform.position.z+5;

        player.transform.position = new Vector3(x,y,z);

        player.AddComponent<Rigidbody>();
        player.GetComponent<Rigidbody>().freezeRotation = true;
        player.AddComponent<T_Moving>();

        player.name = "Player" + playerId;
        player.tag = "Player" + playerId;

        player.GetComponent<Renderer>().material = GlobalSettings.Settings.GlobalMaterilas.FirstOrDefault(m => m.name == player.name);
    }

    private void CreateDestroyer()
    {
        GameObject destroyer = GameObject.CreatePrimitive(PrimitiveType.Cube);

        float x = this.gameObject.transform.position.x;
        float y = this.gameObject.transform.position.y;
        float z = GroundPrefab.transform.position.z - GroundPrefab.GetComponent<Renderer>().bounds.size.z;
        destroyer.transform.position = new Vector3(x,y,z);

        float localScaleX = GroundPrefab.transform.localScale.x;
        destroyer.transform.localScale = new Vector3(localScaleX,5,1);

        destroyer.GetComponent<BoxCollider>().isTrigger = true;

        destroyer.GetComponent<MeshRenderer>().enabled = false;

        destroyer.transform.parent = this.gameObject.transform;

        destroyer.AddComponent<T_Destroy>();

        destroyer.name = "Destroyer";
    }

    private void CreateRespawn()
    {
        _respawn = GameObject.CreatePrimitive(PrimitiveType.Cube);

        _respawn.transform.position = LastDefatulGround.transform.position;

        float localScaleX = GroundPrefab.transform.localScale.x;
        _respawn.transform.localScale = new Vector3(localScaleX, 5, 1);

        _respawn.transform.parent = this.gameObject.transform;

        _respawn.GetComponent<MeshRenderer>().enabled = false;

        _respawn.name = "Respawn";
    }

    public void CrateNewGround()
    {
        System.Random rnd = new System.Random();

        _gorundCounter++;

        GameObject ground = GlobalSettings.Settings.GroundPrefabs[rnd.Next(0,GlobalSettings.Settings.GroundPrefabs.Count)];

        GameObject newGround = Instantiate(ground, _respawn.transform.position, Quaternion.identity);

        newGround.AddComponent<T_MovingGround>();

        newGround.name = "Ground " + _gorundCounter;
    }

    
}
