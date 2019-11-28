using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Event
{
	[SerializeField]
	private int eventID;

	[SerializeField]
	private string eventName;

	[SerializeField]
	public bool completed;

	public void SetCompleted()
	{
		completed = true;
		Debug.Log("Event ID: " + eventID + " completed.");
	}

	public bool GetCompleted() { return completed; }
}

public class EventController : MonoBehaviour
{
	public List<Event> events = new List<Event>();

	#region Singleton
	public static EventController instance;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance of EventController found!");
		}

		instance = this;
	}
	#endregion


}
