namespace TDS.Game.Input
{
    using UnityEngine;
    public class StandardInputService : IInputService
    {
        #region Public methods

        public Vector2 Axis =>
            new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        public Vector3 MousePosition => 
            Input.mousePosition;

        public bool IsFireButtonClicked() =>
            Input.GetButtonDown("Fire1");

        #endregion
    }
}
