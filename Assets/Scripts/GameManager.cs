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

	public int[] totalShots { get; private set; }
	private TextMeshProUGUI[] shotCounters;
	private Gun[] guns;

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

		totalShots = new int[4];
		totalShots[0] = 1;
		totalShots[1] = 1;
		totalShots[2] = 1;
		totalShots[3] = 1;

		shotCounters = new TextMeshProUGUI[4];
		guns = new Gun[4];
	}

	private void Start()
    {
        
    }

	private void Update()
	{
		if (SceneManager.GetActiveScene().buildIndex == 1)
		{
			if (shotCounters.Where(x => x == null).ToList().Count > 0)
			{
				List<TextMeshProUGUI> tmprouguis = FindObjectsOfType<TextMeshProUGUI>().Where(x => x.name == "p1Counter" || x.name == "p2Counter" || x.name == "p3Counter" || x.name == "p4Counter").ToList();
				shotCounters[0] = tmprouguis.Where(x => x.name == "p1Counter").FirstOrDefault();
				shotCounters[1] = tmprouguis.Where(x => x.name == "p2Counter").FirstOrDefault();
				shotCounters[2] = tmprouguis.Where(x => x.name == "p3Counter").FirstOrDefault();
				shotCounters[3] = tmprouguis.Where(x => x.name == "p4Counter").FirstOrDefault();
			}

			if (guns.Where(x => x == null).ToList().Count > 0)
			{
				List<Gun> guns = FindObjectsOfType<Gun>().Where(x => x.name == "p1Barrel" || x.name == "p2Barrel" || x.name == "p3Barrel" || x.name == "p4Barrel").ToList();
				this.guns[0] = guns.Where(x => x.name == "p1Barrel").FirstOrDefault();
				this.guns[1] = guns.Where(x => x.name == "p2Barrel").FirstOrDefault();
				this.guns[2] = guns.Where(x => x.name == "p3Barrel").FirstOrDefault();
				this.guns[3] = guns.Where(x => x.name == "p4Barrel").FirstOrDefault();
			}

			shotCounters[0].text = totalShots[0].ToString();
			shotCounters[1].text = totalShots[1].ToString();
			shotCounters[2].text = totalShots[2].ToString();
			shotCounters[3].text = totalShots[3].ToString();
		}
	}

	public void Double(int player)
	{
		totalShots[player - 1] *= 2;
		shotCounters[player - 1].text = totalShots[player - 1].ToString();
	}

	public void Shoot(int player)
	{
		for (int i = 0; i < totalShots[player - 1]; i++)
		{
			guns[player - 1].Shoot();
		}
		totalShots[player - 1] = 1;
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