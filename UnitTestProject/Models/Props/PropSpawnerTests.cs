using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyRecycling.Models.Props;
using System.Drawing;
namespace UnitTestProject.Models.Props
{
    [TestClass()]
    public class PropSpawnerTests
    {
        [TestMethod()]
        public void Construct_MethodBuildsProps_PropFieldsAreSet()
        {
            //arrange
            PropSpawner propSpawner = new PropSpawner();
            MapPropBuilder builder1 = new TreeBuilder();
            MapPropBuilder builder2 = new MountainBuilder();
            MapPropBuilder builder3 = new MountainBuilder();
            //act
            propSpawner.Construct(builder1);
            propSpawner.Construct(builder2);
            //assert
            Assert.AreNotEqual(builder1.Prop.Picture.Location.X, 0);
            Assert.AreNotEqual(builder1.Prop.Picture.Location.Y, 0);
            Assert.AreNotEqual(builder1.Prop.Picture.Size.Width, 100);
            Assert.AreNotEqual(builder1.Prop.Picture.Size.Height, 50);
            Assert.IsNotNull(builder1.Prop.Picture.Image);

            Assert.AreNotEqual(builder2.Prop.Picture.Location.X, 0);
            Assert.AreNotEqual(builder2.Prop.Picture.Location.Y, 0);
            Assert.AreNotEqual(builder2.Prop.Picture.Size.Width, 100);
            Assert.AreNotEqual(builder2.Prop.Picture.Size.Height, 50);
            Assert.IsNotNull(builder2.Prop.Picture.Image);
        }
    }
}