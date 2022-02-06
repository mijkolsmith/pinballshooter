using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetInput : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI InputField;
	private bool waitingForKey = false;
	private Event keyEvent;
	private KeyCode keyName;

	private void Update()
	{
		InputField.text = PlayerPrefs.GetString(InputField.gameObject.name);
	}

	private void OnGUI()
	{
		keyEvent = Event.current;

		if(keyEvent.isKey && waitingForKey)
		{
			keyName = keyEvent.keyCode;
			waitingForKey = false;
		}
	}

	public void StartAssignment()
	{
		if (!waitingForKey)
		{
			StartCoroutine(AssignKey());
		}
	}

	private IEnumerator AssignKey()
	{
		waitingForKey = true;

		while (!keyEvent.isKey)
		{
			yield return null;
		}

		PlayerPrefs.SetString(InputField.gameObject.name, keyName.ToString());

		yield return null;
	}
}