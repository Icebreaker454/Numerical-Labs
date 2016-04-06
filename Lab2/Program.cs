using System;

namespace Lab2
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Nonlinear Equation Solving Methods, v1.0");
			Console.WriteLine ("by Paul Pukach a.k.a. Icebreaker");
			Console.WriteLine ("");
			/*
			Console.WriteLine ("Enter the desired precision (default = 1E-3)");
			double eps;
			try
			{
				eps = double.Parse (Console.ReadLine ());
			}
			catch
			{
				eps = 1E-3;
			}
			Console.WriteLine ("Enter the X range [a, b]:");
			var a = double.Parse (Console.ReadLine ());
			var b = double.Parse (Console.ReadLine ());

			NonlinearSolving method = new Dychotomy (new double[]{a, b}, eps);
			var baseResult = (method as Dychotomy).Result ();
			Console.WriteLine ("Dychotomy:");
			Console.WriteLine ("Result: " + baseResult);
			Console.WriteLine ("Iterations: " + method.iterations);
			Console.WriteLine ("F(result) = " + Equation.F (baseResult));

			Console.WriteLine ("Enter the desired precision for Iteration method (default = 1E-5)");
			try
			{
				eps = double.Parse (Console.ReadLine ());
			}
			catch
			{
				eps = 1E-5;
			}
			method = new IterationMethod (baseResult, eps);
			var result = (method as IterationMethod).Result ();

			Console.WriteLine ("");
			Console.WriteLine ("Iteration Method:");
			Console.WriteLine ("Result: " + result);
			Console.WriteLine ("Iterations: " + method.iterations);

			Console.WriteLine ("F(result) = " + Equation.F (result)); */
			var eps = 1E-3;
			Console.WriteLine ("Enter the desired precision for Dychotomy method (default = 1E-3)");
			try
			{
				eps = double.Parse (Console.ReadLine ());
			}
			catch
			{
				eps = 1E-3;
			}

			Console.WriteLine ("Enter the X range [a, b]:");
			var a = double.Parse (Console.ReadLine ());
			var b = double.Parse (Console.ReadLine ());

			NonlinearSolving method = new Dychotomy (new double[]{a, b}, eps);
			var baseResult = (method as Dychotomy).Result ();
			Console.WriteLine ("Dychotomy:");
			Console.WriteLine ("Result: " + baseResult);
			Console.WriteLine ("Iterations: " + method.iterations);
			Console.WriteLine ("F(result) = " + Equation.F (baseResult));


			Console.WriteLine ("Enter the desired precision for Cord method (default = 1E-7)");
			try
			{
				eps = double.Parse (Console.ReadLine ());
			}
			catch
			{
				eps = 1E-7;
			}

			CordMethod m = new CordMethod (eps);
			double res = m.Result ((method as Dychotomy).temp);

			Console.WriteLine ("");
			Console.WriteLine ("Cord Method:");
			Console.WriteLine ("Result: " + res);
			Console.WriteLine ("Iterations: " + m.iterations);
			Console.WriteLine ("F(result) = " + Equation.F (res));
		}
	}
}
