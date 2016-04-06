using System;

namespace Lab2
{
	public class Dychotomy : NonlinearSolving
	{
		public double[] temp;

		public Dychotomy (double[] baseResult, double presicion)
		{
			this.baseResult = baseResult;
			this.eps = presicion;
		}

		public override double[] NextResult(double[] currentResult)
		{
			double x1 = currentResult [0];
			double x2 = currentResult [1];
			Console.WriteLine ("Result #" + ++iterations + ": [" + x1 + ", " + x2 + "]");
			double middle = (x1 + x2) / 2.0;
			if (Equation.F (x1) * Equation.F (middle) < 0) 
			{
				temp = new double[] { x1, middle };
				return temp;
			}
			temp = new double[] { middle, x2 };
			return temp;
		}

	}

	public class IterationMethod : NonlinearSolving
	{
		new double baseResult;
		public double[] temp;

		public IterationMethod(double x, double eps)
		{
			this.baseResult = x;
			this.eps = eps;
		}


		public override double[] NextResult(double[] currentResult)
		{
			double c = currentResult [0];
			double next = Math.Pow ((2 * Math.Cos (c / 2.0) + 1), 1.0 / 3.0);
			Console.WriteLine ("Result #" + ++iterations + ": [" + next + "]");
			return new double[] { next };
		}

		public new double Result()
		{
			double current = this.baseResult;
			double next = NextResult (new double[] { current }) [0];
			this.temp = new double[2];

			while (Math.Abs (next - current) > eps) 
			{
				current = next;
				temp = NextResult (new double[] { current });
				next = temp [0];
			}

			return current;
		}
	}

	public class CordMethod
	{
		public double eps;

		public int iterations = 0;
	
		public CordMethod(double eps)
		{
			this.eps = eps;
		}

		public double[] nextResult(double[] previous)
		{
			// cr = x_n;
			// pr = x_(n-1);
			// nr = x_(n+1);
			var cr = previous [1];
			var pr = previous [0];
			var nr = cr - (Equation.F (cr) * (cr - pr)) / (Equation.F (cr) - Equation.F (pr));
			return new double[] { cr, nr };
		}

		public double Result(double[] baseResult)
		{
			double[] next = nextResult (baseResult);
			Console.WriteLine ("Base Result: [" + next[0] + ", " + next[1] + "]");
			while (Math.Abs (next [1] - next [0]) > eps)
			{
				baseResult = next;
				next = nextResult (baseResult);
				Console.WriteLine ("Result #" + ++iterations + ": [" + next[1] + "]");
			}
			return next [1];
		}
	}
}

