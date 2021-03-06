using UnityEngine;
using System;

namespace HexCasters.Core.Grid
{
	/// <summary>
	/// A position in the board.
	/// </summary>
	/// <remarks>
	/// (0, 0) is the board center, rounded to the lower left if it has an
	/// even number of rows and/or columns.
	/// </remarks>
	[System.Serializable]
	public struct BoardPosition
	{
		[SerializeField]
		private int _x;

		[SerializeField]
		private int _y;

		/// <summary>
		/// X axis displacement from the board center.
		/// </summary>
		public int X
		{
			get { return _x; }
			private set { _x = value; }
		}

		/// <summary>
		/// Y axis displacement from the board center.
		/// </summary>
		public int Y
		{
			get { return _y; }
			private set { _y = value; }
		}

		/// <summary>
		/// Displacement from the Z = 0 axis.
		/// </summary>
		public int Z
		{
			get { return -(this.X + this.Y); }
		}

		public BoardPosition(int x, int y)
		{
			this._x = x;
			this._y = y;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is BoardPosition))
				return false;
			var other = (BoardPosition) obj;
			return this.X == other.X && this.Y == other.Y;
		}

		public override int GetHashCode()
		{
			return Tuple.Create(this.X, this.Y).GetHashCode();
		}

		public override string ToString()
		{
			return $"({this.X}, {this.Y}, {this.Z})";
		}
	}
}