using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D tlo;
    private Vector2 tlo_xy;
    private bool skok = false;
    private float czas_skoku = 0.0f;
    private float stratY = 0;
    private float kat = 0.0f;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        if (GraphicsDevice == null)
        {
        _graphics.ApplyChanges();
        }

        _graphics.PreferredBackBufferWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width;
        _graphics.PreferredBackBufferHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height;

        _graphics.ApplyChanges();
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        tlo = Content.Load<Texture2D>("postac");

        tlo_xy.Y = 300;
        stratY =tlo_xy.Y;
       // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
            KeyboardState klawisz = Keyboard.GetState();
            if(skok)
            {
                tlo_xy.Y += czas_skoku;
                czas_skoku += 1;
                if(tlo_xy.Y >= stratY)
                {
                    tlo_xy.Y = stratY;
                    skok = false;
                }
            }
            else
            {
                if(klawisz.IsKeyDown(Keys.Up)){
                skok = true;
                czas_skoku = -15;
                }
            }
            //sterowanie
            if(tlo_xy.X+tlo.Width < _graphics.PreferredBackBufferWidth)
            {
                if(klawisz.IsKeyDown(Keys.Right))
                {
                    tlo_xy.X+=10;
                }
            }
            if(tlo_xy.X > 0)
            {
                if(klawisz.IsKeyDown(Keys.Left))
                {
                    tlo_xy.X -= 10;
                }
            }

        // TODO: Add your update logic here
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin();
        Vector2 obrot = new Vector2();
        _spriteBatch.Draw(tlo,tlo_xy,null,Color.White,kat,obrot,1.01f,SpriteEffects.None,1);
        _spriteBatch.End();
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}