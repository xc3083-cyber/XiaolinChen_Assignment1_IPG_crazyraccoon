using System.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace IPG_Assignment2;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D background;
    private Texture2D door;

    private Texture2D raindrop;

    //新增Main的private调用
    private Main _main;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
       //score font try
       SpriteFont scoreFont=Content.Load<SpriteFont>("File");

        _spriteBatch = new SpriteBatch(GraphicsDevice);

        //加载main类
        // _main=new Main();

        //加载png图片
        Texture2D playerTexture_1=Content.Load<Texture2D>("player_01");
        Texture2D playerTexture_2=Content.Load<Texture2D>("player_02");
        Texture2D playerTexture_3=Content.Load<Texture2D>("player_03");
        background=Content.Load<Texture2D>("background");
        door=Content.Load<Texture2D>("door");
        raindrop=Content.Load<Texture2D>("raindrop");
        Texture2D raccoon_1=Content.Load<Texture2D>("raccoon_01");
        Texture2D raccoon_2=Content.Load<Texture2D>("raccoon_02");
        Texture2D raccoon_3=Content.Load<Texture2D>("raccoon_03");
        Texture2D raccoon_4=Content.Load<Texture2D>("raccoon_04");
        
        _main=new Main(playerTexture_1,door,scoreFont,raindrop);

        


      
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        //调用Mian的Update方法
        _main.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        _spriteBatch.Begin();
        //画背景
        _spriteBatch.Draw(background,GraphicsDevice.Viewport.Bounds,Color.White);

        
        //调用的是main里面的draw function
        _main.Draw(_spriteBatch);
        _spriteBatch.End();


        base.Draw(gameTime);
    }
}
