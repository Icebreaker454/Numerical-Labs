using System;

namespace Lab2
{
	public static class Equation
	{
		public static double F(double x)
		{
			return 2.0 * Math.Cos (x / 2.0) - Math.Pow (x, 3) + 1.0;
		}
	}
}

