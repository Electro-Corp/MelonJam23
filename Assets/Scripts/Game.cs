// Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Game
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
	public bool playing;

	public bool done;

	public static Game Instance { get; private set; }

	private void Start()
	{
		Instance = this;
		playing = false;
	}

	public void StartGame()
	{
		playing = true;
		done = false;
		Time.timeScale = 1f;
		UIManger.Instance.StartGame();
		Timer.Instance.StartTimer();
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		Time.timeScale = 1f;
		StartGame();
	}

	public void EndGame()
	{
		playing = false;
	}

	public void NextMap()
	{
		Time.timeScale = 1f;
		int buildIndex = SceneManager.GetActiveScene().buildIndex;
		if (buildIndex + 1 >= SceneManager.sceneCountInBuildSettings)
		{
			MainMenu();
			return;
		}
		SceneManager.LoadScene(buildIndex + 1);
		StartGame();
	}

	public void MainMenu()
	{
		playing = false;
		SceneManager.LoadScene("MainMenu");
		UIManger.Instance.GameUI(b: false);
		Time.timeScale = 1f;
	}
}
