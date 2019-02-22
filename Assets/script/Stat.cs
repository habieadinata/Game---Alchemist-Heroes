using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour {

	[SerializeField]
	private float lerpSpeed;

	[SerializeField]
	private Text valueText;
	private Image content;
	private float MyMaxValue { get; set; }
	private float currentFill;

	public float MycurrentValue
	{
		get
		{
			return currentValue;
		}

		set 
		{
			if (value > MyMaxValue) {
				currentValue = MyMaxValue;
			} else if (value < 0) {
				currentValue = 0;
			} else 
			{
				currentValue = value;
			}

			currentFill = currentValue / MyMaxValue;
			valueText.text = currentValue + "/" + MyMaxValue;
		}
	}

	private float currentValue;



	// Use this for initialization
	void Start () {
		content = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentFill != content.fillAmount) {
			content.fillAmount = Mathf.Lerp (content.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
		}
	}

	public void Init (float currentValue, float maxValue){
		MyMaxValue = maxValue;
		MycurrentValue = currentValue;
	}
}
