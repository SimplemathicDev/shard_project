/*
*
*   Anything that is going to be an interactable object in your game should extend from GameObject.  
*       It handles the life-cycle of the objects, some useful general features (such as tags), and serves 
*       as the convenient facade to making the object work with the physics system.  It's a good class, Bront.
*   @author Michael Heron
*   @version 1.0
*   
*/

using SDL2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace Shard
{
    class GameObject : Renderable
    {
        private Transform3D transform;
        private bool transient;
        private bool toBeDestroyed;
        private bool visible;
        private int alpha = 255;
        private PhysicsBody myBody;
        private List<string> tags;

        public void addTag(string str)
        {
            if (tags.Contains(str))
            {
                return;
            }

            tags.Add(str);
        }

        public void removeTag(string str)
        {
            tags.Remove(str);
        }

        public bool checkTag(string tag)
        {
            return tags.Contains(tag);
        }

        public String getTags()
        {
            string str = "";

            foreach (string s in tags)
            {
                str += s;
                str += ";";
            }

            return str;
        }

        public void setPhysicsEnabled()
        {
            MyBody = new PhysicsBody(this);
        }


        public bool queryPhysicsEnabled()
        {
            if (MyBody == null)
            {
                return false;
            }
            return true;
        }

        internal Transform3D Transform
        {
            get => transform;
        }

        internal Transform Transform2D
        {
            get => (Transform)transform;
        }

        public bool Visible
        {
            get => visible;
            set => visible = value;
        }
        public int Alpha
        {
            get => alpha;
            set => alpha = Math.Min(255, Math.Max(0, value));
        }
        public bool Transient { get => transient; set => transient = value; }
        public bool ToBeDestroyed { get => toBeDestroyed; set => toBeDestroyed = value; }
        internal PhysicsBody MyBody { get => myBody; set => myBody = value; }

        public virtual void initialize()
        {
        }

        public virtual void update()
        {
            if (visible) Bootstrap.getDisplay().addToDraw(this);
        }

        public virtual void physicsUpdate()
        {
        }

        public virtual void prePhysicsUpdate()
        {
        }

        public GameObject()
        {
            GameObjectManager.getInstance().addGameObject(this);

            transform = new Transform3D(this);
            visible = true;

            ToBeDestroyed = false;
            tags = new List<string>();

            this.initialize();

        }

        public void checkDestroyMe()
        {

            if (!transient)
            {
                return;
            }

            if (Transform.X > 0 && Transform.X < Bootstrap.getDisplay().getWidth())
            {
                if (Transform.Y > 0 && Transform.Y < Bootstrap.getDisplay().getHeight())
                {
                    return;
                }
            }


            ToBeDestroyed = true;

        }

        public virtual void killMe()
        {
            PhysicsManager.getInstance().removePhysicsObject(myBody);

            myBody = null;
            transform = null;
        }

        public override void Render(IntPtr renderer)
        {
            if (transform.SpritePath == null)
            {
                return;
            }

            SDL.SDL_Rect sourceRect;
            SDL.SDL_Rect destinationRect;

            IntPtr sprite = Bootstrap.getDisplay().loadTexture(transform.SpritePath);
            Vector2 spriteSize = Bootstrap.getDisplay().GetTextureSize(sprite);

            sourceRect.x = 0;
            sourceRect.y = 0;
            sourceRect.w = (int)spriteSize.X;
            sourceRect.h = (int)spriteSize.Y;

            destinationRect.x = (int)transform.X;
            destinationRect.y = (int)transform.Y;
            destinationRect.w = (int)(transform.Wid * transform.Scalex);
            destinationRect.h = (int)(transform.Ht * transform.Scaley);

            SDL.SDL_SetTextureBlendMode(sprite, SDL.SDL_BlendMode.SDL_BLENDMODE_BLEND);//This sets the texture in blendmode

            SDL.SDL_SetTextureAlphaMod(sprite, (byte)alpha); //sets the alpha into the texture

            SDL.SDL_RenderCopyEx(renderer, sprite, ref sourceRect, ref destinationRect, (int)transform.Rotz, IntPtr.Zero, SDL.SDL_RendererFlip.SDL_FLIP_NONE);
        }
    }
}
