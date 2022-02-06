using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
	[SerializeField] private List<Menu> menuObjects = new List<Menu>();
	private Dictionary<MenuType, Menu> menus = new Dictionary<MenuType, Menu>();
	private MenuType currentMenu;
	[SerializeField] private Image transition;

	private static MenuManager instance = null;
	public static MenuManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<MenuManager>();
			}
			return instance;
		}
	}

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		if (instance != this)
		{
			Destroy(gameObject);
		}

		// Set the currentMenu to the Main Menu
		currentMenu = MenuType.Main;
		foreach (Menu m in menuObjects)
		{
			menus.Add(m.menuType, m);
		}
	}

	public void NextScene()
	{
		GameManager.Instance.StartCoroutine(GameManager.Instance.SlowLoadScene(SceneManager.GetActiveScene().buildIndex + 1, transition));
	}

	// This one works for buttons
	public void OpenMenu(int t)
	{
		// Cast the int to MenuType enum
		MenuType menuType = (MenuType)t;

		OpenMenu(menuType);
	}

	// This one doesn't work for buttons, as unity doesn't accept enums in buttons
	public void OpenMenu(MenuType menuType)
	{
		if (currentMenu == menuType)
		{
			return;
		}

		menus[currentMenu].Close();
		menus[menuType].Open();
		currentMenu = menuType;
	}

	public void Quit()
	{
		Application.Quit();
	}
}