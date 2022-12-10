using UnityEngine;

namespace HutongGames.PlayMaker.Actions

{
    [ActionCategory(ActionCategory.Application)]
    [Tooltip("Get the Application Streaming Assets Path")]
    public class ApplicationGetStreamingAssetsPath : FsmStateAction
	{

		[RequiredField]
		[Tooltip("The Application Streaming Assets Path")]
		[UIHint(UIHint.Variable)]
		public FsmString streamingAssetsPath;

		[Tooltip("If true, adds a path delimiter '/' at the end of the path")]
		public bool appendPathDelimiter;

		public override void Reset()
		{
			streamingAssetsPath = null;
			appendPathDelimiter = true;
		}

		public override void OnEnter()
		{
			streamingAssetsPath.Value = Application.streamingAssetsPath;

			if (appendPathDelimiter)
			{
				streamingAssetsPath.Value += "/";
			}

			Finish();
		}
	}
}