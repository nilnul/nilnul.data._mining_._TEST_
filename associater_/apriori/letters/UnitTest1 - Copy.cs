using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nilnul.obj;
using nilnul.obj.seq.be_;
using nilnul.stat.dist_.finite_.multivar_.binary;
using O = nilnul.data.mining.associater_.apriori_._txtItem.Observation;

namespace nilnul.data._mining_._TEST_.apriori.letters
{
	[TestClass]
	public class UnitTest11
	{
		[TestMethod]
		public void TestMethod1()
		{
			var sample = new List<O>(){
				new O(){ "A", "C", "S", "L" }
				,
				new O(){ "D",			"A", "C", "E","B" }
				,
				new O() {			"A" , "B" , "C"            }
				,
				new O() { "C", "A", "B", "E" }
			};

			var support = 0.6;
			var confidence = 0.9;

			var trainer = new nilnul.data.mining.associater_.apriori_.TxtItem(
				support
				,
				confidence
				//,
				//samples.ToArray()
			);

			var r = trainer.getRules(sample);//.Where(x=>x.Item2 >=confidence);

			r.Each(
				rule =>
				Debug.WriteLine(
					$"{rule.Item1}:{rule.Item2}"
					)
			);



		}

	}

}
