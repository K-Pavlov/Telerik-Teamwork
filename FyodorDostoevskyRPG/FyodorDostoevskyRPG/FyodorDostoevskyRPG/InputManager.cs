namespace FyodorDostoevskyRPG
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class InputManager
    {
        private static InputManager instance;
        private MouseState currentMouseState, previousMouseState;
        private KeyboardState currentKeyboardState, previousKeyboardState;

        private InputManager()
        {
        }

        static InputManager()
        {
            InputManager.instance = new InputManager();
        }

        public static InputManager Instance
        {
            get
            {
                return InputManager.instance;
            }
        }

        public void Update()
        {
            this.previousMouseState = currentMouseState;
            this.previousKeyboardState = currentKeyboardState;
            this.currentMouseState = Mouse.GetState();
            this.currentKeyboardState = Keyboard.GetState();
        }

        public Vector2 MousePosition
        {
            get
            {
                return new Vector2(currentMouseState.X, currentMouseState.Y);
            }
        }

        public bool MouseLeftButtonPressed()
        {
            return this.currentMouseState.LeftButton == ButtonState.Pressed && this.previousMouseState.LeftButton == ButtonState.Released;
        }

        public bool MouseLeftButtonDown()
        {
            return this.currentMouseState.LeftButton == ButtonState.Pressed;
        }

        public bool KeyPressed(Keys k)
        {
            return this.currentKeyboardState.IsKeyDown(k) && this.previousKeyboardState.IsKeyUp(k);
        }
    }
}
