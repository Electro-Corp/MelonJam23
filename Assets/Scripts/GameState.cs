// Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// GameState
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GameState : MonoBehaviour
{
	public GameObject ppVolume;

	public PostProcessProfile pp;

	private MotionBlur ppBlur;

	public bool graphics = true;

	public bool muted;

	public bool blur = true;

	public bool shake = true;

	public bool slowmo = true;

	private float sensitivity = 1f;

	private float volume;

	private float music;

	public float fov = 1f;

	public float cameraShake = 1f;

	public static GameState Instance { get; private set; }

	private void Start()
	{
		Instance = this;
		ppBlur = pp.GetSetting<MotionBlur>();
		UpdateSettings();
	}

	public void SetGraphics(bool b)
	{
		graphics = b;
		ppVolume.SetActive(b);
	}


	public void SetShake(bool b)
	{
		shake = b;
		if (b)
		{
			cameraShake = 1f;
		}
		else
		{
			cameraShake = 0f;
		}
	}

	public void SetSlowmo(bool b)
	{
		slowmo = b;
	}

	public void SetSensitivity(float s)
	{
		float num = (sensitivity = Mathf.Clamp(s, 0f, 5f));
		if ((bool)PlayerMovement.Instance)
		{
			PlayerMovement.Instance.UpdateSensitivity();
		}
	}

	public void SetVolume(float s)
	{
		float num2 = (AudioListener.volume = (volume = Mathf.Clamp(s, 0f, 1f)));
	}

	public void SetFov(float f)
	{
		float num = (fov = Mathf.Clamp(f, 50f, 150f));
		if ((bool)MoveCamera.Instance)
		{
			MoveCamera.Instance.UpdateFov();
		}
	}

	public void SetMuted(bool b)
	{
		muted = b;
	}

	private void UpdateSettings()
	{
		SetGraphics(graphics);
		SetSensitivity(sensitivity);
		SetVolume(volume);
		SetFov(fov);
		SetShake(shake);
		SetSlowmo(slowmo);
		SetMuted(muted);
	}

	public bool GetGraphics()
	{
		return graphics;
	}

	public float GetSensitivity()
	{
		return sensitivity;
	}

	public float GetVolume()
	{
		return volume;
	}

	public float GetMusic()
	{
		return music;
	}

	public float GetFov()
	{
		return fov;
	}

	public bool GetMuted()
	{
		return muted;
	}
}
