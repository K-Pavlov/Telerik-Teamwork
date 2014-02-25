namespace FyodorDostoevskyRPG.GameObject.GameItems
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class SpecialAbilityItem : Item, ISpecial
    {
        // Constructor
        protected SpecialAbilityItem(Texture2D image, Vector2 position)
            : base(image, position)
        {
        }

        // Methods
        /// <summary>
        /// Activates the special attack of the item
        /// </summary>
        public abstract bool ActivateSpecial();

        /// <summary>
        /// Deactivates the speacial attack of the item
        /// </summary>
        public abstract void DeactivateSpecial();
    }
}
