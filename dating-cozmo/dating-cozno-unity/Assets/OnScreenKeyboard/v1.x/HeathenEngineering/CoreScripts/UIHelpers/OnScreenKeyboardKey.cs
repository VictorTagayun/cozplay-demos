using UnityEngine;
using System.Collections;

namespace HeathenEngineering.OSK.v1
{
	/// <summary>
	/// On screen keyboard key.
	/// Represents a key and stores values used by the keyboard on press events
	/// </summary>
	[AddComponentMenu("Heathen/OSK/v1/On Screen Keyboard Key (v1.0)")]
	public class OnScreenKeyboardKey : MonoBehaviour
	{
		[HideInInspector]
		public OnScreenKeyboard Keyboard;
		public KeyClass type = KeyClass.String;
		public string LowerCaseValue = "a";
		public string UpperCaseValue = "A";
		public Renderer ButtonRenderer;
		public TextMesh Text;
		public OnScreenKeyboardKey LeftKey;
		public OnScreenKeyboardKey RightKey;
		public OnScreenKeyboardKey UpKey;
		public OnScreenKeyboardKey DownKey;

		// Use this for initialization
		void Start ()
		{
			if(LeftKey == null
			   || RightKey == null
			   || UpKey == null
			   || DownKey == null)
				Debug.LogError("One or more navigation links are missing on the OnScreenKeyboardKey; insure LeftKey, RightKey, UpKey, DownKey are populated.", this);
		}

		// Update is called once per frame
		void Update ()
		{

		}

		/// <summary>
		/// Presses the key.
		/// This can be called to simulate a press event on this specific key
		/// </summary>
		public void PressKey()
		{
			if(Keyboard != null)
			{
				Keyboard.ActiveKey = this;
				Keyboard.ActivateKey();
			}
			else
				Debug.LogError("An OnScreenKeyboardKey was pressed but does not have an owning keyboard; insure the key is a child of an OnScreenKeyboard", this);
		}
		/// <summary>
		/// Sets the case for this key by updating the text mesh object.
		/// Special handlig is done for keys with no upper string value such as space
		/// </summary>
		/// <param name="ToUpper">If set to <c>true</c> to upper.</param>
		public void SetCase(bool ToUpper)
		{
			//Handel space special so it can render text but not have a text value
			if(type == KeyClass.String && string.IsNullOrEmpty(UpperCaseValue.Trim()))
				Text.text = "_";
			else
			{
				if(ToUpper)
					Text.text = UpperCaseValue;
				else
					Text.text = LowerCaseValue;
			}
		}
	}
	/// <summary>
	/// Key class.
	/// Defines the type of key this is and is used by the OnScreenKeyboard to perform special actions for non string keys
	/// </summary>
	public enum KeyClass
	{
		String,
		Shift,
		Return,
		Backspace
	}
}
