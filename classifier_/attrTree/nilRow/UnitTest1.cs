using System;
using System.Linq;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace nilnul.data._mining_._TEST_.classifier_.attrTree_.nilRows
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var fs = new[] {
//				@"D:\170203\data\nilnul.data._mining_\_TEST_(Git\Resources\normal\attrTree.csv"
//,@"D:\170203\data\nilnul.data._mining_\_TEST_(Git\Resources\someColDefinite\attrTree.csv"
//,
//			@"D:\170203\data\nilnul.data._mining_\_TEST_(Git\Resources\allCandidatesDefinite\attrTree.csv"
//,
//				@"D:\170203\data\nilnul.data._mining_\_TEST_(Git\Resources\infoNotNuf\attrTree.csv"
//,
//			@"D:\170203\data\nilnul.data._mining_\_TEST_(Git\Resources\lastColDefinte\attrTree.csv"
//,
//			@"D:\170203\data\nilnul.data._mining_\_TEST_(Git\Resources\colsAllCorrelate\attrTree.csv"
//,
//				@"D:\170203\data\nilnul.data._mining_\_TEST_(Git\Resources\nilCols\attrTree.csv"
//,
				@"D:\170203\data\nilnul.data._mining_\_TEST_(Git\Resources\nilRows\attrTree.csv"
			};

			for (int i = 0; i < fs.Length; i++)
			{
				var f = fs[i];
				Mine(f);
			}
		}

		public void Mine(string f)
		{
			var r = nilnul.data.mining.classifier_._TreedX.GenerateTree_ofBlob(
				System.IO.File.ReadAllText(
					f
				)
			); ;

			var tree = nilnul.data.mining.classifier_._TreedX._ToTree(r);

			var layout = nilnul.rel_.net_.tree_.positioned_.arcNamed.graph.InvertStair.Layout(
				tree
			);

			var needUmbreall = tree.boxed.field.Where(n => n.Name == "NeedUmbrella");
			needUmbreall.ForEach(
				n =>
				layout.nodeAttrs.Add(n, new XAttribute[] {
					new XAttribute("fill", "yellow")
				})
			);




			var xDoc = layout.draw();

			var tgtFile = nilnul.fs.folder_.tmp.denote_.mainVered_._NextX.Spear(".svg").ToString();
			System.IO.File.WriteAllText(tgtFile, xDoc.ToString());

			//nilnul.fs.file.explore_._SelX.Vod(tgtFile);

			nilnul.fs.file._ExeX.Exe(tgtFile);
			nilnul.fs.file._ExeX.Exe(f);
			//nilnul.win.prog_.notepad.run_.shell_.NewWin.Singleton.run(tgtFile);

		}


	}
}
