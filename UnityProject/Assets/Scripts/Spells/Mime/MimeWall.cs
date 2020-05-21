public class MimeWall : Spell
{

	public override bool ValidateCast(ConnectedPlayer caster)
	{
		if (!base.ValidateCast(caster))
		{
			return false;
		}

		if (caster.Script.mind.occupation.JobType != JobType.MIME ||
		    caster.Script.mind.GetPropertyOrDefault("brokeVowOfSilence", false))
		{
			Chat.AddExamineMsg(caster.GameObject, "You must dedicate yourself to silence first!");
			return false;
		}

		return true;
	}
}