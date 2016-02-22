using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour 
{

	public void Quit()
	{
		Application.Quit();
		Debug.Log("The Game Has Quit");
	}

}
