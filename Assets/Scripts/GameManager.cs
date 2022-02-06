using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	//Singleton pattern
	private static GameManager instance = null;
	public static GameManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<GameManager>();
			}
			return instance;
		}
	}

	public float volume;

	public List<int> totalShots { get; private set; }
	public List<TextMeshProUGUI> shotCounters;

	private void Awake()
	{
		//Singleton pattern
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
	}

	private void Start()
    {
        
    }

	private void Update()
	{
		
	}

	public void addShots(int shots, int player)
	{
		totalShots[player - 1] += shots;
		shotCounters[player - 1].text = totalShots[player - 1].ToString();
	}

	public IEnumerator SlowLoadScene(int scene, Image transition)
	{
		for (int i = 0; i < 100; i++)
		{
			transition.color = new Color(1 - i / 100f, 1 - i / 100f, 1 - i / 100f, i / 100f);
			yield return new WaitForSeconds(0.01f);
		}

		SceneManager.LoadScene(scene);
		yield return null;
	}
}