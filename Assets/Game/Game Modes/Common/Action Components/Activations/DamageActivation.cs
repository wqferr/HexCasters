using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using HexCasters.Core.Units;
using HexCasters.Core.Actions;
using HexCasters.Core.Grid;

namespace HexCasters.GameModes.Common
{
	public class DamageActivation : ActionActivation
	{
		public int damage;

		public override void Perform(
			BoardCellContent actor,
			IEnumerable<BoardCell> targets,
			IEnumerable<BoardCell> aoe)
		{
			var affectedHPs = aoe
				.Select(cell => cell.Content)
				.Select(content => content?.GetComponent<HP>())
				.Where(hp => hp != null);
			foreach (var hp in affectedHPs)
			{
				hp.Decrease(this.damage);
			}
		}

		public override void Cleanup(IEnumerable<BoardCell> aoe)
		{
			var affectedHPs = aoe
				.Select(cell => cell.Content)
				.Select(content => content?.GetComponent<HP>())
				.Where(hp => hp != null);
			foreach (var hp in affectedHPs)
			{
				hp.Commit();
			}
		}
	}
}