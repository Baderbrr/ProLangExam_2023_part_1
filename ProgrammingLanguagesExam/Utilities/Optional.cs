namespace Utilities;

public class Optional
{

	public class Maybe<T>
	{
		private T value;

		public Maybe(T value)
		{
			this.value = value;
		}

		public T Value
		{
			get
			{
				if (!HasValue)
				{
					throw new InvalidOperationException("NULL Exception");
				}
				return value;
			}
		}

		public bool HasValue => this.value == null ? false : true;

		public override string ToString()
		{
			return HasValue ? Value.ToString() : "";
		}
	}

}