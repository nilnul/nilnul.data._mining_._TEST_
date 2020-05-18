using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nilnul.obj;
using nilnul.obj.seq.be_;
using nilnul.stat.dist_.finite_.multivar_.binary;

namespace nilnul.data._mining_._TEST_.apriori
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var samples = new List<Observation>(){
				new Observation(){ "Müşteri", "Aldığı Ürünler" }
				,
				new Observation(){ "Şeker", "Çay", "Ekmek" }
				,
				new Observation() { "Ekmek" , "Peynir" , "Zeytin"  , "Makarna"            }
				,
				new Observation() { "Şeker", "Peynir", "Deterjan", "Ekmek", "Makarna" }
				,
				new Observation(){ "Ekmek", "Peynir", "Çay", "Makarna" }
				,
				new Observation() { "Peynir", "Makarna", "Şeker", "Bira" }
			};

			var support = 0.6;
			var confidence = 0.75;

			var trainer = new Trainer(
				support
				,
				confidence
				,
				samples.ToArray()
			);

			var r = trainer.train().Where(x=>x.Item2 >=confidence);

			r.Each(
				rule =>
				Debug.WriteLine(
					$"{rule.Item1}:{rule.Item2}"
					)
			);



		}

	}

	public class Trainer
	{
		double support;
		/// <summary>
		/// alias:confidence
		/// </summary>
		double confidence;

		Observation[] samples;

		public Trainer(double support, double trust, Observation[] samples)
		{
			this.support = support;
			this.confidence = trust;
			this.samples = samples;
		}

		public nilnul.txt.Bag1 CalculateProductCounts()
		{
			return new nilnul.txt.Bag1(
				samples.SelectMany(s => s)

			);//  Dictionary<string, int>();


		}

		public List<(nilnul.data.mining._associater.Association<string>, double)> train()
		{
			var minSupport = (BigInteger)(samples.Length * support);
			var bag = CalculateProductCounts();

			var supportedRvComponents = new nilnul.txt.Bag1(
				bag.Where(x => x.Value >= minSupport)
			);

			var supportedBagsOld = new nilnul.obj.Bag1<IEnumerable<string>>(
				new NotNull2<IEqualityComparer<IEnumerable<string>>>(
					new nilnul.obj.str_.seq.Eq<string>()
				)
			);

			supportedRvComponents.Each(
				component =>
				{
					supportedBagsOld.add(
						new[] { component.Key }
					);
				}
			);

			var itemSetCardinality = 1;

			while (true)
			{
				//}
				//for (int i = 2; i < supportedBagsOld.Keys.Count; i++)
				//{

				var oldItemSet = new nilnul.txt.Set(supportedBagsOld.Keys.SelectMany(x => x));

				var newSupportedBags = new nilnul.obj.Bag1<IEnumerable<string>>(
					new NotNull2<IEqualityComparer<IEnumerable<string>>>(
						new nilnul.obj.str_.seq.Eq<string>()
					)
				);

				itemSetCardinality++;

				samples.Each(
					s =>
					{
						//
						var intersected = nilnul.set.op_.binary_._IntersectX.Intersect(
							oldItemSet
							,
							s
						);

						var combinated = nilnul.set.family.op_.of_.set_.combinate_._ByIndexsX._Cord_assumeDistinct(
							intersected,
							(uint)(itemSetCardinality)
						);

						combinated.Each(
							combinatedInstance =>
						newSupportedBags.add(
							(
							combinatedInstance
							)
						)
						);

					}

				);
				newSupportedBags.removeKeys_ofFinite(
					newSupportedBags.Where(x => x.Value < minSupport).Select(y => y.Key).ToArray()
				);

				///The algorithm gets terminated when the frequent itemsets cannot be extended further.
				///
				if (newSupportedBags.None())
				{
					break;
				}
				else
				{
					supportedBagsOld = newSupportedBags;
				}

			}

			var ruleSet = new List<(nilnul.data.mining._associater.Association<string>, double)>();
			///now we get the frequent itemSetS.
			///to extract rules from each set.
			///
			foreach (var itemsFreq in supportedBagsOld)
			{
				for (int i = 0; i <= itemsFreq.Key.Count(); i++)
				{
					foreach (
						var combinated in nilnul.set.family.op_.of_.set_.combinate_._ByIndexsX._Cord_assumeDistinct(
							itemsFreq.Key
							,
							i
						)
					)
					{
						var complement =
							itemsFreq.Key.Except(combinated)
						;
						ruleSet.Add(
							(
								new mining._associater.Association<string>(
									combinated
									,
									complement
								)
								,
								nilnul.stat.dist_.finite_.multivar_.binary.observation.str._ConfidenceX.Confidence(
									samples.Select(s => new HashSet<string>(s)), combinated, complement
								)
							//(double) itemsFreq.Value.en  / samples.Count()
							)
						);
					}
				}
			}
			///now we get the ruleGrpS
			///
			return ruleSet;
		}
	}

	public class Observation : List<string>
	{
	}
}
