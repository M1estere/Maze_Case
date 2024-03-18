using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("_timerText", "_currentTime")]
	public class ES3UserType_Countdown : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Countdown() : base(typeof(Countdown)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (Countdown)obj;
			
			writer.WritePrivateFieldByRef("_timerText", instance);
			writer.WritePrivateField("_currentTime", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (Countdown)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "_timerText":
					instance = (Countdown)reader.SetPrivateField("_timerText", reader.Read<TMPro.TMP_Text>(), instance);
					break;
					case "_currentTime":
					instance = (Countdown)reader.SetPrivateField("_currentTime", reader.Read<System.Single>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_CountdownArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_CountdownArray() : base(typeof(Countdown[]), ES3UserType_Countdown.Instance)
		{
			Instance = this;
		}
	}
}