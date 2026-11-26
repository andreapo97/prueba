using Prueba.models;

namespace Prueba.interfaces
{
    public interface IMuestra
    {
        //metodo para listar
        Task<Response> ListarTodasLasMuestras();

        //metodo para traer muestra por id
        Task<Response> TraerMuestraPorId(int id);

        //metodo para crear
        Task<Response> CrearOEditarUnaMuestra(MuestrasModel muestra);

        //metodo para eliminar
        Task<Response> EliminarMuestra(int id);

        //metodo para cambiar de estado
        Task<Response> CambiarEstadoDeMuestra(Status status);

        //metodo para consultar tipo de muestra
        Task<Response> ListaTiposDeMuestra();
    }
}
