using UnityEngine;

public class ButtonScene : MonoBehaviour
{
    public enum TipoBoton
    {
        Jugar,
        MenuPrincipal,
        Regresar
    }

    public TipoBoton tipo;

    public void EjecutarAccion()
    {
        switch (tipo)
        {
            case TipoBoton.Jugar:
                SceneEvents.Jugar();
                break;

            case TipoBoton.MenuPrincipal:
                SceneEvents.volverMenu();
                break;

            case TipoBoton.Regresar:
                SceneEvents.volverMenu();
                break;

            default:
                Debug.LogWarning("El tipo de boton no esta configurado");
                break;
        }
    }
}