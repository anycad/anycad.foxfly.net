﻿using AnyCAD.Forms;
using AnyCAD.Foundation;
using System;



namespace AnyCAD.Demo.Graphics
{
    class Graphics_PointsGroup : TestCase
    {
        public override void Run(RenderControl render)
        {
            
            // prepare points data
            const int COUNT = 10;

            var material = PointsMaterial.Create("points-material");
            material.SetPointSize(4.0f);
            material.SetColor(ColorTable.IndianRed);

            var group = new GroupSceneNode();
            PrimitiveSceneNode node = null;
            Random random = new Random();
            for (int i = 0; i < COUNT; i++)
            {

                float x = 2000 * (float)random.NextDouble() - 1000;
                float y = 2000 * (float)random.NextDouble() - 1000;
                float z = 2000 * (float)random.NextDouble() - 1000;

                node = new PrimitiveSceneNode(GeometryBuilder.AtomPoint(), material);
                node.SetTransform(Matrix4.makeTranslation(x, y, z));

                group.AddNode(node);
            }

            render.ShowSceneNode(group);


            var picker = new PickedItem(node, new IntersectPoint(EnumShapeFilter.Zero, 0));

            render.GetContext().GetSelectionManager().GetSelection().Add(picker, true);
        }
    }
}
