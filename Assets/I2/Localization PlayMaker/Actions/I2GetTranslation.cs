using HutongGames.PlayMaker;

namespace I2.Loc
{
	[ActionCategory("I2 Localization")]
	[Tooltip("Set the localization CurrentLanguage ")]
	public class I2GetTranslation : FsmStateAction
	{

        public LanguageSource mSource;
        public LanguageSourceAsset mAsset;

        public I2LocPlayMaker_SelectionMode SelectionMode = I2LocPlayMaker_SelectionMode.Selection;

		[Tooltip("The Term to Translate")]
		public FsmString term;

        [Tooltip("The resulting translation")]
        public FsmString translation;


		public override void Reset()
		{
			term = null;
			translation = null;
		}

		public override void OnEnter()
		{
            string termTranslation = null;
            if (mSource != null) mSource.mSource.GetTranslation(term.Value);
            else
            if (mAsset != null) mAsset.mSource.GetTranslation(term.Value);
            else
                termTranslation = LocalizationManager.GetTranslation(term.Value);

		    if (!translation.IsNone)
		        translation.Value = termTranslation;

			Finish();
		}
	}
}