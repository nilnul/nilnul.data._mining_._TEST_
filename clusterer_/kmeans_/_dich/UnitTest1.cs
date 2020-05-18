using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace nilnul.data._mining_._TEST_.clusterer_.kmeans
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var points = new List<nilnul.geometry.planar.PointDbl>() {
				new geometry.planar.PointDbl(1,1)
				,
				new geometry.planar.PointDbl(2,1.5)
				,
				new geometry.planar.PointDbl(4,3.5)
				,
				new geometry.planar.PointDbl(5,4.5)
				,
				new geometry.planar.PointDbl(3.5,5)
			};

			var k = 2;

			//var centers = new nilnul.geometry.planar.PointDbl[k];
			//centers[0] = points[0];
			//centers[1] = points[1];
			var center0 = points[0];
			var center1 = points[1];

			var distance4center0 = points.Select(p => nilnul.geometry.planar.span._DistanceX.Distance(p, center0)).ToArray();

			var distance4center1 = points.Select(p => nilnul.geometry.planar.span._DistanceX.Distance(p, center1)).ToArray();
			var indexes = Enumerable.Range(0, points.Count);// distance4center0.Select((e, i) => i).ToArray();

			var indexes0 =indexes.Where(i => distance4center0[i] <= distance4center1[i]);
			var indexes1 = indexes.Except(indexes0);

			var newCenter0 = nilnul.geometry.planar.points_.started._CenterX._Center_assumeStarted(
				points.Where((e, i) => indexes0.Contains(i))
			);
			var newCenter1 = nilnul.geometry.planar.points_.started._CenterX._Center_assumeStarted(
				points.Where((e, i) => indexes1.Contains(i))
			);

			while ((newCenter0, newCenter1) != (center0, center1))
			{
				center0 = newCenter0;
				center1 = newCenter1;
				 distance4center0 = points.Select(p => nilnul.geometry.planar.span._DistanceX.Distance(p, center0)).ToArray();

				 distance4center1 = points.Select(p => nilnul.geometry.planar.span._DistanceX.Distance(p, center1)).ToArray();

				 indexes0 = indexes.Where(i => distance4center0[i] <= distance4center1[i]);
				 indexes1 = indexes.Except(indexes0);

				 newCenter0 = nilnul.geometry.planar.points_.started._CenterX._Center_assumeStarted(
					points.Where((e, i) => indexes0.Contains(i))
				);
				 newCenter1 = nilnul.geometry.planar.points_.started._CenterX._Center_assumeStarted(
					points.Where((e, i) => indexes1.Contains(i))
				);
			}
		}
	}
}
