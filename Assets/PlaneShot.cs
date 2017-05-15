using UnityEngine;
using UnityEngine.UI;

public class PlaneShot : MonoBehaviour
{
	public int cam_m_PlayerNumber = 1;              // Used to identify the different players.
	public Rigidbody cam_m_Shell;                   // Prefab of the shell.
	public Transform cam_m_FireTransform;           // A child of the tank where the shells are spawned.
	public AudioSource cam_m_ShootingAudio;         // Reference to the audio source used to play the shooting audio. NB: different to the movement audio source.
	public AudioClip cam_m_FireClip;                // Audio that plays when each shot is fired.
	public float LaunchForce = 15f;        // The force given to the shell if the fire button is not held.



	private string cam_m_FireButton;                // The input axis that is used for launching shells.
	private float cam_m_CurrentLaunchForce;         // The force that will be given to the shell when the fire button is released.
	private bool cam_m_Fired;                       // Whether or not the shell has been launched with this button press.

	private void Start()
	{
		// The fire axis is based on the player number.
		cam_m_FireButton = "Fire" + cam_m_PlayerNumber;
	}


	private void Update()
	{
		//FireCamera();

		// Otherwise, if the fire button has just started being pressed...
		if (Input.GetButtonDown(cam_m_FireButton))
		{
			// ... reset the fired flag and reset the launch force.
			cam_m_Fired = false;
			cam_m_CurrentLaunchForce = LaunchForce;
		}
		// Otherwise, if the fire button is being held and the shell hasn't been launched yet...
		else if (Input.GetButton(cam_m_FireButton) && !cam_m_Fired)
		{
			// Increment the launch force and update the slider.
			cam_m_CurrentLaunchForce = LaunchForce;
		}
		// Otherwise, if the fire button is released and the shell hasn't been launched yet...
		else if (Input.GetButtonUp(cam_m_FireButton) && !cam_m_Fired)
		{
			// ... launch the shell.
			FireCamera();
		}
	}


	private void FireCamera()
	{
		// Set the fired flag so only Fire is only called once.
		cam_m_Fired = true;

		// Create an instance of the shell and store a reference to it's rigidbody.
		Rigidbody shellInstance =
			Instantiate(cam_m_Shell, cam_m_FireTransform.position, cam_m_FireTransform.rotation, GameObject.Find("Game").transform) as Rigidbody;

		// Set the shell's velocity to the launch force in the fire position's forward direction.
		shellInstance.velocity = cam_m_CurrentLaunchForce * cam_m_FireTransform.forward;

		// Change the clip to the firing clip and play it.
		cam_m_ShootingAudio.clip = cam_m_FireClip;
		cam_m_ShootingAudio.Play();

		// Reset the launch force.  This is a precaution in case of missing button events.
		cam_m_CurrentLaunchForce = LaunchForce;
	}
}