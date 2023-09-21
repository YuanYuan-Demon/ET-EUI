﻿namespace ET
{
	public class NumericWatcherAttribute : BaseAttribute
	{
		public SceneType SceneType { get; }

		public NumericType NumericType { get; }

		public NumericWatcherAttribute(SceneType sceneType, NumericType type)
		{
			this.SceneType = sceneType;
			this.NumericType = type;
		}
	}
}