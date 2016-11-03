using UnityEngine;
using System.Collections;

// Countup timer will be ture until the timer has ended
public class CountupTimer : BaseTimer
{
	public override void SetTime (float t)
	{
		time = t;
	}

	public override void BeginTimer()
	{
		endTime = Time.fixedTime - time;
	}
		
	public override bool Ended()
	{
		return Time.fixedTime < endTime;
	}
}
