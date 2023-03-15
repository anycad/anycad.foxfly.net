﻿using AnyCAD.Foundation;
using System;

namespace AnyCAD.Demo.Geometry
{
    class Geometry_Extrema : TestCase
    {
        public override void Run(IRenderView render)
        {
            var arc = SketchBuilder.MakeArcOfCircle(new GCirc(GP.XOY(), 10), 0, Math.PI);
            var points = new GPntList
            {
                new GPnt(0,0,0),
                new GPnt(2,5,0),
                new GPnt(15,15,0)
            };
            var line = SketchBuilder.MakeBSpline(points);

            var extrema = new ExtremaCurveCurve();
            extrema.Initialize(arc, line);
            int count = extrema.GetPointCount();
            for (int ii = 0; ii < count; ++ii)
            {                
                var point = extrema.GetPoint1(ii);
                var node = new PrimitiveSceneNode(GeometryBuilder.AtomSphere(), null);
                node.SetTransform(Matrix4.makeTranslation(Vector3.From(point)));
                render.ShowSceneNode(node);
            }

            render.ShowShape(arc, ColorTable.Red);
            render.ShowShape(line, ColorTable.Green);
        }
    }
}
