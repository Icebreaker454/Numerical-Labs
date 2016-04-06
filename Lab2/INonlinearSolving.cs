using System;

namespace Lab2
{
	public interface INonlinearSolving
	{
		double Result();
		double[] NextResult(double[] x);
	}

	public abstract class NonlinearSolving : INonlinearSolving
	{
		protected double[] baseResult;
		protected double eps;
		public int iterations = 0;

		public abstract double[] NextResult(double[] x);

		public double Result()
		{
			double[] current = this.baseResult;
			double[] next = NextResult (current);
			while (Math.Abs (current [0] - current [1]) > this.eps) 
			{
				current = next;
				next = NextResult (current);
			}
			return (current[0] + current[1]) / 2.0;
		}
	}
}

