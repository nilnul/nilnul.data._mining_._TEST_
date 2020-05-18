using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace nilnul.data._mining_._TEST_.clusterer_.kmeans_.dich
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

			var kmeans = new nilnul.geometry.planar.points.clusterer_.kmeans_.Dichonotomy(points);

			var (indexes0, indexes1) = kmeans.mine();

			// kmeans = new nilnul.geometry.planar.points.clusterer_.kmeans_.Dichonotomy(
			//	 points
			//	 ,
			//	 new[] {
			//		 new geometry.planar.PointDbl()
			//		 ,
			//		 new geometry.planar.PointDbl(1,1)

			//	 }
			//);

			// (indexes0, indexes1) = kmeans.mine();



		}
	}
}
