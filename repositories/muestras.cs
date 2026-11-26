using Prueba.interfaces;
using Prueba.models;

namespace Prueba.repositories
{
    public class muestras : IMuestra
    {
        List<MuestrasModel> listaMuestras = new List<MuestrasModel>();

        List<TipoMuestra> tiposDeMuestras = new List<TipoMuestra>
        {
            new TipoMuestra { id = 1, nombre = "Sangre" },
            new TipoMuestra { id = 2, nombre = "Orina" },
            new TipoMuestra { id = 3, nombre = "Heces" }
        };

        async public Task<Response> CrearOEditarUnaMuestra(MuestrasModel muestra)
        {

            if (muestra.id == 0)
            {
                muestra.id = listaMuestras.Count() + 1;
                listaMuestras.Add(muestra);

                return new Response
                {
                    Status = 201,
                    Flag = true,
                    Message = "Muestra Creada correctamente"
                };
            }
            else
            {
                int index = listaMuestras.FindIndex(x => x.id == muestra.id);
                listaMuestras[index] = muestra;

                return new Response
                {
                    Status = 200,
                    Flag = true,
                    Message = "Muestra Editada correctamente"
                };
            }
        }

        async public Task<Response> EliminarMuestra(int id)
        {

            listaMuestras.RemoveAll(x => x.id == id);

            return new Response
            {
                Status = 200,
                Flag = true,
                Message = "Muestra eliminada correctamente"
            };

        }

        async public Task<Response> ListarTodasLasMuestras()
        {
            return new Response
            {
                Status = 200,
                Flag = true,
                Message = listaMuestras.Count() > 0 ? "Muestras encontradas" : "No hay muestras",
                Data = listaMuestras.Count() > 0 ? listaMuestras : null
            };
        }

        async public Task<Response> TraerMuestraPorId(int id)
        {
            //Buscamos el indice de la muestra en la lista
            int index = listaMuestras.FindIndex(x => x.id == id);

            //retornamos el item 

            return new Response
            {
                Data = listaMuestras[index],
                Flag = true,
                Message = "Tome su muestra",
                Status = 200
            };

        }

        async public Task<Response> CambiarEstadoDeMuestra(Status status)
        {
            int index = listaMuestras.FindIndex(x => x.id == status.id);
            listaMuestras[index].estado = status.estado;

            return new Response
            {
                Data = null,
                Flag = true,
                Message = "Se cambio",
                Status = 200
            };
        }

        async public Task<Response> ListaTiposDeMuestra()
        {
            return new Response
            {
                Data = tiposDeMuestras,
                Flag = true,
                Message = "Listado de muestra retornado",
                Status = 200
            };
        }
    }
}
