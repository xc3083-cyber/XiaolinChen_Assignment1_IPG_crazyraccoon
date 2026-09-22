
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IPG_Assignment2;

public class Main

{
    private Player _player;
    private Texture2D _doorTexture;
    private Rectangle _doorBounds;

    private SpriteFont _scorefont;

    private int count=0;
    private Rain raindrop;

    public Main(Texture2D playerTexture,Texture2D door,SpriteFont scoreFont,Texture2D raindropTexture)

    {
        _player=new Player(playerTexture,new Vector2(50,272));
        _doorTexture=door;
        _doorBounds=new Rectangle(620,240,160,160);
        _scorefont=scoreFont;
        raindrop=new Rain(raindropTexture,new Vector2(350,0));

        
        
    }
    public void Update(GameTime gameTime)
    {
        _player.Update(gameTime);

        Rectangle PlayerBounds=_player.GetBounds();
        Rectangle DoorHitBox=new Rectangle(_doorBounds.X+38,_doorBounds.Y+9,85,139);
        //collide
        if (PlayerBounds.Intersects(DoorHitBox))
        {
            count+=1;
            _player.Reset();
        }

        //rain 
        raindrop.Update(gameTime);
        
        
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        //darw the door
        spriteBatch.Draw(_doorTexture,_doorBounds,Color.White);
        //draw the player
        _player.Draw(spriteBatch);
        //draw the font
        spriteBatch.DrawString(_scorefont,$"Score:{count}",new Vector2(20,20),Color.White);

        //raindrop
        raindrop.Draw(spriteBatch);
        

        
    }
  
}