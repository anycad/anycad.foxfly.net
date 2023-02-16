﻿using AnyCAD.Forms;
using AnyCAD.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyCAD.Demo
{
    public partial class NewForm3D : Form
    {
        RenderControl mRenderView;

        public delegate void UpdateTagHandler();
        public event UpdateTagHandler UpdateTagEvent;

        public Scene mScene;
        public NewForm3D(Scene scene)
        {
            mScene = scene;
            InitializeComponent();

            mRenderView = new RenderControl(this.panel1);
        }

        private void NewForm3D_Load(object sender, EventArgs e)
        {
            var box = GeometryBuilder.CreateBox(100, 200, 300);
            var material = MeshPhongMaterial.Create("simple");
            material.SetColor(ColorTable.Red);
            var node = new PrimitiveSceneNode(box, material);

            mRenderView.ShowSceneNode(node);


            //var itr = mScene.CreateIterator();
            //for(;itr.More();itr.Next())
            //{
            //    mRenderView.ShowSceneNode(itr.Current());
            //}


            mRenderView.SetStandardView(EnumStandardView.DefaultView);
            mRenderView.ZoomAll();

            // 转发给事件处理
            mRenderView.SetAfterRenderingCallback(()=>{
                if (UpdateTagEvent != null)
                    UpdateTagEvent();
            });

            // 创建两个自定义标注
            var mTagCtl = new MyTagControl(mRenderView, new Vector3(200, 300, 400), Vector3.Zero);
            UpdateTagEvent += mTagCtl.UpdateLayout;

            var mTagCtl2 = new MyTagControl(mRenderView, new Vector3(-100, -200, 100), Vector3.Zero);
            UpdateTagEvent += mTagCtl2.UpdateLayout;
        }
    }
}
