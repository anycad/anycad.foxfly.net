﻿using AnyCAD.Foundation;



namespace AnyCAD.Demo.Graphics
{
    class Graphics_Text : TestCase
    {
        static bool mLoaded = false;
        public override void Run(IRenderView render)
        {
            if(!mLoaded)
            {
                mLoaded = true;

                FontManager.Instance().AddFont("LS", @"C:\Windows\Fonts\STLITI.TTF");
            }    

            {
                var fontMaterial = FontMaterial.Create("font-texture-1");
                fontMaterial.SetFaceSide(EnumFaceSide.DoubleSide);
                fontMaterial.SetColor(new Vector3(1, 1, 0));
                fontMaterial.SetBackground(new Vector3(0, 0, 1));
                fontMaterial.SetBillboard(true);

                var dim = fontMaterial.SetText(" Hello 世界! ", 128, "LS");
                var shape = GeometryBuilder.CreatePlane(dim.x * 0.05f, dim.y * 0.05f);

                var node = new PrimitiveSceneNode(shape, fontMaterial);
                node.SetPickable(false);
                node.SetTransform(Matrix4.makeTranslation(new Vector3(100, -100, 100)));
                render.ShowSceneNode(node);
            }
            {
                var fixedSizeMaterial = SpriteMaterial.Create("font-mesh-material");
                fixedSizeMaterial.SetSizeAttenuation(false);
                fixedSizeMaterial.SetColor(ColorTable.OrangeRed);

                var mesh = FontManager.Instance().CreateMesh("为中华之崛起而代码！");
                var node = new PrimitiveSceneNode(mesh, fixedSizeMaterial);
                var scale = 1 / 44.0f;
                node.SetTransform(Matrix4.makeTranslation(10, 10, 10) * Matrix4.makeScale(scale, scale, scale));
                node.SetPickable(false);

                render.ShowSceneNode(node);
                
            }

            {
                var text = new TextSceneNode(" 33.0℃ ", 32, ColorTable.White, ColorTable.Green, true);
                var tag = TagNode2D.Create(text, new Vector3(10, 10, 0), new Vector3(0));
                render.ShowSceneNode(tag);
            }

            {
                var text = TextSceneNode.Create("不缩放大小", ColorTable.Green, 24, true);
                var tag = TagNode2D.Create(text, new Vector3(-10, -10, -10));               
                render.ShowSceneNode(tag);

                var pt = GeometryBuilder.CreatePoint(new Vector3(-10, -10, -10));
                var node = PrimitiveSceneNode.Create(pt, null);
                render.ShowSceneNode(node); 
            }

        }
    }
}
