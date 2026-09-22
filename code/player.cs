using System.ComponentModel.Design;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace IPG_Assignment2;

public class Player
{
    private Texture2D _texture;
    private Vector2 _position;

    private Vector2 _startposition;

    //player movement,this is the speed, I should create a new update function for main to call
    private float _speed=200f;
    //initialize, this clas need 2 parameter texture and position
    public Player(Texture2D texture, Vector2 position)
    {
        //store data
       _texture=texture;
       _position=position;
       _startposition=position;
       
    }
    //rest to the start point
    public void Reset()
    {
        _position=_startposition;
    }

    //返回一个bound
    public Rectangle GetBounds()
    {
        return new Rectangle((int)_position.X+32,(int)_position.Y+17,65,97);
    }

    public void Update(GameTime gameTime)
    {
        //calculate the duration time 
        float duration=(float)gameTime.ElapsedGameTime.TotalSeconds;
        KeyboardState keyboard=Keyboard.GetState();
        if (keyboard.IsKeyDown(Keys.A))
        {
            _position.X-=_speed*duration;

        }
        if (keyboard.IsKeyDown(Keys.D))
        {
            _position.X+=_speed*duration;
        }
        if (_position.X < 0)
        {
            _position.X=0;
        }
        if (_position.X > 800 - 128)
        {
            _position.X=800-128;
        }
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        Rectangle destination=new Rectangle((int)_position.X,(int)_position.Y,128,128);
        //drwa 
        spriteBatch.Draw(_texture,destination,Color.White);
        
    }

    
    
    
        
    
}