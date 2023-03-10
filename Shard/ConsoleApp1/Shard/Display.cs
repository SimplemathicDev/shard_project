/*
*
*   The abstract display class setting out the consistent interface all display implementations need.  
*   @author Michael Heron
*   @version 1.0
*   
*/

using SDL2;
using System;
using System.Drawing;
using System.Numerics;

namespace Shard
{
    abstract class Display
    {
        protected int _height, _width;

        public virtual void drawLine(int x, int y, int x2, int y2, int r, int g, int b, int a, int layer = Renderable.MaxLayer)
        {
        }

        public virtual void drawLine(int x, int y, int x2, int y2, Color col, int layer = Renderable.MaxLayer)
        {
            drawLine(x, y, x2, y2, col.R, col.G, col.B, col.A, layer);
        }


        public virtual void drawCircle(int x, int y, int rad, int r, int g, int b, int a, int layer = Renderable.MaxLayer)
        {
        }

        public virtual void drawCircle(int x, int y, int rad, Color col, int layer = Renderable.MaxLayer)
        {
            drawCircle(x, y, rad, col.R, col.G, col.B, col.A, layer);
        }

        public virtual void drawFilledCircle(int x, int y, int rad, Color col, int layer = Renderable.MaxLayer)
        {
            drawFilledCircle(x, y, rad, col.R, col.G, col.B, col.A, layer);
        }

        public virtual void drawFilledCircle(int x, int y, int rad, int r, int g, int b, int a, int layer = Renderable.MaxLayer)
        {
            while (rad > 0)
            {
                drawCircle(x, y, rad, r, g, b, a, layer);
                rad -= 1;
            }
        }

        public void showText(string text, double x, double y, int size, Color col, TextAlignment alignmentHorizontal = TextAlignment.Start, TextAlignment alignmentVertical = TextAlignment.Start)
        {
            showText(text, x, y, size, col.R, col.G, col.B, col.A, alignmentHorizontal, alignmentVertical);
        }



        public virtual void setFullscreen()
        {
        }

        public virtual IntPtr loadTexture(string path)
        {
            return IntPtr.Zero;
        }

        public virtual IntPtr loadTexture(Transform transform)
        {
            return IntPtr.Zero;
        }

        public virtual Vector2 GetTextureSize(IntPtr texture)
        {
            return new Vector2();
        }

        public virtual void addToDraw(Renderable renderable)
        {
        }

        public virtual void removeToDraw(Renderable renderable)
        {
        }
        public int getHeight()
        {
            return _height;
        }

        public int getWidth()
        {
            return _width;
        }

        public virtual void setSize(int w, int h)
        {
            _height = h;
            _width = w;
        }

        public abstract void initialize();
        public abstract void clearDisplay();
        public abstract void display();

        public abstract void showText(string text, double x, double y, int size, int r, int g, int b, int a, TextAlignment alignmentHorizontal = TextAlignment.Start, TextAlignment alignmentVertical = TextAlignment.Start);
        public abstract void showText(char[,] text, double x, double y, int size, int r, int g, int b, int a, TextAlignment alignmentHorizontal = TextAlignment.Start, TextAlignment alignmentVertical = TextAlignment.Start);
    }
}
