using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
	public GameObject button;
	private AudioSource audioSource;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}
	public void puton()
    {
		audioSource.Play();
    }

}
