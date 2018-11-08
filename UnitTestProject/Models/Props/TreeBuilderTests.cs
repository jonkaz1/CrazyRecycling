using CrazyRecycling.Models.Props;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Models.Props
{
    [TestClass()]
    public class TreeBuilderTests
    {
        [TestMethod()]
        public void BuildPictureBox_MethodSetsAttribute_ImageIsNotNull()
        {
            //arrange
            MapPropBuilder builder = new TreeBuilder();
            //act
            builder.BuildPictureBox();
            //assert
            Assert.IsNotNull(builder.Prop.Picture.Image);
        }
        [TestMethod()]
        public void BuildSize_MethodSetsAttribute_SizeIsSetTo16And16()
        {
            //arrange
            MapPropBuilder builder = new TreeBuilder();
            //act
            builder.BuildSize();
            //assert
            Assert.AreEqual(builder.Prop.Picture.Size.Width, 16);
            Assert.AreEqual(builder.Prop.Picture.Size.Height, 16);
        }
        [TestMethod()]
        public void BuildLocation_MethodSetsAttribute_LocationIsSetTo10And10()
        {
            //arrange
            MapPropBuilder builder = new TreeBuilder();
            //act
            builder.BuildLocation(10, 10);
            //assert
            Assert.AreEqual(builder.Prop.Picture.Location.X, 10);
            Assert.AreEqual(builder.Prop.Picture.Location.Y, 10);
        }
    }
}
