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

namespace nilnul.data._mining_._TEST_.apriori.breadMilk
{
	[TestClass]
	public class UnitTest11
	{
		[TestMethod]
		public void TestMethod1()
		{
			var samples = new List<O>(){
				new O(){ "bread", "milk" }
				,
				new O(){ "bread",			"pamper", "beer", "egg" }
				,
				new O() {			"milk" , "pamper" , "beer",			"coke"            }
				,
				new O() { "bread", "milk", "pamper", "beer" }
				,
				new O(){ "bread", "milk", "pamper",					"coke" }
			};

			var support = 0.4;
			var confidence = 0.6;

			var trainer = new nilnul.data.mining.associater_.apriori_.TxtItem(
				support
				,
				confidence
				//,
				//samples.ToArray()
			);

			var r = trainer.getRules(samples);//.Where(x=>x.Item2 >=confidence);

			r.Each(
				rule =>
				Debug.WriteLine(
					$"{rule.Item1}:{rule.Item2}"
					)
			);



		}

	}

}
