namespace FyodorDostoevskyRPG
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class InputManager
    {
        // Fields
        private static InputManager instance;
        private MouseState currentMouseState, previousMouseState;
        private KeyboardState currentKeyboardState, previousKeyboardState;

        // Constructor for making the class singleton
        private InputManager()
        {
        }

        static InputManager()
        {
            InputManager.instance = new InputManager();
        }

        // Properties
        /// <summary>
        /// Access to the input manager
        /// </summary>
        public static InputManager Instance
        {
            get { return InputManager.instance; }
        }

        /// <summary>
        /// Get the current mouse position coordinates as a vector
        /// </summary>
        public Vector2 MousePosition
        {
            get { return new Vector2(currentMouseState.X, currentMouseState.Y); }
        }

        /// <summary>
        /// Get the rectangle at the current mouse position
        /// </summary>
        public Rectangle MouseRectanle
        {
            get { return new Rectangle(this.currentMouseState.X, this.currentMouseState.Y, 1, 1); }
        }

        // Methods
        /// <summary>
        /// Updates the mouse and keybord states
        /// </summary>
        public void Update()
        {
            this.previousMouseState = currentMouseState;
            this.previousKeyboardState = currentKeyboardState;
            this.currentMouseState = Mouse.GetState();
            this.currentKeyboardState = Keyboard.GetState();
        }        

        /// <summary>
        /// Checks if the left mouse button is pressed (up - down)
        /// </summary>
        public bool MouseLeftButtonPressed()
        {
            return this.previousMouseState.LeftButton == ButtonState.Released && this.currentMouseState.LeftButton == ButtonState.Pressed;
        }

        /// <summary>
        /// Checks if the left mouse button is pressed (down - up)
        /// </summary>
        public bool MouseLeftButtonPressedInverted()
        {
            return this.previousMouseState.LeftButton == ButtonState.Pressed && this.currentMouseState.LeftButton == ButtonState.Released;
        }

        /// <summary>
        /// Checks if the left mouse button is pressed
        /// </summary>
        public bool MouseLeftButtonDown()
        {
            return this.currentMouseState.LeftButton == ButtonState.Pressed;
        }

        /// <summary>
        /// Checks if the left mouse button is released
        /// </summary>
        public bool MouseLeftButtonUp()
        {
            return this.currentMouseState.LeftButton == ButtonState.Released;
        }

        /// <summary>
        /// Checks if the given key is pressed
        /// </summary>
        public bool KeyPressed(Keys k)
        {
            return this.currentKeyboardState.IsKeyDown(k) && this.previousKeyboardState.IsKeyUp(k);
        }
    }
}
