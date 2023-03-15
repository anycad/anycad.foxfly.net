﻿using AnyCAD.Foundation;


namespace AnyCAD.Demo.Geometry
{
    class Geometry_Hole : TestCase
    {
        public override void Run(IRenderView render)
        {
            string fileName = GetResourcePath("models/hole.STEP");
            var shape = StepIO.Open(fileName);
            if (shape == null)
                return;

            var face = shape.FindChild(EnumTopoShapeType.Topo_FACE, 7);
            var wireExp = new WireExplor(face);
            var wires = wireExp.GetInnerWires();
            foreach(var wire in wires)
            {
                render.ShowShape(wire, ColorTable.Red);
            }
            render.ShowShape(shape,  ColorTable.LightYellow);
        }
    }
}
