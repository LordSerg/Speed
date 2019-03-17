using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Math;
using OpenTK.Platform.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Speed
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //int texture;
        int x, y, z;
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            timer1.Enabled = true;
            //timer2.Interval = 1;
            //timer2.Enabled = true;
            //glControl1.SwapBuffers();
            //glControl1.Width = glControl1.Height;
        }

        //public static int load_texture(string path)
        //{
        //int id = GL.GenTexture();
        //GL.BindTexture(TextureTarget.Texture2D, id);
        //Bitmap bmp = new Bitmap(path);
        //BitmapData data = bmp.LockBits(new Rectangle(0,0,bmp.Width,bmp.Height),ImageLockMode.ReadOnly,System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        //GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
        //bmp.UnlockBits(data);
        ////GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Clamp);
        ////GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Clamp);
        //GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
        ////GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
        //return id;
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {//текстура!!!
         /*GL.Enable(EnableCap.Texture2D);
         texture = load_texture(@"C:\Users\moskalenko_s\Desktop\My games\Speed\Speed\House01.png");
         GL.Clear(ClearBufferMask.ColorBufferBit);
         GL.ClearColor(Color.SandyBrown);

         GL.BindTexture(TextureTarget.Texture2D, texture);
         GL.Begin(PrimitiveType.Quads);
         GL.Color3(Color.Brown);
         GL.TexCoord2(0, 0);
         GL.Vertex2(0, 0);

         GL.TexCoord2(1, 0);
         GL.Vertex2(0.4, 0);

         GL.TexCoord2(1, 1);
         GL.Vertex2(0.4, -0.4);

         GL.TexCoord2(0, 1);
         GL.Vertex2(0, -0.4);

         GL.End();


         glControl1.SwapBuffers();*/

            GL.ClearColor(Color.White);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            Bitmap bitmap = new Bitmap(@"C:\Users\moskalenko_s\Desktop\My games\Speed\Speed\House01.png");
            int texture;

            
            GL.Enable(EnableCap.Texture2D);

            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);

            GL.GenTextures(1, out texture);
            GL.BindTexture(TextureTarget.Texture2D, texture);

            BitmapData data = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            bitmap.UnlockBits(data);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            

            

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.BindTexture(TextureTarget.Texture2D, texture);
            for (double i = -1; i < 1; i += 0.1)
                for (double j = -1; j < 1; j += 0.1)
                {
                    GL.Begin(BeginMode.Quads);
                    GL.TexCoord2(0.0, 0.0); GL.Vertex2(i, j);
                    GL.TexCoord2(-1.0, 0.0); GL.Vertex2(i + 0.1, j);
                    GL.TexCoord2(-1.0, -1.0); GL.Vertex2(i + 0.1, j + 0.1);
                    GL.TexCoord2(0.0, -1.0); GL.Vertex2(i, j + 0.1);
                    GL.End();
                }

            glControl1.SwapBuffers();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color.Black);
            GL.Begin(PrimitiveType.Lines);
            Cube();
            GL.End();
            if (x != 0 || y != 0 || z != 0)
            {
                GL.Begin(PrimitiveType.Patches);
                GL.Rotate(1, x, y, z);
                GL.End();
            }
            glControl1.SwapBuffers();
        }

        private void glControl1_KeyDown(object sender, KeyEventArgs e)
        {
            //label1.Text = e.KeyValue.ToString();
        }

        private void glControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.CompareTo('a') == 0)
            {
                x++;
            }
            else if (e.KeyChar.CompareTo('d') == 0)
            {
                x--;
            }
            if (e.KeyChar.CompareTo('w') == 0)
            {
                y++;
            }
            else if (e.KeyChar.CompareTo('s') == 0)
            {
                y--;
            }
            if (e.KeyChar.CompareTo('x') == 0)
            {
                z++;
            }
            else if (e.KeyChar.CompareTo('z') == 0)
            {
                z--;
            }
            if (e.KeyChar.CompareTo(' ') == 0)
            {
                y = 0;
                x = 0;
                z = 0;
            }
            label1.Text = x.ToString() + " " + y.ToString() + " " + z.ToString();
        }

        void Cube()
        {
            GL.Color3(Color.Red);
            GL.Vertex3(0.5, 0.5, 0.5);
            GL.Vertex3(-0.5, 0.5, 0.5);

            GL.Vertex3(-0.5, 0.5, 0.5);
            GL.Vertex3(-0.5, 0.5, -0.5);

            GL.Vertex3(-0.5, 0.5, -0.5);
            GL.Vertex3(0.5, 0.5, -0.5);

            GL.Vertex3(0.5, 0.5, -0.5);
            GL.Vertex3(0.5, 0.5, 0.5);

            GL.Color3(Color.Yellow);
            GL.Vertex3(0.5, -0.5, 0.5);
            GL.Vertex3(0.5, -0.5, -0.5);

            GL.Vertex3(0.5, -0.5, -0.5);
            GL.Vertex3(-0.5, -0.5, -0.5);

            GL.Vertex3(-0.5, -0.5, -0.5);
            GL.Vertex3(-0.5, -0.5, 0.5);

            GL.Vertex3(-0.5, -0.5, 0.5);
            GL.Vertex3(0.5, -0.5, 0.5);

            GL.Color3(Color.Blue);
            GL.Vertex3(0.5, 0.5, 0.5);
            GL.Vertex3(0.5, -0.5, 0.5);

            GL.Vertex3(-0.5, 0.5, 0.5);
            GL.Vertex3(-0.5, -0.5, 0.5);

            GL.Vertex3(-0.5, 0.5, -0.5);
            GL.Vertex3(-0.5, -0.5, -0.5);

            GL.Vertex3(0.5, 0.5, -0.5);
            GL.Vertex3(0.5, -0.5, -0.5);

            GL.Color3(Color.Green);
            GL.Vertex3(0.5, 0.5, 0.5);
            GL.Vertex3(-0.5, -0.5, -0.5);

            GL.Vertex3(-0.5, 0.5, 0.5);
            GL.Vertex3(0.5, -0.5, -0.5);

            GL.Vertex3(-0.5, 0.5, -0.5);
            GL.Vertex3(0.5, -0.5, 0.5);

            GL.Vertex3(0.5, 0.5, -0.5);
            GL.Vertex3(-0.5, -0.5, 0.5);

        }
    }
}
