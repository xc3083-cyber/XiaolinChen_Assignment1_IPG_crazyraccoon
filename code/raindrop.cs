using System.ComponentModel.Design;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace IPG_Assignment2;

public class Rain
{
    private Texture2D _texture;
    private Vector2 _position;
    //copy player,s the speed, I should create a new update function for main to call
    private float _speed=200f;
    //initialize, this clas need 2 parameter texture and position
    public Rain(Texture2D raintexture, Vector2 position)
    {
        //store data
       _texture=raintexture;
       _position=position;
    
       
    }
    public Rectangle GetRainBounds()
    {
        return new Rectangle((int)_position.X,(int)_position.Y,10,20);
    }

    public void Update(GameTime gameTime)
    {
        //calculate the duration time 
        float duration=(float)gameTime.ElapsedGameTime.TotalSeconds;
        _position.Y+=duration*_speed;
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        Rectangle destination=new Rectangle((int)_position.X,(int)_position.Y,10,20);
        //drwa 
        spriteBatch.Draw(_texture,destination,Color.White);
        
    }

    
    
    
        
    
}